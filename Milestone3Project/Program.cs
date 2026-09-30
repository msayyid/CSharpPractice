// Milestone 3 project

// Store Analytics System

// Checkpoint 1 

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