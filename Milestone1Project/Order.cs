namespace Milestone1Project;

public class Order
{
    private static int _nextId = 0; // shared counter
    // ------
    // private - only code inside Order can access it
    // static - one shared value for the whole Order class
    
    public int Id { get; } // this means, each individual order keeps its own ID
    
    /*
    // private static int _nextId
    // → one shared counter for all orders
    // → only Order can access it
    //
    // public int Id { get; }
    // → each order has its own ID
    // → outside code can read it
    // → cannot change it
    */
    
    
    public Product Product { get; }
    public int Quantity { get; }
    // the above four shouldn't change or become different,
    // therefore, no setters
    public OrderStatus Status { get; private set; }
    // we should choose getters and setters based on whether
    // the class actually needs to change the property

    public Order(Product product, int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("quantity must be greater than 0");
        }
        // since making the quantity negative would be a serious
        // error, i am throwing an error 
        _nextId++;
        Id = _nextId;
        Status = OrderStatus.Pending;
        Quantity = quantity;
        Product = product;
        
    }
    
    // Change status
    public void ChangeStatus(OrderStatus newStatus)
    {
        Status = newStatus; 
        // newStatus is a variable that can contain an OrderStatus value
    }

    public override string ToString()
    {
        return $"Order ID: {Id}\n" +
               $"Product: {Product}\n" +
               $"Quantity: {Quantity}\n" +
               $"Status: {Status}";
    }
}