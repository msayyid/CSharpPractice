namespace Milestone2Practice;

public abstract class Animal
{
    public string Name { get; set; }

    protected Animal(string name) // protected because only child classes are supposed to call it
    {
        Name = name;
    }


    public abstract string MakeSound();
    
}