namespace Milestone1Project;

public class Store
{
    private readonly Dictionary<string, Product> _products = new();
    private readonly List<Order> _orders = new();
    // _name is a convention, it tells you this is a private
    // field belonging to the class

    public bool AddProduct(Product product)
    {
        if (_products.ContainsKey(product.Name))
        {
            return false;
        }

        _products.Add(product.Name, product);
        return true;
    }
    
    // find a product
    public Product? FindProduct(string productName)
    {
        if (_products.TryGetValue(productName, out Product? product))
            // i am not sure about this part at all
        {
            return product;
        }

        return null;
    }
    
    // Add order
    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }
    
    // find an order by ID
    public Order? FindOrderById(int id)
    {
        foreach (Order order in _orders)
        {
            if (order.Id == id)
            {
                return order;
            }
            
        }

        return null;
    }
    
    // display
    public void ShowProducts()
    {   
        Console.WriteLine("--- Products ---");
        foreach (var item in _products)
        {
            Console.WriteLine($"Product: {item.Value}");
        }
    }

    public void ShowOrders()
    {
        Console.WriteLine("--- Orders ---");
        foreach (var order in _orders)
        {
            // Console.WriteLine($"Order ID - {order.Id}\n" +
            //                   $"Product - {order.Product}\n" +
            //                   $"Order Status - {order.Status}\n" +
            //                   $"Order Quantity - {order.Quantity}");
            Console.WriteLine(order);
        }
    }
    
    // place order
    public Order? PlaceOrder(string productName, int quantity)
    {
        if (_products.TryGetValue(productName, out Product? product))
        {
            if (!product.Sell(quantity))
            {
                return null;
            }

            Order order = new Order(product, quantity);
            _orders.Add(order);
            return order;
        }
        // Console.WriteLine($"store.cs line 79\n couldn't find product");
        // Store handles logic, Program.cs decides what to display
        
        return null;

    }
    
    // change order status
    public bool ChangeOrderStatus(int orderId, OrderStatus newStatus)
    {
        foreach (var order in _orders)
        {
            if (order.Id == orderId)
            {
                order.ChangeStatus(newStatus);
                return true;
                
            }

        }

        return false;
    } 
    
}