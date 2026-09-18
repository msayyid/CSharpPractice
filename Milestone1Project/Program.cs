using Milestone1Project;
//
// Product product1 = new("Mac M4", 2000, 12);
// Product product2 = new("Huawei MateBook", 1700, 10);
// Product product3 = new("Galaxy Book6", 1500, 15);
// product1.Sell(3);
// Console.WriteLine(product1);
// product1.Restock(11);
// Console.WriteLine(product1);
// product1.ChangePrice(1999);
// product2.Sell(23);
// Console.WriteLine("####################");
//
// Console.WriteLine(product1);
// Console.WriteLine(product1);
// Console.WriteLine(product2);
// Console.WriteLine(product3);
//
// Console.WriteLine("\n\n\n");
// Console.WriteLine("####################");
//
// Order order1 = new(product1, 2);
// Order order2 = new(product2, 3);
// Order order3 = new(product3, 3);
// Console.WriteLine(order1);
// Console.WriteLine(order2);
// Console.WriteLine(order3);
//
// Console.WriteLine("####################");
//
// order1.ChangeStatus(OrderStatus.Cancelled);
// Console.WriteLine(order1);
//
// Console.WriteLine("####################");
// Console.WriteLine("####################");
// Console.WriteLine("####################");
// Console.WriteLine("####################");

// Store store = new();
// // store.ShowOrders();
// // store.ShowProducts();
//
// // Add products
// Product product1 = new("Mac2", 1200, 10);
// Product product2 = new("Mac3", 1300, 15);
// Product product3 = new("Mac4", 1500, 20);
//
// // add products to store
// store.AddProduct(product1);
// store.AddProduct(product2);
// store.AddProduct(product3);
// // Console.WriteLine(store.AddProduct(product1)); // false
// store.ShowProducts();

// find an existing product
// Product? myProduct = store.FindProduct("mac2");

// if (myProduct == null)
// {
//     Console.WriteLine($"Product not found.");
// }
// else
// {
// Console.WriteLine($"Product found: {myProduct}");
// }
// 1 valid order



// Order? order = store.PlaceOrder("Mac2", 3);
// if (order != null)
// {
//     Console.WriteLine("Order created:");
//     Console.WriteLine(order);
// }
// else
// {
//     Console.WriteLine("Could not create order");
// }
//
// // 2. product doesn't exist
// store.PlaceOrder("Bananbook", 2); // fail
//
// // 3. not enough stock
// store.PlaceOrder("Mac2", 100); // fail stock didn't change
// Console.WriteLine(product1); 
//
// // 4. invalid quantity => handled, caught the exception
// try
// {
//     store.PlaceOrder("Mac2", -5);
// }
// catch (ArgumentException ex)
// {
//     Console.WriteLine(ex.Message);
// } 
//
//
// Order order1 = new(product1, 3);
// Order order2 = new(product2, 4);
// Order order3 = new(product3, 5);
//
// store.AddOrder(order1);
// store.AddOrder(order2);
// store.AddOrder(order3);
// store.ShowOrders();
//
// Console.WriteLine("CHecking change order status method");
// Console.WriteLine("-------------------------------------");
// // 5. order status change check
// if (!store.ChangeOrderStatus(2, OrderStatus.Processing))
// {
//     Console.WriteLine("Order not found");
// }
//
// Console.WriteLine(product2);
// Console.WriteLine(order1);
// Console.WriteLine("-------------------------------------");
//
// store.ShowOrders();
//



//
// // find order with id 2
// Order? my_order = store.FindOrderById(500);
// if (my_order != null)
// {
//     Console.WriteLine($"Order is found:\n" +
//                       $"{my_order}");
// }
// else
// {
//     Console.WriteLine("Order not found");
// }

// checkpoint 4 - Interactive menu

Store store = new();
DisplayMenu();

while (true)
{
    Console.Write("Choose an option: ");
    bool success = int.TryParse(Console.ReadLine(), out int choice);
    if (!success)
    {
        Console.WriteLine("Invalid input. Please try again");
        continue;
    }

    if (choice == 0)
    {
        Console.WriteLine("Bye");
        break;
    }

    switch (choice)
    {
        case 1:
            Console.WriteLine("Adding product");

            Console.Write("Product name: ");
            string productName = Console.ReadLine()!;
            decimal price;
            while (true)
            {
                Console.Write("Price: ");
                bool success1 = decimal.TryParse(Console.ReadLine(), out price);
                if (!success1 || price < 0)
                {
                    Console.WriteLine("invalid input. try again");
                }
                else
                {
                    break;
                }
            }

            int startingStock;
            while (true)
            {
                Console.Write("Starting stock: ");
                bool success2 = int.TryParse(Console.ReadLine(), out startingStock);
                if (!success2 || startingStock <= 0)
                {
                    Console.WriteLine("Invalid input. try again");
                }
                else
                {
                    break;
                }
            }
            // question  --- answered ----
            // i am not sure whether everythin above teh input handling should ve been
            // inside the method HandleAddProduct()
            // answer yes in later to make it look compact
            HandleAddProduct(productName, price, startingStock); 
            // question???: --- answered
            // the exception handling
            // right now when i try to create nonsene product, like price: -98
            // or stock: -12, i m not being reprompted, we are just throwing an error that's it and quitting
            // i think i wanted to ask where the looping must be to keep asking for a valid input
            // i mean if it must be in there, or is it something we deal with later?
            // answer: program.cs: tries to give the user a nice experience and re-prompt
            // product: guarantees an invalid Product can never exist
            
            // Console.WriteLine("we've reached in here !!!!!!");
            break;
        case 2:
            Console.WriteLine("Showing products");
            HandleShowProducts();
            break;
        case 3:
            Console.WriteLine("Find product");
            HandleFindProduct();
            break;
        case 4:
            Console.WriteLine("Place order");
            HandlePlaceOrder();
            break;
        case 5:
            Console.WriteLine("Show orders");
            HandleShowOrders();
            break;
        case 6:
            Console.WriteLine("Change order status:");
            HandleChangeOrderStatus();
            break;
        default:
            Console.WriteLine("Invalid input. Please try again");
            // DisplayMenu();
            break;
    }
    
}



void DisplayMenu()
{
    Console.WriteLine("===== STORE MANAGEMENT =====");
    Console.WriteLine("1. Add product");
    Console.WriteLine("2. Show products");
    Console.WriteLine("3. Find product");
    Console.WriteLine("4. Place order");
    Console.WriteLine("5. Show orders");
    Console.WriteLine("6. Change order status");
    Console.WriteLine("0. Exit");
}

void HandleAddProduct(string productName, decimal price, int startingStock)
{
    try
    {
        Product product = new(productName, price, startingStock);
        
        if (store.AddProduct(product))
        {
            Console.WriteLine("Product has been added");
        }
        else
        {
            Console.WriteLine("Product already exists");
        }

    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex}");
    }
}

void HandleShowProducts()
{
    store.ShowProducts();
}

void HandleFindProduct()
{
    Console.Write("Enter product name to find: ");
    string productName = Console.ReadLine()!;

    Product? product = store.FindProduct(productName);
    if (product == null)
    {
        Console.WriteLine($"Product: {productName} not found");
        return;
    }

    Console.WriteLine("Product found:");
    Console.WriteLine(product);
    // store.FindProduct(productName);
}

void HandlePlaceOrder()
{
    Console.Write("Enter product to name to order: ");
    string productName = Console.ReadLine()!;
    int quantity;
    while (true)
    {
        Console.Write("Enter Quantity: ");
        
        bool success = int.TryParse(Console.ReadLine(), out quantity);
        if (!success || quantity <= 0)
        {
            Console.WriteLine("Invalid input. Try again");
        }
        else
        {
            break;
        }
    }

    Order? order = store.PlaceOrder(productName, quantity);
    if (order == null)
    {
        Console.WriteLine("Product not found");
        return; // why is this redundant? 
    }
    else // why redundnat?
    {
        Console.WriteLine("Order has been placed");
        Console.WriteLine(order);
    }
}

void HandleShowOrders()
{
    store.ShowOrders();
}

void HandleChangeOrderStatus()
{
    Console.Write("Enter order ID to change status: ");
    bool success = int.TryParse(Console.ReadLine(), out int orderId);
    if (!success || orderId <= 0)
    {
        Console.WriteLine("Invalid input");
        return;
    } 
    // show the found order:
    Order? order = store.FindOrderById(orderId);
    if (order == null)
    {
        Console.WriteLine("Order not found");
        return;
    }

    Console.WriteLine(order);
    
    // since our order statuses are enum, i thought we could give the user
    // to choose from the options and we could assign it ourselves,
    // something like this:
    // 1 - Pending; 2 - processing; etc...
    // and before changing i am showing the user the order's info they want to change
    int statusChoice;
    while (true)
    {
        Console.WriteLine("Choose new order status:");
        Console.WriteLine("1 - Pending");
        Console.WriteLine("2 - Processing");
        Console.WriteLine("3 - Shipped");
        Console.WriteLine("4 - Delivered");
        Console.WriteLine("5 - Cancelled");
        bool success1 = int.TryParse(Console.ReadLine(), out statusChoice);
        if (!success1 || statusChoice < 1 || statusChoice > 5)
        {
            Console.WriteLine("Invalid input. Try again");
        }
        else
        {
            break;
        }
    }

    var newStatus = OrderStatus.Pending;
    switch (statusChoice)
    {
        case 1:
            newStatus = OrderStatus.Pending;
            Console.WriteLine($"Order status changed to {OrderStatus.Pending}");
            store.ChangeOrderStatus(orderId, newStatus);
            break;
        case 2:
            newStatus = OrderStatus.Processing;
            Console.WriteLine($"Order status changed to {OrderStatus.Pending}");
            store.ChangeOrderStatus(orderId, newStatus);
            break;
    }
    
}