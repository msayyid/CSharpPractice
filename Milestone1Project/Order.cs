namespace Milestone1Project;

public class Order
{
    public static int Id { get; private set; }
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public OrderStatus Status { get; private set; }
    // about the getters and setters of the above, i was not sure
    // what they should have so i just added them all, 
    // it does no harm does it?

    public Order(Product product, int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("quantity must be greater than 0");
        }
        // since making the quantity negative would be a serious
        // error, i am throwing an error

        Id++; // i am nto sure if this is correct way of doing it
        Status = OrderStatus.Pending;
        Quantity = quantity;
        Product = product;
        
    }
    
    // Change status
    public void ChangeStatus(OrderStatus newStatus)
    {
        Status = newStatus; // this also seemed not very correct
        // because earlier we were using the whole thing like
        // OrderStatus.Something, or am i confusing this?
    }

    public override string ToString()
    {
        return $"Order ID: {Id}\n" +
               $"Product: {Product}\n" +
               $"Quantity: {Quantity}\n" +
               $"Status: {Status}";
    }
}