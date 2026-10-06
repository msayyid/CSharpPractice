namespace Milestone3Project;

public class StoreAnalytics
{
    private readonly List<Product> _products = new();

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public List<Product> GetProductsByCategory(string category)
    {
        List<Product> products = _products
            .Where(product => product.Category == category)
            .ToList();
        return products;
    }


    public List<Product> GetProductsAbovePrice(decimal minimumPrice)
    {

        List<Product> products = _products
            .Where(product => product.Price > minimumPrice)
            .OrderBy(product => product.Price)
            .ToList();
        
        return products;
    }

    public List<string> GetProductNames()
    {

        List<string> products = _products
            .OrderBy(product => product.Name)
            .Select(product => product.Name)
            .ToList();
        return products;
    }

    public Product? FindProductById(int id)
    {
        return _products
            .FirstOrDefault(product => product.Id == id);
    }


    public Product? FindProductByName(string name)
    {
        return _products
            .FirstOrDefault(product => product.Name == name);
    }

    public List<Product> GetProductsByPrice(bool descending)
    {
        if (descending)
        {
            return _products
                .OrderByDescending(product => product.Price)
                .ToList();
        }

        return _products
            .OrderBy(product => product.Price)
            .ToList();
    }


    public List<Product> GetLowStockProducts(int threshold)
    {
        return _products
            .Where(product => product.Stock <= threshold)
            .OrderBy(product => product.Stock)
            .ToList();
    }

    public List<Product> SearchProducts(string text)
    {
        return _products
            .Where(product => product.Name.Contains(text))
            .OrderBy(product => product.Name)
            .ToList();
    }

    public int GetTotalProductCount()
    {
        return _products.Count();
    }


    public decimal GetTotalInventoryValue()
    {
        decimal totalValue = _products.Sum(product => product.Price * product.Stock);
        return totalValue;
    }

    public decimal GetMostExpensivePrice()
    {
        return _products.Max(product => product.Price);
    }

    
    public decimal GetCheapestPrice()
    {
        return _products.Min(product => product.Price);
    }


    public int GetOutOfStockCount()
    {
        return _products.Count(product => product.Stock == 0);
    }

    public bool HasOutOfStockProducts()
    {
        return _products.Any(product => product.Stock == 0);
    }

    public bool AreAllProductsInStock()
    {
        return _products.All(product => product.Stock > 0);
    }

    public int GetTotalStock()
    {
        return _products.Sum(pr => pr.Stock);
    }

    
    // IGrouping<string, Product>
    // IEnumerable<IGrouping<string, Product>> means:
    // a sequence of a category groups
    
    
    public IEnumerable<IGrouping<string, Product>> GetProductsByCategory() // a sequence of a category groups
    {
        // GroupBy() groups products that share the same Category.
        //
        // Each item returned by GroupBy() is an IGrouping<string, Product>.
        //
        // string  -> the key type, here the category name
        // Product -> the type of items stored inside each group
        //
        // Example:
        // group.Key = "Electronics"
        //
        // group contains:
        // MacBook
        // Iphone
        // Monitor
        //
        // So this method returns a sequence of category groups.
        
        return _products
            .GroupBy(product => product.Category);
    }

    // public List<CategorySummary> GetCategorySummaries()
    // {
    //     return _products
    //         .GroupBy(product => product.Category) // in here after this GroupBy(), each item is IGrouping<string, Product>
    //         .Select(group => new CategorySummary( // Select says for every category group, crate one CategorySummary
    //                 group.Key,
    //                 group.Count(),
    //                 group.Sum(product => product.Stock),
    //                 group.Sum(product => product.Stock * product.Price)
    //             )
    //         )
    //         .ToList();
    // }
    
    public List<CategorySummary> GetCategorySummaries()
    {
        return _products

            // After GroupBy(), each item is now a GROUP of Products,
            // not a single Product.
            //
            // Example:
            // "Electronics" -> MacBook, Iphone, Monitor
            // "Furniture"   -> Desk, Chair
            .GroupBy(product => product.Category)

            // Select() transforms each category group into ONE CategorySummary.
            //
            // Before Select:
            // IGrouping<string, Product>
            //
            // After Select:
            // CategorySummary
            .Select(group => new CategorySummary(

                // group.Key is the value we grouped by.
                // Here it is the category name, e.g. "Electronics".
                group.Key,

                // group itself contains all Products in this category.
                // Count() counts how many Products are inside this group.
                group.Count(),

                // Sum the Stock of every Product inside this category group.
                group.Sum(product => product.Stock),

                // Calculate the inventory value of every Product
                // in this category, then add those values together.
                //
                // Inventory value of one Product:
                // Price * Stock
                group.Sum(product => product.Stock * product.Price)
            ))

            // Select() produced a sequence of CategorySummary objects.
            // ToList() materializes that sequence into List<CategorySummary>.
            .ToList();
    }


    // public List<CategorySummary> GetCategorySummariesWithStockAtLeast(int minimumStock)
    // {
    //     return _products
    //         // .Where(product => product.Stock >= minimumStock)
    //         .GroupBy(product => product.Category)
    //         .Select(group => new CategorySummary( // question, so in here, select creates group of summaries for all the existing categories?
    //                 group.Key,
    //                 group.Count(), // and in here, how is this working, is it not like supposed to be, wait so group key is like key in a dict, and group itself has the contents is that it?
    //                 group.Sum(product => product.Stock),
    //                 group.Sum(product => product.Stock * product.Price)
    //             )
    //         )
    //         // .ToList()
    //         .Where(summary => summary.TotalStock >= minimumStock)
    //         .OrderByDescending(summary => summary.TotalStock)
    //         .ToList();
    // }
    
    public List<CategorySummary> GetCategorySummariesWithStockAtLeast(int minimumStock)
    {
        return _products

            // First group Products by category.
            // Each item after this is one category group.
            .GroupBy(product => product.Category)

            // Convert every category group into one CategorySummary.
            //
            // Important:
            // Select() is NOT creating another group.
            // It transforms:
            //
            // category group -> CategorySummary
            .Select(group => new CategorySummary(
                group.Key,
                group.Count(),
                group.Sum(product => product.Stock),
                group.Sum(product => product.Stock * product.Price)
            ))

            // At this point each item is a CategorySummary,
            // so now we can filter by the TOTAL stock of the whole category.
            //
            // This is different from filtering individual Products by Stock.
            .Where(summary => summary.TotalStock >= minimumStock)

            // Sort category summaries by total stock,
            // highest total stock first.
            .OrderByDescending(summary => summary.TotalStock)

            .ToList();
    }
    
}