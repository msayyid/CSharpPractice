using System.Globalization;
using System.Runtime.CompilerServices;
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


/*
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

*/

/*

// Lesson 4 - IEnumerable<T>

// IEnumerable<T> means: "a sequence of T values that can be iterated over."

List<int> numbers = new () { 1, 2, 3, 4, 5, };
IEnumerable<int> sequence1 = numbers;

foreach (int number in sequence1)
{
    Console.WriteLine(number);
}

// List<int>
// -> collection with lots of operations

// IEnumerable<int>
// -> sequence of ints that I can iterate through
// this becomes useful because LINQ methods usually don't care whether the data came from:
// List<T>, array, HashSet<T>, database query, generated sequence
// they just care:
// can i enumerate over it?

// List<int> = a concrete collection type
// IEnumerable<int> = an interface saying:
// "I provide a sequence of ints you can iterate over"

// practice
List<string> names = new()
{
    "ali", "bek", "john"
};
IEnumerable<string> sequence = names;

foreach (string name in sequence)
{
    Console.WriteLine(name);
}
// sequence.Add("sarah"); // error
names.Add("sarah");

foreach (var VARIABLE in sequence)
{
    Console.WriteLine(VARIABLE);
}

// sarah still appears through sequence even though i added it through names
// because i think IEnumerable is just a reference type, meaning it does not
// contain a different list to names, it points to the same list, 
// meaning it is a reference 
// yes, sequence is just a reference to the list, but it can only iterate

*/


/*
// Lesson 5 - LINQ basics with Where()
// this is where lambdas + IEnumerable<T> start connecting

// List<int> evenNumbers = numbers.FindAll( number  => number % 2 == 0);

// LINQ gives us:
// IEnumerable<int> evenNumbes = numbers.Where(number => number % 2 == 0 );

// Where() is a LINQ method and works on anything that behaves like an IEnumerable<T>
// it works with List<T>, arrays, HashSet<T>, many other sequences

// Where() means: keep every item where this condition is true

// Where() 
// -> gives sequence

// ToList()
// -> turn that sequence into an actual List<T>

// List<int> result1 = new();
// foreach (var number in numbers)
// {
//     if (number > 5)
//     {
//         result1.Add(number);
//     }
// }

// with LINQ
// List<int> result = numbers
//     .Where(number => number > 5)
//     .ToList();

// objects work the same way


// Chaining 
// IEnumerable<int> result2 = number % 2 == 0);

// meaning: 
// first: keep numbers > 3
// then: from those, keep even numbers

// practice

string line = "-----------------------------------\n";
List<int> numbers = new()
{
    1, 2, 3, 4, 5, 6, 7, 8, 9, 10
};

IEnumerable<int> evenNumbers = numbers
    .Where(number => number % 2 == 0);
foreach (int number in evenNumbers)
{
    Console.WriteLine(number);
}
Console.WriteLine(line);

IEnumerable<int> greaterThanFives = numbers
    .Where(number => number > 5);
foreach (int number in greaterThanFives)
{
    Console.WriteLine(number);
}
Console.WriteLine(line);

IEnumerable<int> bothConditions = numbers
    .Where(number => number % 2 == 0)
    .Where(number => number > 5);
foreach (int number in bothConditions)
{
    Console.WriteLine(number);
}

Console.WriteLine(line);


List<string> names = new()
{
    "Ali",
    "Bek",
    "john",
    "Alexander",
    "Chingiz"
};
//
// IEnumerable<string> neededNames = names
//     .Where(name => name.Length > 3)
//     .ToList(); // this won't work, they do not match

// the flow is 
// names -> List<string> -> .Where() -> IEnumerable<string> -> .ToList() -> List<string>
// Where() return IEnumerable<T>, to make it a list you need to assign to a list and convert .ToList()
List<string> neededNames = names.Where(name => name.Length > 3).ToList();
neededNames.Add("Sarah");

// comparison
IEnumerable<string> a = names.Where(name => name.Length > 3);
// No ToList() needed because Where() already returns IEnumerable<string>

// but
List<string> b = names.Where(name => name.Length > 3).ToList();
// needs ToList() because Where() alone does not return a List<string>



foreach (string name in neededNames)
{
    Console.WriteLine(name);
}

Console.WriteLine(line);

// IEnumerable<T>
// -> sequence / query / iterate

// List<T>
// -> concrete collection you can modify and index

// ToList()
// -> execute/materialize the sequence into a list

*/



/*
// Lesson 6 - Select()

// Where()   -> choose which items stay
// Select()  -> change WHAT each item becomes

string line = "\n-----------------------------------";


List<int> numbers = new()
{
    1, 2, 3, 4, 5
};

IEnumerable<int> doubled = numbers
    .Select(number => number * 2);

foreach (int num in doubled)
{
    Console.WriteLine(num);
}
// Select() does not filter anything out

Console.WriteLine(line);
// strings to lengths
List<string> names = new()
{
    "ali", "john", "alexander"
};

IEnumerable<int> lengths = names
    .Select(name => name.Length);

foreach (var VARIABLE in lengths)
{
    Console.WriteLine(VARIABLE);
}
// select can even change the type

// objects to one property
// List<Developer> developers = ...
// we can do
// IEnumerable<string> names = developers.Select(developer => developer.Name)
// now instead of sequence of Developers we have sequence of string

// Where() + Select() 

Console.WriteLine(line);
IEnumerable<int> result = numbers
    .Where(number => number > 2)
    .Select(number => number * 10);
    
// flow: Where() keeps the numbers greater than 2, and Select() multiplies them by 10
foreach (var VARIABLE in result)
{
    Console.WriteLine(VARIABLE);
}

// practice

List<int> myNumbers = new()
{
    1, 2,3, 4, 5
};

// 1. doubled numbers
Console.WriteLine(line);
IEnumerable<int> doubledNumbers = myNumbers
    .Select(number => number * 2);
foreach (var VARIABLE in doubledNumbers)
{
    Console.WriteLine(VARIABLE);
}

// 2. squared numbers
Console.WriteLine(line);
IEnumerable<int> squaredNumbers = myNumbers
    .Select(number => number * number);

foreach (var VARIABLE in squaredNumbers)
{
    Console.WriteLine(VARIABLE);
}

// 3. sequence of name lengths
List<string> myNames = new()
{
    "Ali", "Bek", "John", "Alexander"
};
Console.WriteLine(line);
IEnumerable<int> nameLengths = myNames
    .Select(name => name.Length);

foreach (var VARIABLE in nameLengths)
{
    Console.WriteLine(VARIABLE);
}

// 4. upper case versions of all names
Console.WriteLine(line);
IEnumerable<string> uppercaseName = myNames
    .Select(name => name.ToUpper());
foreach (var VARIABLE in uppercaseName)
{
    Console.WriteLine(VARIABLE);
}

// 5. keep names longer than 3 chars
// 6. transform those remaining names to uppercase
Console.WriteLine(line);
List<string> combinedConditions = myNames
    // .Where(name => name.Length == 3) 
    .Where(name => name.Length > 3) 
    .Select(name => name.ToUpper())
    .ToList();
combinedConditions.Add("Barsbek"); // working

foreach (var VARIABLE in combinedConditions)
{
    Console.WriteLine(VARIABLE);
}
*/


// Lesson 7 - OrderBy(), ThenBy()

// these are for sorting

// OrderBy()  -> sort by the first rule
// ThenBy()   -> if some values are tied, sort those by a second rule

string line = "\n-----------------------------------";

// 1. OrderBy()
List<int> numbers = new()
{
    5, 2, 8, 1, 3
};

IEnumerable<int> sorted = numbers
    .OrderBy(number => number); // the lambda: sort using the number itself as the key
foreach (var VARIABLE in sorted)
{
    Console.WriteLine(VARIABLE);
}

// 2. OrderByDescending()
Console.WriteLine(line);
IEnumerable<int> sortedDescending = numbers
    .OrderByDescending(number => number);
    
foreach (var VARIABLE in sortedDescending)
{
    Console.WriteLine(VARIABLE);
}

// sorting strings 
Console.WriteLine(line);
List<string> names = new()
{
    "john", "ali", "alexander", "bek"
};
IEnumerable<string> alphabetical = names
    .OrderBy(name => name);
foreach (var VARIABLE in alphabetical)
{
    Console.WriteLine(VARIABLE);
}

Console.WriteLine(line);
IEnumerable<string> byLength = names
    .OrderBy(name => name);
foreach (var VARIABLE in byLength)
{
    Console.WriteLine(VARIABLE);
}


// ThenBy() 
// IEnumerable<Student> sorted = students
//     .OrderBy(student => student.Age)
//     .ThenBy(student => student.Name);

// OrderBy Age -> primary sorting rule
// ThenBy Name -> secondary sorting rule when Ages match

// do not use OrderBy().OrderBy
// do OrderBy().ThenBy().ThenBy()...


// practice

List<int> myNumbers = new()
{
    8, 2, 10, 4, 1, 6
};
// ascending order
Console.WriteLine(line);
IEnumerable<int> ascending = myNumbers
    .OrderBy(number => number);

foreach (var VARIABLE in ascending)
{
    Console.WriteLine(VARIABLE);
}

// descending order
Console.WriteLine(line);
IEnumerable<int> descending = myNumbers
    .OrderByDescending(number => number);

foreach (var VARIABLE in descending)
{
    Console.WriteLine(VARIABLE);
}

List<string> myNames = new()
{
    "john", "ali", "alexander", "bek", "sarah"
};

// alphabetical order
Console.WriteLine(line);
IEnumerable<string> alphabeticalOrder = myNames
    .OrderBy(name => name);
foreach (var VARIABLE in alphabeticalOrder)
{
    Console.WriteLine(VARIABLE);
}

// shortest to longest
Console.WriteLine(line);
IEnumerable<string> shortToLong = myNames
    .OrderBy(name => name.Length);
foreach (var VARIABLE in shortToLong)
{
    Console.WriteLine(VARIABLE);
}


// longest to shortest
Console.WriteLine(line);
IEnumerable<string> longToShort = myNames
    .OrderByDescending(name => name.Length);
foreach (var VARIABLE in longToShort)
{
    Console.WriteLine(VARIABLE);
}


Student st1 = new Student("Po", 19);
Student st2 = new Student("Bek", 16);
Student st3 = new Student("Jumong", 18);
List<Student> students = new();
students.Add(st1);
students.Add(st2);
students.Add(st3);
students.Add(new Student("Sarah", 18));
students.Add(new Student("Ali", 18));
students.Add(new Student("Ben", 18));


Console.WriteLine(line);
List<Student> seqStudents = students
    .OrderBy(student => student.Age)
    .ToList();
seqStudents.Add(new Student("Barsbek", 15));
foreach (var VARIABLE in seqStudents)
{
    Console.WriteLine(VARIABLE);
}

Console.WriteLine(line);
IEnumerable<Student> nameStudents = seqStudents
    .OrderBy(student => student.Age)
    .ThenBy(student => student.Name);

foreach (var VARIABLE in nameStudents)
{
    Console.WriteLine(VARIABLE);
}
