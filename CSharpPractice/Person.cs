public class Person
{
    public string Name { get; set; }
    
    public int Age { get; set; }
    
    public string Country { get; set; }

    // constructor
    public Person(string name, int age, string country)
    {
        Name = name;
        Age = age;
        Country = country;
    }
    // Name, Age - property
    // name, age - parameter of the constructor
    // so basically, we are saying: take the parameters and attach them to the actual attributes of the class?
    // is it a correct way to see it?
    // asnwer yes, that is a correct way


    public void Introduce()
    {
        Console.WriteLine($"My name is {Name} and I am {Age} years old and i am from {Country}");
    }

    public bool IsAdult()
    {
        return Age >= 18;
    }

    // public void ShowAge(bool isAdult) // i do not know if this is a correct usage
    // // this could have been in Person.cs as a function, but it is here
    // // i mean i am sure it would work either way, but which is recommended i guess?
    // {
    //     if (isAdult)
    //     {
    //         Console.WriteLine($"{Name} is an adult.");
    //     }
    //     else
    //     {
    //         Console.WriteLine($"{Name} is a minor.");
    //     }
    // }

    public void ShowAgeStatus()
    // for later:
    // Person, the class, might know its properties, but it shouldn't be
    // responsible for console output at all.
    {
        if (IsAdult())
        {
            Console.WriteLine($"{Name} is an adult.");
        }
        else
        {
            Console.WriteLine($"{Name} is a minor.");
        }
        
    }
}
