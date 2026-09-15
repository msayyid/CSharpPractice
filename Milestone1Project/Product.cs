namespace Milestone1Project;

public class Product
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    public Product(string name, decimal price, int stock) 
    // in here i didn't know whether to include price and stock in the 
    // constructor params, but i did, seemed kinda easier for me
    {
        if (price < 0)
        {
            Console.WriteLine("Price cannot be negative");
            return;
        }

        if (stock < 0)
        {
            Console.WriteLine("Stock cannot be negative");
            return;
        }

        Name = name;
        Price = price;
        Stock = stock;
    }
    
    // Restock
    public void Restock(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid amount input. Error in line 31, Restock()");
            return;
        }

        Stock += amount;
        // in here i thought, i could have made the Stock readonly
        // as it is only for counting
        // just a thougt, do address this one as well please
    }
    
    // Sell
    public bool Sell(int amount)
    {
        if (amount <= 0 || amount > Stock)
        {
            Console.WriteLine("Invalid amount input or Out of stock. Error: line 46, Sell()");
            return false;
        }

        Stock -= amount;
        return true;
    }
    
    // change price
    public void ChangePrice(decimal newPrice)
    {
        if (newPrice < 0)
        {
            Console.WriteLine("Invalid price input. Error: line 59, ChangePrice()");
            return;
        }

        Price = newPrice;
    }
    
    // override 
    public override string ToString()
    {
        return $"{Name} - £{Price} - {Stock} in stock";
    }
}