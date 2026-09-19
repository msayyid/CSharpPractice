namespace Milestone2Practice;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    protected string Nationality; // { get; set; } // do we not need get set for this?
    // answer ---- 
    // this "protected string Nationality;" is a field.
    // field stores data directly
    
    // this "protected string Nationality; { get; set; }" is a property.
    // property gives control access
    
    public Person(string name, int age, string nationality)
    {
        Name = name;
        Age = age;
        Nationality = nationality;
    }

    public string Introduce()
    {
        return $"My name is {Name} and I am {Age} years old.";
    }
    
}

