using Microsoft.AspNetCore.Mvc;
using Milestone8MixedPractice.Services;

namespace Milestone8MixedPractice.Controllers;

[ApiController] // this means, this is an API controller so api-specific behavior must be applied
[Route("inventory")]
public class InventoryController : ControllerBase // ControllerBase gives controller helper methods like Ok(), NotFound()...
{

    private readonly IInventoryService _inventoryService; // is just a field where the controller will store the service it receives, so all controller methods can use it
    public InventoryController(IInventoryService inventoryService)
    {
        // this whole constructor means:
        // controller says: "i need an IInventoryService."
        // -> 
        // ASP.NET checks DI registration
        // -> 
        // IInventoryService -> InventoryService
        // ->
        // ASP.NET gives that object to the contructor
        // ->
        // we store it in _inventoryService
        _inventoryService = inventoryService;
        
        // when IInventoryService is called in here, DI registration passes
        // the actual InventoryService
    }
    
    [HttpGet]
    public IActionResult GetAllItems()
    {
        List<InventoryItem> items = _inventoryService.GetAll();
        return Ok(items);
    }


    [HttpGet("{id}")]
    public IActionResult GetItemById(int id)
    {
        InventoryItem? item = _inventoryService.GetById(id);
        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }


    [HttpPost]
    public IActionResult CreateItem(InventoryItem newItem)
    {
        // InventoryItem createdItem = _inventoryService.Create(newItem);
        if (string.IsNullOrWhiteSpace(newItem.Name))
        {
            return BadRequest("name cannot be empty");
        }

        if (newItem.Price < 0)
        {
            return BadRequest("Price cannot be negative");
        }

        if (newItem.Quantity < 0)
        {
            return BadRequest("Quantity cannot be negative");
        }
        InventoryItem createdItem = _inventoryService.Create(newItem);
        
        return CreatedAtAction(
            nameof(GetItemById),
            new { id = createdItem.Id },
            createdItem
            );
    }

    [HttpPut("{id}")]
    public IActionResult UpdateItem(int id, InventoryItem updatedItem)
    {

        InventoryItem? item = _inventoryService.GetById(id);

        if (item is null)
        {
            return NotFound();
        }
        
        if (string.IsNullOrWhiteSpace(updatedItem.Name))
        {
            return BadRequest("Name cannot be empty");
        }

        if (updatedItem.Price < 0)
        {
            return BadRequest("Price cannot be negative");
        }

        if (updatedItem.Quantity < 0)
        {
            return BadRequest("Quantity cannot be negative");
        }
        
        InventoryItem? result = _inventoryService.Update(id, updatedItem);
        
        
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteItem(int id)
    {
        bool result = _inventoryService.Delete(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}