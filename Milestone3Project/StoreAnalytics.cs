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
    
    
}