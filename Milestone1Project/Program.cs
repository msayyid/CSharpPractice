using System.Diagnostics;
using System.Net;
using Milestone1Project;

Product product1 = new("Mac M4", 2000, 12);
Product product2 = new("Huawei MateBook", 1700, 10);
Product product3 = new("Galaxy Book6", 1500, 15);
product1.Sell(3);
Console.WriteLine(product1);
product1.Restock(11);
Console.WriteLine(product1);
product1.ChangePrice(1999);
product2.Sell(23);
Console.WriteLine("####################");

Console.WriteLine(product1);
Console.WriteLine(product1);
Console.WriteLine(product2);
Console.WriteLine(product3);

Console.WriteLine("\n\n\n");
Console.WriteLine("####################");

Order order1 = new(product1, 2);
Order order2 = new(product2, 3);
Order order3 = new(product3, 3);
Console.WriteLine(order1);
Console.WriteLine(order2);
Console.WriteLine(order3);

Console.WriteLine("####################");

order1.ChangeStatus(OrderStatus.Cancelled);
Console.WriteLine(order1);