// Milestone 3 project

// Store Analytics System

// Checkpoint 1 

using System.Globalization;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using Milestone3Project;

Product product1 = new Product(1, "MacBook", "Electronics", 1500m, 5);
Product product2 = new Product(2, "Iphone", "Electronics", 900m, 10);
Product product3 = new Product(3, "Desk", "Furniture", 300m, 4);
Product product4 = new Product(4, "Chair", "Furniture", 150m, 8);
Product product5 = new Product(5, "Monitor", "Electronics", 400m, 6);
Product product6 = new Product(6, "Keyboard", "Accessories", 80m, 20);

StoreAnalytics storeAnalytics = new StoreAnalytics();
storeAnalytics.AddProduct(product1);
storeAnalytics.AddProduct(product2);
storeAnalytics.AddProduct(product3);
storeAnalytics.AddProduct(product4);
storeAnalytics.AddProduct(product5);
storeAnalytics.AddProduct(product6);

var products = storeAnalytics.GetProductsByCategory("Electronics");
// Console.WriteLine(products);
foreach (var VARIABLE in products)
{
    Console.WriteLine(VARIABLE);
}

Console.WriteLine("---------------------------------");
var productsAbovePrice = storeAnalytics.GetProductsAbovePrice(350);
// Console.WriteLine(productsAbovePrice);
foreach (var VARIABLE in productsAbovePrice)
{
    Console.WriteLine(VARIABLE);
}


Console.WriteLine("---------------------------------");
var productNames = storeAnalytics.GetProductNames();
// Console.WriteLine(productNames);
foreach (var VARIABLE in productNames)
{
    Console.WriteLine(VARIABLE);
}


// Checkpoint 2 - searching + sorting
var line = "---------------------------------";
Console.WriteLine(line);
Console.WriteLine(line);
Console.WriteLine(line);

Console.WriteLine(storeAnalytics.FindProductById(1));
Console.WriteLine(storeAnalytics.FindProductById(987)); // null

Console.WriteLine(line);
Console.WriteLine(storeAnalytics.FindProductByName("MacBook"));
Console.WriteLine(storeAnalytics.FindProductByName("Banana")); // null


Console.WriteLine(line);
var productsByPrice = storeAnalytics.GetProductsByPrice(false);

foreach (var VARIABLE in productsByPrice)
{
    Console.WriteLine(VARIABLE);
}

Console.WriteLine(line);
var productsByPrice2 = storeAnalytics.GetProductsByPrice(true);
foreach (var VARIABLE in productsByPrice2)
{
    Console.WriteLine(VARIABLE);
}

Console.WriteLine(line);
Console.WriteLine("Low stock products");
Console.WriteLine(line);

var lowStockProducts = storeAnalytics.GetLowStockProducts(5);
foreach (var VARIABLE in lowStockProducts)
{
    Console.WriteLine(VARIABLE);
}

Console.WriteLine(line);
var searchedProducts = storeAnalytics.SearchProducts("t");
foreach (var VARIABLE in searchedProducts)
{
    Console.WriteLine(VARIABLE);
}


// checkpoint 3 - store statistics / aggregation
Console.WriteLine(line);
Console.WriteLine(storeAnalytics.GetTotalProductCount());

Console.WriteLine(line);
Console.WriteLine(storeAnalytics.GetTotalStock());

Console.WriteLine(line);
Console.WriteLine(storeAnalytics.GetTotalInventoryValue());

Console.WriteLine(line);
Console.WriteLine(storeAnalytics.GetMostExpensivePrice());

Console.WriteLine(line);
Console.WriteLine(storeAnalytics.GetCheapestPrice());

Console.WriteLine(line);
Console.WriteLine(storeAnalytics.GetOutOfStockCount());

Console.WriteLine(line);
Console.WriteLine(storeAnalytics.HasOutOfStockProducts());

Console.WriteLine(line);
Console.WriteLine(storeAnalytics.AreAllProductsInStock());

storeAnalytics.AddProduct(new Product(7, "Mouse", "Accessories", 40m, 0));

Console.WriteLine(line);
Console.WriteLine(storeAnalytics.HasOutOfStockProducts());

Console.WriteLine(line);
Console.WriteLine(storeAnalytics.AreAllProductsInStock());




// Checkpoint 4 - GroupBy()j + category reports

Console.WriteLine(line);
Console.WriteLine(line);
Console.WriteLine(line);

// print out the groups and their content with nested loops
var groups = storeAnalytics.GetProductsByCategory();
foreach (var group in groups)
{
    Console.WriteLine(group.Key);
    foreach (var VARIABLE in group)
    {
        Console.WriteLine($"- {VARIABLE.Name}");
    }
}


// for every category, calculate CategorySummary
Console.WriteLine(line);
Console.WriteLine(line);
var summaries = storeAnalytics.GetCategorySummaries();
foreach (var VARIABLE in summaries)
{
    Console.WriteLine(VARIABLE.Category);
    Console.WriteLine($"Products: {VARIABLE.ProductCount}");
    Console.WriteLine($"Stock: {VARIABLE.TotalStock}");
    Console.WriteLine($"Value: {VARIABLE.InventoryValue}");
    Console.WriteLine(line);
}

Console.WriteLine(line);
Console.WriteLine(line);
var minStock = 13;
var summariesByMinStock = storeAnalytics.GetCategorySummariesWithStockAtLeast(minStock);
Console.WriteLine($"Minimum Stock: {minStock}");
Console.WriteLine(line);

foreach (var VARIABLE in summariesByMinStock)
{
    Console.WriteLine($"Category: {VARIABLE.Category}");
    Console.WriteLine($"Products: {VARIABLE.ProductCount}");
    Console.WriteLine($"Stock: {VARIABLE.TotalStock}");
    Console.WriteLine($"Value: {VARIABLE.InventoryValue}");
    Console.WriteLine(line);
}




// Checkpoint 5 - Func<> custom filtering + final cleanup

Console.WriteLine(line);
Console.WriteLine(line);
Console.WriteLine(line);

var expensiveProducts = storeAnalytics.FilterProducts(product => product.Price > 500);
foreach (var VARIABLE in expensiveProducts)
{
    Console.WriteLine(VARIABLE);
}

Console.WriteLine(line);
var electronics = storeAnalytics.FilterProducts(product => product.Category == "Electronics");
foreach (var VARIABLE in electronics)
{
    Console.WriteLine(VARIABLE);
}

Console.WriteLine(line);

var lowStockProducts1 = storeAnalytics.FilterProducts(product => product.Stock <= 5);
foreach (var VARIABLE in lowStockProducts1)
{
    Console.WriteLine(VARIABLE);
}
// i honestly didn't really undersand how func works, i undersatnd it i sworking, making sense but like not fully
Console.WriteLine(line);
Console.WriteLine(line);

bool hasExpensiveProduct = storeAnalytics.Exists(product => product.Price > 1000);
Console.WriteLine(hasExpensiveProduct);

Console.WriteLine(line);
bool hasNoStock = storeAnalytics.Exists(product => product.Stock == 0);
Console.WriteLine(hasNoStock);

Console.WriteLine(line);
bool hasItem = storeAnalytics.Exists(product => product.Name == "banana");
Console.WriteLine(hasItem);