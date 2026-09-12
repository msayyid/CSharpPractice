namespace Milestone1Practice;

public class Product
{
    public string Name { get; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    public Product(string name, decimal price, int stock)
    {
        Name = name;

        if (price < 0)
        {
            throw new ArgumentException("Initial price cannot be negative");
        }
        Price = price;

        if (stock < 0)
        {
            throw new ArgumentException("Initial stock cannot be negative");
        }
        Stock = stock;
    }

    public override string ToString()
    {
        return $"{Name} - {Price} - {Stock} in stock";
    }

    public void Restock(int stock)
    {
        if (stock < 0)
        {
            throw new ArgumentException("Input cannot be negative");
            // i am not sure whether to use throw here
            // or if and return
        }

        Stock += stock;
        Console.WriteLine($"{Name} has been restocked. Stock: {Stock}");
    }

    public void Sell(int stock)
    {
        if (stock < 0 || stock > Stock)
        {
            throw new ArgumentException("Invalid input / Not available");
        }

        Stock -= stock;
        Console.WriteLine($"{stock} pieces of {Name} has/have been sold. Availability: {Stock}");
    }

    public void ChangePrice(decimal newPrice)
    {
        if (newPrice < 0)
        {
            throw new ArgumentException("price cannot be negative");
        }

        Price = newPrice;
        Console.WriteLine($"{Name}'s price has been changed to {Price}");
    }

}