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
    
}