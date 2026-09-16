namespace Milestone1Project;

public class Product
{
    public string Name { get; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    public Product(string name, decimal price, int stock) 
    // in here i didn't know whether to include price and stock in the 
    // constructor params, but i did, seemed kinda easier for me
    // ----- answer:
    // Yes - completely reasonable
    // A product needs a name, an initial price, and an initial stock
    // level in order to be created
    
    {
        if (price < 0)
        {
            // Console.WriteLine("Price cannot be negative");
            // return;
            // return ends up creating the product
            // if the product isn't valid, don't create the product
            throw new ArgumentException("Price cannot be negative");
        }

        if (stock < 0)
        {
            // Console.WriteLine("Stock cannot be negative");
            // return;
            // same issue: DO NOT CREATE TEH PRODUCT IF THE PRODUCT ISN'T VALID
            throw new ArgumentException("Stock cannot be negative");
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
            // Console.WriteLine("Invalid amount input. Error in line 31, Restock()");
            // return;
            // we will throw error, since this is a nonsense input
            throw new ArgumentException("Restock amount must be greater than 0");
        }

        Stock += amount;
        // in here i thought, i could have made the Stock readonly
        // as it is only for counting
        // just a thougt, do address this one as well please
        // ----- answer:
        // no. readonly means this field cannot be reassigned after initialization/construction
        
    }
    
    // Sell
    public bool Sell(int amount)
    {
        // if (amount <= 0 || amount > Stock)
        // {
        //     Console.WriteLine("Invalid amount input or Out of stock. Error: line 46, Sell()");
        //     return false;
        // }
        // Distinguish bad input from a normal failed operation:
        // bad input:
        if (amount <= 0)
        {
            throw new ArgumentException("Sale amount must be greater than 0");
        }

        // failed operation:
        if (amount > Stock)
        {
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
            // Console.WriteLine("Invalid price input. Error: line 59, ChangePrice()");
            // return;
            // throw error since it is a nonsense input
            throw new ArgumentException("Price cannot be negative");
        }

        Price = newPrice;
    }
    
    // override 
    public override string ToString()
    {
        return $"{Name} - £{Price} - {Stock} in stock";
    }
}