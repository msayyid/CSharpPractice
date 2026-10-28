using Microsoft.AspNetCore.Mvc;

namespace Milestone7Practice.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> products =
    [
        new(1, "Keyboard", 80, true),
        new(2, "Monitor", 300, true),
        new(3, "Mouse", 40, false)
    ];

    [HttpGet]
    public IActionResult GetProducts([FromQuery] bool? inStock)
    {
        if (inStock is not null)
        {
            return Ok(products.Where(product => product.InStock == inStock));
        }
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        Product? product = products.FirstOrDefault(product => product.Id == id);
        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }


    [HttpPost]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (string.IsNullOrWhiteSpace(newProduct.Name))
        {
            return BadRequest("Name cannot be empty");
        }

        if (newProduct.Price < 0)
        {
            return BadRequest("Price cannot be negative");
        }

        products.Add(newProduct);
        return CreatedAtAction(
            nameof(GetProductById), // which controller action retrieves this resource
            new { id = newProduct.Id }, // tell ASP.NET what value to use for {id}
            newProduct
            );
    }


    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product updatedProduct)
    {
        // find
        Product? product = products.FirstOrDefault(product => product.Id == id);
        if (product is null)
        {
            return NotFound();
        }
        
        // validate
        if (string.IsNullOrWhiteSpace(updatedProduct.Name))
        {
            return BadRequest("Name cannot be empty");
        }

        if (updatedProduct.Price < 0)
        {
            return BadRequest("Price cannot be empty");
        }

        Product replacement = updatedProduct with { Id = id };
        int index = products.IndexOf(product);
        products[index] = replacement;

        return Ok(replacement);
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateInStockRequest(int id, UpdateInStock request)
    {
        Product? product = products.FirstOrDefault(p => p.Id == id);
        if (product is null)
        {
            return NotFound();
        }

        Product updatedProduct = product with { InStock = request.InStock };
        int index = products.IndexOf(product);
        products[index] = updatedProduct;
        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        Product? product = products.FirstOrDefault(p => p.Id == id);
        if (product is null)
        {
            return NotFound();
        }

        products.Remove(product);
        return NoContent();
    }
    
    
    
    
}