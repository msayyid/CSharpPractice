Console.WriteLine("Hello, World!");

// Variables 
// Csharp is statically typed
// string name = "Ali";
// int age = 21;
// double height = 1.82;
// bool isStudent = true;
//
// Console.WriteLine(name);
// Console.WriteLine(age);
// Console.WriteLine(height);
// Console.WriteLine(isStudent);
//
// int number = 10;
// double price = 19.99;
// bool isActive = true;
// char letter = 'A';
// string text = "wassup";
//
// Console.WriteLine(text);
//
// var age2 = 22;
// int age3 = 23;
//
// Console.WriteLine(age2);
// Console.WriteLine(age3);


// string interpolation 

// string name = "ali";
// var age = 21;
//
// Console.WriteLine("My name is " + name + " and i am " + age);
//
// Console.WriteLine($"My name is {name} and I am {age}");
//
// string city = "London";
// double temperature = 17.5;
// Console.WriteLine($"it is {temperature} in {city}.");


// Getting input

// Console.WriteLine("What is your name? ");
// string? name = Console.ReadLine();
//
// Console.WriteLine($"Hello, {name}!");

// string? - nullability, it warns that ReadLine could return null
// -----

// Converting input
// string? age = Console.ReadLine(); // this always returns string 

// int age = Console.ReadLine(); // doesn't work, we need conversion
// Console.WriteLine("Enter your age: ");
// int age = int.Parse(Console.ReadLine()!);
// Console.WriteLine($"Next year you will be {age + 1} years old. ");

// -------

// If statements

// int age = 2;
// bool hasTicket = true;
// if (age >= 18 && hasTicket)
// {
//     Console.WriteLine("Adult, You can enter");
// }
// else
// {
//     Console.WriteLine("Minor, or go away");
// }

// ----

/*
// Task 1
Console.Write("What is your name? ");
string? name = Console.ReadLine();

Console.WriteLine("How old are you? ");
int age = int.Parse(Console.ReadLine()!);

Console.WriteLine("What country are you from?");
string? country = Console.ReadLine();

Console.WriteLine($"Hello, {name}!\nYou are {age} years old and you are from {country}.\n" +
                  $"Next year you will be {age + 1}.");
if (age >= 18)
{
    Console.WriteLine("You are an adult");
}
else
{
    Console.WriteLine("You are a minor");
}
*/

// Lesson 2 - loops and collections

// for (int i = 0; i < 5; i++)
// {
//     Console.WriteLine(i);
// }
//
// int i1 = 0;
//
// while (i1 < 5)
// {
//     Console.WriteLine(i1 + " ione");
//     i1++;
// }

// string[] names =
// {
//     "Ali",
//     "John",
//     "Sarah"
// };
// // question so string[] names is a list of strings? [] - means list correct? - answered
//
// foreach (string name in names)
// {
//     Console.WriteLine(name);
// }

// so string[] is an array, it has fixed size, does it mean we cannot add or remove from it?
// string[] is an array that is fixed, not mutable

// List<T> - collection we can grow dynamically, meaning it is a list we can append, and remove from?
// answer - yes, List<t> is a list that can be appended to, removed from etc
// List<string> names = new List<string>(); // this is an old way of doing things
// List<string> names = new(); // new way of doing things
// names.Add("Ali");
// names.Add("John");
// names.Add("Sarah");
// foreach (string name in names)
// {
//     Console.WriteLine(name);
// }
// one more question, is csharp a indent proof like cpp or java? or is it like python? 
// answer it is like cpp and java not python

/*
// Task 2
Console.Write("How many names do you want to enter? ");

int number = int.Parse(Console.ReadLine()!);

List<string> names = new();

for (int i = 0; i < number; i++)
{
    Console.Write($"Enter name {i + 1}: ");
    string name = Console.ReadLine()!;
    names.Add(name);
}
Console.WriteLine("#########");
foreach (string name in names)
{
    Console.WriteLine(name);
}
*/

// Lesson 3 - Methods

// // void functions
// void Greet(string name) 
// {
//     Console.WriteLine($"Hello {name}");
// }
//
// Greet("Ali");
// // question, just to confirm we use camelcase for function/method names?
// // answer, no, we use PascalCase
//
// void PrintMessage()
// {
//     Console.WriteLine("Hello!");
// }
//
// PrintMessage();
//
// // parameters
// Greet("John");
// Greet("Sarah");
// Greet("Mo");
//
// void Introduce(string name, int age)
// {
//     Console.WriteLine($"My name is {name} and i am {age}");
// }
//
// Introduce("Ali", 23);
//
// // Returning a value
//
// int Add(int a, int b)
// {
//     return a + b;
// }
//
// int result = Add(10, 20);
// Console.WriteLine(result);
// Console.WriteLine(Add(10, 10));


/*
// Task 3

Console.Write("How many names do you want to enter? ");

int number = int.Parse(Console.ReadLine()!);

// PrintNames(GetNames(number));

List<string> names = GetNames(number);
PrintNames(names);


// iterates number of time and prompts the user for the names
// and saves the names in a list
List<string> GetNames(int number)
{
    List<string> names = new();
    for (int i = 0; i < number; i++)
    {
        Console.Write($"Enter name {i + 1}: ");
        string name = Console.ReadLine()!;
        // Console.WriteLine($"check name {name}");
        names.Add(name);
    }

    return names;
}

// takes a list of names and prints them out
void PrintNames(List<string> names)
{
    foreach (string name in names)
    {
        Console.WriteLine(name);
    }
}
*/

// Lesson 4 - classes, objects, constructors, and properties

// Person person = new Person();

// Person person = new Person("Ali", 24);
// // person.Name = "Alibay";
// // person.Age = 16;
//
// Console.WriteLine(person.Name);
// Console.WriteLine(person.Age);
//
// person.Introduce();
// if (person.IsAdult())
// {
//     Console.WriteLine("Adult");
// }
// else
// {
//     Console.WriteLine("Minor");
// }

// get set allow to read and change properties (Name, Age)
// get -> you're allowed to read it
// set -> you're allowed to change it

// question, just to confirm, so us putting get; set; in both in Person.cs meant 
// make this variable readable and changeable? is that right? 
// answer: yes that is right, if made private they become inaccessible

// one more question, if i am not mistaken in java i think, setters and getters give us
// like control whether a var is to change or to read or not? and python has _var , which is 
// only to let the devs know that it is to not change i mean i m kidna confused now, i made it worse
// i think, i need some clarification, please on get set s
// here what i knew was right, properties are there to make sure that sensitive variables 
// do not get changed by accident or whatever


// public and private
// public -> other code can access it
// private -> only this class can access it
// question, so what this basically means public var or methods can be accessed in anywhere
// of the code other files and shit, but private can only be accessed inside its own class
// it means literally, did i understand it right?
// answer: Properties let a class control how its data is read and changed
// private in c# means, you cannot access this attribute

// one more question, if files are in one directory, we do not need to like "import" them like in python and others?

// Task 4

Person person1 = new Person("Jumong", 23, "Kyrgyzstan");
Person person2 = new Person("Barsbek", 16, "England");

person1.Introduce();
person2.Introduce();

// person1.ShowAge(person1.IsAdult());
// person2.ShowAge(person2.IsAdult());
// separation of responsibilities

person1.ShowAgeStatus();
person2.ShowAgeStatus();


// property -> data exposed through get/set
// constructor -> initializes a new object
// public -> outside code can access it
// private -> only the class itself can access it