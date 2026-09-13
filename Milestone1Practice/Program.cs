/*
// Practice 1 - Methods + loops + List <T>

Console.Write("How many numbers do you want to enter? ");

bool success = int.TryParse(Console.ReadLine(), out int number);

if (!success || number <= 0)
{
    Console.WriteLine("Invalid input");
}

List<int> numbers = new();
for (int i = 0; i < number; i++)
{
    Console.Write($"Enter number {i + 1}: ");
    int num = int.Parse(Console.ReadLine()!);
    numbers.Add(num);
}

int total = GetSum(numbers);
int largest = GetLargest(numbers);

Console.WriteLine($"The sum of the numbers is {total}");
Console.WriteLine($"The largest in the list is {largest}");


// get the sum
int GetSum(List<int> numbers)
{
    int total = 0;
    foreach (int num in numbers)
    {
        total += num;
    }

    return total;
}

// get the largest number
int GetLargest(List<int> numbers)
{
    int largest = numbers[0];
    for (int i = 1; i < numbers.Count; i++)
    {
        if (numbers[i] > largest)
        {
            largest = numbers[i];
        }
    }

    return largest;
}

*/


// ########################################



/*
// Practice 2 - Dictionary - TryParse - validation
// Build a small product stock system

Console.WriteLine("PRODUCT STOCK SYSTEM");

Dictionary<string, int> products = new();

for (int i = 0; i < 3; i++)
{
    Console.Write("Product name: ");
    string name = Console.ReadLine()!;
    Console.Write("Quantity: ");
    bool success = int.TryParse(Console.ReadLine(), out int quantity);
    if (!success || quantity < 0)
    {
        Console.WriteLine("Invalid quantity | (Or negative quantity)");
        return;
    }

    products[name] = quantity;
}

ShowAllProducts(products);

Console.Write("Which product do you want to search for? ");
string productName = Console.ReadLine()!;

if (products.TryGetValue(productName, out int retrievedQuantity))
{
    Console.WriteLine($"Product found. {productName} : {retrievedQuantity}");
}
else
{
    Console.WriteLine("Product not found");
}


void ShowAllProducts(Dictionary<string, int> products)
{
    Console.WriteLine("Products:");
    foreach (var item in products)
    {
        Console.WriteLine($"{item.Key} - {item.Value}");
    }
}

*/



// ########################################################
/*
// Practice 3 - Classes - encapsulation

using Milestone1Practice;

Product product1 = new("Mac", 999m, 10);
Product product2 = new("Asus", 420, 5);

Console.WriteLine(product1);
Console.WriteLine(product2);

// read properties
Console.WriteLine(product1.Name);
Console.WriteLine(product2.Name);

// sell 
product1.Sell(4);
Console.WriteLine(product1);

product2.Sell(1);
Console.WriteLine(product2);

// restock
product1.Restock(30);
Console.WriteLine(product1);

product2.Restock(20);
Console.WriteLine(product2);

// change price
// product1.Price = 500; // inaccessible 
product1.ChangePrice(1200);
Console.WriteLine(product1);

product2.ChangePrice(250);
Console.WriteLine(product2);
*/

// ########################################################



/*
// Practice 4 - enums - switch - object state
// Build a small support ticket system

using Milestone1Practice;

// SupportTicket ticket = new("Wifi is not working");
//
// Console.WriteLine(ticket);
// ticket.ShowStatus();
//
// ticket.Start();
// ticket.ShowStatus();
//
// ticket.Resolve();
// ticket.ShowStatus();
//
// ticket.Close();
// ticket.ShowStatus();

// Choose the return type based on what the caller needs back from the method

SupportTicket ticket = new("Wifi is not working");
Console.WriteLine(ticket);

Console.WriteLine(ticket.GetStatusMessage());

if (!ticket.Start())
{
    Console.WriteLine("Could not start ticket.");
}

Console.WriteLine(ticket.GetStatusMessage());

if (!ticket.Resolve())
{
    Console.WriteLine("Could not resolve");
}
Console.WriteLine((ticket.GetStatusMessage()));

if (!ticket.Close())
{
    Console.WriteLine("Could not close");
}
Console.WriteLine(ticket.GetStatusMessage());

*/

// ####################################

// Practice 5 - static - generics - exceptions

using Milestone1Practice;

Repository<string> names = new();
Repository<int> years = new();

names.ShowAll();
names.Add("Ali");
names.Add("Bek");
names.ShowAll();
names.Add("Maria");
Console.WriteLine(names);
string name = names.Get(1);
Console.WriteLine(name);
names.Add("Davud");

try
{
    string name1 = names.Get(3);
    Console.WriteLine(name1);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
names.Add("Juma");
Console.WriteLine(Repository<string>.TotalItemsAdded);
Console.WriteLine("#############");

years.ShowAll();
years.Add(2000);
years.Add(2004);
years.ShowAll();
years.Add(2109);
Console.WriteLine(years);
years.ShowAll();
Console.WriteLine(Repository<int>.TotalItemsAdded);

Console.WriteLine("#############");
Console.WriteLine("#############");
Console.WriteLine("#############");

Product product = new("Winds", 1200, 12);

Repository<Product> products = new();
products.ShowAll();
products.Add(product); // i didn't know how to do this, "apple gave an error"
products.ShowAll();
Console.WriteLine(Repository<Product>.TotalItemsAdded);
