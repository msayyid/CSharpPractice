public class Order
{
    public string ProductName { get; private set; }
    
    // Status is a property of type OrderStatus.
    // it stores one OrderStatus value.
    public OrderStatus Status { get; private set; } 

    public Order(string productName)
    {
        ProductName = productName;
        Status = OrderStatus.Pending;
    }

    public void ChangeStatus(OrderStatus newStatus)
    {
        Status = newStatus;
    }

    public void ShowStatus()
    {
        string message = Status switch // Order status is type, Status is a variable that stores one value at a time
        {
            OrderStatus.Pending => $"{ProductName} is waiting to be processed.",
            OrderStatus.Processing => $"{ProductName} is being prepared.", 
            OrderStatus.Shipped => $"{ProductName} is on the way.", 
            OrderStatus.Delivered => $"{ProductName} has been delivered.",
            OrderStatus.Cancelled => $"{ProductName} order was cancelled.",
            _ => "Unknown status. Error."

        };
        Console.WriteLine(message);
    }
}