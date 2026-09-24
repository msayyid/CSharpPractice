using System.Globalization;
using Milestone3Practice;

Console.WriteLine("Hello, World!");
// Milestone 3 practice

/*
// Lesson 1 - lambdas

// Lambda is a short function that you can write without giving it a normal method name
// bool IsEven(int number)
// {
//     return number % 2 == 0;
// }

// number => number % 2 == 0
// take a number and return whether it is even.

// List<int> numbers = new()
// {
//     1, 2, 3, 4, 5, 6
// };
// List<int> evenNumbers = numbers.FindAll(
//     number => number % 2 == 0
// );
// foreach (var num in evenNumbers)
// {
//     Console.WriteLine(num);
// }

// x         -> x * 2
// x         -> parameter
// =>        -> lambda operator
// x * 2     -> expression result

// input => what to do with input

// lambda = unnamed function/behavior that can be passed somewhere

List<int> numbers = new()
{
    1, 2, 3, 4, 5, 6, 7, 8, 9, 10
};

List<int> evenNumbers = numbers.FindAll(number => number % 2 == 0);

List<int> numbersGreaterThanFive = numbers.FindAll(number => number > 5);

foreach (var num in evenNumbers)
{
    Console.WriteLine(num);
}

foreach (int num in numbersGreaterThanFive)
{
    Console.WriteLine(num);
}

List<string> names = new()
{
    "Ali",
    "John",
    "Bek",
    "Alexander",
    "Chingizkhan"
};

List<string> newNames = names.FindAll(name => name.Length > 5);
foreach (string name in newNames)
{
    Console.WriteLine(name);
}
*/


// Lesson 2 - Delegates
// it is a type that can hold a reference to a method
// int Double(int number)
// {
//     return number * 2;
// }

// ex 
// public delegate int NumberOperation(int number);
// this says:
// NumberOperation can point to any method that
// - takes one int
// - returns one int

// NumberOperation operation = Double; // not working
// Console.WriteLine(operation(5));

// method -> delegate stores/references it -> delegate can call it later

// delegate = a type for storing and passing methods around

// practice 
// public delegate int NumberOperation(int number);

int Double(int number)
{
    return number * 2;
}

int Square(int number)
{
    return number * number;
}

NumberOperation operation1 = Double;
NumberOperation operation2 = Square;
NumberOperation operation3 = number => number * 3;

Console.WriteLine(operation1(3));
Console.WriteLine(operation2(5));
Console.WriteLine(operation3(6));


// NumberOperation operation1 = Double;
// means:
// store/reference the Double method inside this delegate variable 
// then operation1(2) calls whichever method operation1 currently points to

// notes
// delegate = a type that can reference a method
// Double     -> method itself
// Double(5)  -> calling the method

// NumberOperation op = Double;
// -> op now reference Double

// op(5);
// -> calls Double through the delegate



// Lesson 3 - Func, Action, and Predicate

// these are just built-in delegate types

// 1. Func
// use when the method takes input and RETURNS something
Func<int, int> doubleNumber = number => number * 2; // takes an int and returns an int
// int - input
// int - return

// <....> last type is the return type, before param types

// 2. Action
// use when the method returns nothing (void)

Action<string> printName = name => // take a string return nothing
{
    Console.WriteLine($"Hello {name}");
};
printName("ali");

// 3. Predicate.
// Predicate<T> is more specific
// it means:
// takes one T and returns bool

Predicate<int> isEven = number => number % 2 == 0;
Console.WriteLine(isEven(4));
Console.WriteLine(isEven(5));

// simple comparison
// Func
// -> returns a value

// Action
// -> returns void

// Predicate
// -> takes one value and returns bool

// examples
Func<int, int> doubleIt = 
    x => x * 2;

Action<string> print 
    = text => Console.WriteLine(text);

Predicate<int> isPositive = 
    x => x > 0;    
    
    
    
// Practice

Func<int, int> square = number => number * number;

Func<int, int, int> multiply = (x, y) => x * y;

Action<string> greet = name => Console.WriteLine($"Hello, {name}");

Predicate<int> isAdult = age => age >= 18;

Console.WriteLine(square(5));
Console.WriteLine(multiply(5, 6));
greet("Hasan");
Console.WriteLine(isAdult(7));

// Predicate <int> isEven = ...
// Func<int, bool> isEven2 = ...
// both represent the same condition, because predicate
// is just like a func but without explicitly saying it
// in this case func is doing the same job as predicate does
// meaning taking int and returning bool???
