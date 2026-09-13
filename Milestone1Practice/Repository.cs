namespace Milestone1Practice;

public class Repository<T>
{

    private readonly List<T> _items = new();
    public static int TotalItemsAdded { get; private set; }

    public void Add(T item)
    {
        _items.Add(item);
        TotalItemsAdded++;
    }

    public void ShowAll()
    {
        if (_items.Count <= 0)
        {
            Console.WriteLine("The list is empty");
            return;
        }

        foreach (T item in _items)
        {
            Console.WriteLine(item);
        }
    }

    public T Get(int index)
    {
        if (index >= _items.Count || index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        return _items[index];

    }
    
}