using System.Diagnostics;

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
/*
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
*/

// // Lesson 5 - Encapsulation, validation, and controlling object state
//
// Person person = new("Jumong", 23);
// person.HaveBirthday();
// // person.Age = 40; // inaccessible and this is called encapsulation
// // "If you want to modify my age, use the behavior i provide"
// Console.WriteLine(person.Age);
//
// // object state - it simply means the current data is stored in that object.
// // HaveBirthday() changes the object's state
// // so methods often exist to safely change an object's state.
//
// // validation 
// // we can validate inside the constructor -> go to Person.cs
//
// // Person person1 = new("Barsbek", -20);
// // Console.WriteLine(person.Name);
//
// // double -> general floating-point calculations
// // decimal -> commonly preferred for money

/*
// Task 5
BankAccount account = new("Alibek", 1000m);
account.ShowBalance();

account.Deposit(500m);
account.ShowBalance();

account.Withdraw(200m);
account.ShowBalance();

account.Withdraw(5000m);
account.ShowBalance();


// BankAccount account2 = new("Jama", -400m); // exception handled. 
// account2.ShowBalance();
*/

// // Lesson 6 - Exceptions and error handling
//
// // try and catch
// // try -> attempt this code
// // catch -> if an exception happens, run this instead
//
// // int[] numbers = { 10, 20, 30 };
// // Console.WriteLine(numbers[10]); // error
//
// // try
// // {
// //     Console.Write("enter a number: ");
// //
// //     int number = int.Parse(Console.ReadLine()!);
// //     Console.WriteLine(100 / number);
// //
// // }
// // catch (FormatException)
// // {
// //     Console.WriteLine("That wasn't a valid integer.");
// // }
// // catch (DivideByZeroException)
// // {
// //     Console.WriteLine("You cannot divide by zero.");
// // }
//
// // throw
// // this is the opposite side of exception handling
// // catch handles an exception
// // throw creates one
// // int age = -7;
// //
// // if (age < 0)
// // {
// //     throw new ArgumentException("Age cannot be negative");
// // }
// // this is saying: "This input is invalid. Stop normal execution and throw an error."
//
//
//
// // try
// // {
// //     Person person = new("ali", -20);
// // }
// // catch (ArgumentException)
// // {
// //     Console.WriteLine("Could not create the person.");
// // }
//
// // flow is: Program.cs -> new Person(...) -> Person detects invalid age -> throws ArgumentException
// // -> Program catches it -> shows friendly message
//
// // getting the exception message
// try
// {
//     Person person1 = new("alibek", -23);
// }
// catch (ArgumentException ex)
// {
//     Console.WriteLine($"Error: {ex.Message}");
// }
//
//
//
// // finally
// // it runs whether the code succeeds or fails.
// // success -> finally runs
// // failure -> catch runs -> finally runs
//
// try
// {
//     Console.WriteLine("Trying something...");
// }
// catch
// {
//     Console.WriteLine("Something failed");
// }
// finally
// {
//     Console.WriteLine("This always runs");
// }
//
// // TryParse
// Console.Write("Enter your age: ");
// bool success = int.TryParse(Console.ReadLine(), out int age);
// // does this mean: if result of parsing is int age, then true otherwise false? 
// // answer: yes. it means: try to turn the input into an integer. tell me whether it worked using the returned bool,
// // and put the converted number into age
//
// if (success)
// {
//     Console.WriteLine($"Your age is {age}");
// }
// else
// {
//     Console.Write("Invalid age.");
// }


/*
// Task 6
try
{
    BankAccount account = new("Alibek", -1000m);
    account.ShowBalance();
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.Write("Enter your age: ");
bool success = int.TryParse(Console.ReadLine(), out int age);

if (success)
{
    Console.WriteLine($"You are {age} years old.");
}
else
{
    Console.WriteLine("Invalid age.");
}

// Note
// int.Parse(...) and int.TryParse(...) are solving similar problems differently
// int.Parse -> convert this. if you can't, throw an exception
// int.TryParse -> try converting this and simply tell me whether it worked.
*/

/*
// Lesson 7 - enum and switch

// enum is a type that has a fixed set of named choices

OrderStatus status = OrderStatus.Pending;
// Create a variable called status whose type is OrderStatus, and store the Pending 
// value of that enum inside it.
Console.WriteLine(status);

if (status == OrderStatus.Pending)
{
    Console.WriteLine("The order hasn't been processed yet.");
}

// switch
switch (status)
{
    case OrderStatus.Pending:
        Console.WriteLine("Waiting to be processed.");
        break;
    
    case OrderStatus.Processing:
        Console.WriteLine("Order is being prepared.");
        break;
    
    case OrderStatus.Shipped:
        Console.WriteLine("Order is on the way.");
        break;
    
    case OrderStatus.Delivered:
        Console.WriteLine("Order has arrived.");
        break;
    
    case OrderStatus.Cancelled:
        Console.WriteLine("Order was cancelled.");
        break;
    
    default: // - it is basically the else of a switch.
        Console.WriteLine("Some other status.");
        break;
    
}


string message = status switch
{
    OrderStatus.Pending => "Waiting to be processed",
    OrderStatus.Processing => "Being prepared.",
    OrderStatus.Shipped => "On the way.",
    OrderStatus.Delivered => "Delivered.",
    OrderStatus.Cancelled => "cancelled.",
    _ => "Unknown status."
};
Console.WriteLine("message one is about to be printed:");
Console.WriteLine(message);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();


Console.WriteLine("££££££££££££");
// OOP example
Order order = new("MacBook");
// order.ChangeStatus(OrderStatus.Shipped);
// Console.WriteLine(order.Status + order.ProductName);

order.ShowStatus();
order.ChangeStatus(OrderStatus.Processing);
order.ShowStatus();

order.ChangeStatus(OrderStatus.Shipped);
order.ShowStatus();

order.ChangeStatus(OrderStatus.Delivered);
order.ShowStatus();
*/

// // Lesson 8 - Dictionaries and useful collection operations
//
// Dictionary<string, int> ages = new();
// ages.Add("Ali", 23);
// ages.Add("Bek", 22);
// ages.Add("Khan", 17);
//
// Console.WriteLine(ages["Ali"]);
//
// foreach (var item in ages)
// {
//     Console.WriteLine($"{item.Key} is {item.Value} years old.");
// }
//
// if (ages.ContainsKey("Barsbek"))
// {
//     Console.WriteLine(ages["Barsbek"]);
// }
// else
// {
//     Console.WriteLine("Person does not exist");
// }
//
// // TryGetValue
// if (ages.TryGetValue("Bek", out int age))
// {
//     Console.WriteLine("The guy exists." + " age is " + age);
// }
// else
// {
//     Console.WriteLine("We got zero bro: " + age);
// }
//
// Console.WriteLine(ages.Count);
// ages.Remove("Ali");
// Console.WriteLine(ages.Count);
//
// List<string> names = new()
// {
//     "ali",
//     "bek",
//     "xon"
// };
// Console.WriteLine(names.Contains("John"));
// Console.WriteLine(names.IndexOf("ali"));

/*
// Task 8
Dictionary<string, int> students = new();
Console.WriteLine("Enter student names and their scores:");
for (int i = 0; i < 3; i++)
{
    Console.Write($"Student {i + 1}: ");
    string name = Console.ReadLine()!;
    
    Console.Write($"Enter student {i + 1}'s score: ");
    bool success = int.TryParse(Console.ReadLine(), out int score);
    if (success)
    {
        students[name] = score; // add this student, otherwise update their score
    }
    else
    {
        Console.WriteLine("Invalid score.");
        break;
    }
    
}

Console.WriteLine("Number of students: " + students.Count);
foreach (var item in students)
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}

Console.Write("Which student do you want to search for? ");
string name_prompt = Console.ReadLine()!;
if (students.TryGetValue(name_prompt, out int student_score))
{
    Console.WriteLine($"Success. {name_prompt}'s score is {student_score}");
}
else
{
    Console.WriteLine($"{name_prompt} not found.");
}
*/



// Lesson 9 - static, const, readonly

// 1. instance members vs static
// question - would it be correct to say instance methods are the ones that depend on the object
// and static ones are independent?
// answer - Instance members belong to a specific object. Static members belong to the class/type itself.

// If a method doesn't need the state of a particular object, it may make sense for it to be static.

// Example:
//
// public class Person
// {
//     public static int PersonCount { get; private set; } // the value becomes 0 automatically
//
//     public string Name { get; set; }
//
//     public Person(string name)
//     {
//         Name = name;
//         PersonCount++;
//     }
// }
//
// Now:
//
// Person person1 = new("Ali");
// Person person2 = new("John");
// Person person3 = new("Sarah");
//
// Then:
//
// Console.WriteLine(Person.PersonCount);
//
// prints:
//
// 3 



// static members can't directly access instance members

// const 
// const is static, should never change, and a value must be assigned to it right away
// - value must be known at compile time
// - never changes
// - inplicitly static

// readonly
// It is for when a value can be assigned when an object is created
// - value can be determined at runtime
// - normally assigned when object is created
// - cannot be changed afterward

// Task 9

Game game1 = new("Minecraft");
Game game2 = new("FC 26");
Game game3 = new("GTA V");

// instance members  /  object specific/dependent properties/fields
Console.WriteLine($"{game1.Name} created at - {game1.CreatedAt}");
Console.WriteLine($"{game2.Name} created at - {game2.CreatedAt}");
Console.WriteLine($"{game3.Name} created at - {game3.CreatedAt}");

// attributes/properties that belong to the class only not the object
Console.WriteLine($"Total games created: {Game.GamesCreated}");
Console.WriteLine($"Maximum players: {Game.MaxPlayers}");

