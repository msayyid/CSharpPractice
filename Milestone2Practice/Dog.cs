namespace Milestone2Practice;

public class Dog : Animal, IMovable
{

    public Dog(string name)
        : base(name)
    {
        // can i have an empty constructor for a child? i mean is this cool? -- answered --
        // yes, completely okay
    }
    
    public override string MakeSound()
    {
        return $"{Name} says woof";
    }

    public void Move()
    {
        Console.WriteLine($"{Name} is running");
    }
}