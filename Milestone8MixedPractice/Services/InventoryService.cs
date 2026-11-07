namespace Milestone8MixedPractice.Services;

public class InventoryService : IInventoryService
{
    private readonly List<InventoryItem> _items =
    [
        new(1, "Keyboard", 10, 80),
        new(2, "Monitor", 5, 300),
        new(3, "Mouse", 0, 40)
    ];

    public List<InventoryItem> GetAll()
    {
        return _items;
    }

    public InventoryItem? GetById(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);

        // if (item is null)
        // {
        //     return null;
        // }
        //
        // return item;
    }

    public InventoryItem Create(InventoryItem newItem)
    {
        _items.Add(newItem);
        return newItem;
    }

    public InventoryItem? Update(int id, InventoryItem updatedItem)
    {
        InventoryItem? item = _items.FirstOrDefault(item => item.Id == id);
        if (item is null)
        {
            return null;
        }

        int index = _items.IndexOf(item);
        InventoryItem replacement = updatedItem with { Id = id };
        _items[index] = replacement;
        return replacement;
    }

    public bool Delete(int id)
    {
        InventoryItem? item = _items.FirstOrDefault(item => item.Id == id);
        if (item is null)
        {
            return false;
        }

        _items.Remove(item);
        return true;

    }
}