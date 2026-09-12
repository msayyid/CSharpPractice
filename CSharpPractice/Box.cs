public class Box<T>
{
    public T Value { get; private set; }

    public Box(T value)
    {
        Value = value;
        
    }

    public void ShowValue()
    {
        Console.WriteLine(Value);
    }
        
}