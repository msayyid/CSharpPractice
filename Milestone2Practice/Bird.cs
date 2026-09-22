namespace Milestone2Practice;

public class Bird : Animal, IMovable
{
    public Bird(string name)
        : base(name)
    {
        // empty????
    }

    public override string MakeSound()
    {
        return $"{Name} says chirp";
    }

    public void Move()
    {
        Console.WriteLine($"{Name} is flying");
    }
}