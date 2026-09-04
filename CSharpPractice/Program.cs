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



