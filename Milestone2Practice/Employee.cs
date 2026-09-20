using System.Globalization;

namespace Milestone2Practice;

public class Employee : Person, IWorker
{
    public string Company { get; }

    public Employee(string name, int age, string nationality, string company)
        : base(name, age, nationality)
    {
        Company = company;
    }

    public override string Introduce()
    {
        return $"My name is {Name}, I am {Age} years old. I am from {Nationality}. I work at {Company}";
    }

    public void Work()
    {
        Console.WriteLine($"{Name} is working at {Company}");
        
    }
}