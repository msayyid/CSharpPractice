namespace Milestone8MixedPractice.Services;

public interface IInventoryService
// interface, any class that claims to be this interface must provide
// these operations
{
    List<InventoryItem> GetAll();

    InventoryItem? GetById(int id);

    InventoryItem Create(InventoryItem newItem);

    InventoryItem? Update(int id, InventoryItem updatedItem);

    bool Delete(int id);
}