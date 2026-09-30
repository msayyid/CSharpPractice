using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks.Dataflow;
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


/*

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
*/



/*
// Lesson 8 - First() and FirstOrDefault()
// these are for getting a single item from a sequence

// First()

string line = "\n-----------------------------------";


List<int> numbers = new()
{
    5, 2, 8, 11, 3, 10
};

int first = numbers.First();
Console.WriteLine(first);
// returns the first item
// we can also give it a condition
Console.WriteLine(line);

int firstOverTen = numbers
    .First(number => number > 10);
Console.WriteLine(firstOverTen);

// if not found First() does not return null
// it throws an exception

// so match exists -> return it
// no match -> exception

// FirstOrDefault()
// this is usually safer when something might not exist
Console.WriteLine(line);
int result = numbers
    .FirstOrDefault(number => number > 100);
Console.WriteLine(result);
// no match -> returns a default value: 0

// default values:
// int - 0
// string - null
// bool - false
// class - null

// First() vs FirstOrDefault()

// First()
// -> "I expect this item to exist."
// if not, crash/exception

// FirstOrDefault()
// -> "it might not exist"
// -> give default value instead

// Practice

List<int> myNumbers = new()
{
    5, 10, 15, 20
};
// first()
Console.WriteLine(line);
int first1 = myNumbers
    .First();
Console.WriteLine(first1);

// first number > 10
Console.WriteLine(line);
int first10 = myNumbers
    .First(number => number > 10);
Console.WriteLine(first10);

// for numbers greater than 100
Console.WriteLine(line);
int greaterThanHundred = myNumbers
    .FirstOrDefault(number => number > 100);
Console.WriteLine(greaterThanHundred); // 0


List<string> names = new()
{
    "ali", "bek", "alexander", "john"
};
// first name langer than 3 chars
Console.WriteLine(line);
string firstName = names
    .First(name => name.Length > 3);
Console.WriteLine(firstName);

// first name longer than 20 chars with default value
Console.WriteLine(line);
string? noName = names
    .FirstOrDefault(name => name.Length > 20);
Console.WriteLine(noName);

// Students
List<Student> students = new()
{
    new Student("barsbek", 14),
    new Student("chingiz", 17),
    new Student("yildirim", 13)
};

Student? student = students
    .FirstOrDefault(student => student.Name == "chingiz");
// give me the first student where the student's name is "chingiz"
Console.WriteLine(student);

// rule
// FirstOrDefault with classes/reference types 
// -> very convenient because "not found" = null

// with int/bool/etc.
// -> completely valid
// -> just remember the default value may also be a real value
*/



/*
// Lesson 9 - Any() and All()
// these both return a bool.

// Any()
// - is there AT LEAST ONE matching item?

// All() 
// - do ALL items match 

string line = "\n-----------------------------------";


List<int> numbers = new()
{
    1, 2, 3, 4, 5
};

bool hasEvenNumber = numbers
    .Any(number => number % 2 == 0);
Console.WriteLine(hasEvenNumber);

// Any() with no condition
Console.WriteLine(line);
bool hasItems = numbers.Any();
Console.WriteLine(hasItems);
// is this sequence not empty


Console.WriteLine(line);
bool allPositive = numbers
    .All(number => number > 0);
Console.WriteLine(allPositive);
// true because every number passes the condition


// FirstOrDefault()
// -> give me the matching item
// Any()
// -> just tell me whether a matching item exists

// Any() - one or more must pass
// All() - everyone must pass

// Practice

List<int> myNumbers = new()
{
    2, 4, 6, 8, 10
};

// > 5
Console.WriteLine(line);
bool isGreater = myNumbers
    .Any(number => number > 5);
Console.WriteLine(isGreater); // true

// odd numbers ?
Console.WriteLine(line);
bool hasOddNumbers = myNumbers
    .Any(number => number % 2 == 1);
Console.WriteLine(hasOddNumbers); // false

// are all even
Console.WriteLine(line);
bool allEven = myNumbers
    .All(number => number % 2 == 0);
Console.WriteLine(allEven); // true

// all > 0?
Console.WriteLine(line);
bool allGreaterThanZero = myNumbers
    .All(number => number > 0);
Console.WriteLine(allGreaterThanZero); // true

List<Student> students = new()
{
    new Student("Ali", 17),
    new Student("Bek", 20),
    new Student("Sara", 22)
};

// anyone 18+ 
Console.WriteLine(line);
bool hasAdults = students
    .Any(student => student.Age >= 18);
Console.WriteLine(hasAdults); // true

// all 18+ 
Console.WriteLine(line);
bool allAdults = students
    .All(student => student.Age >= 18);
Console.WriteLine(allAdults); // false

// bek?
Console.WriteLine(line);
bool isBekThere = students
    .Any(student => student.Name == "Bek");
Console.WriteLine(isBekThere); // true

*/


/*
// Lesson 10 - Count(), Sum(), Min(), Max()

// these are for getting one final value from a sequence

// Count()

string line = "\n-----------------------------------";

List<int> numbers = new()
{
    1, 2, 3, 4, 5
};

// LINQ lets us count only matching items
int evenCount = numbers
    .Count(number => number % 2 == 0);
Console.WriteLine(evenCount);

// Count() - how many items
// Count(condition) - how many items match

// for a List<T> we have the property number.Count without parentheses
// numbers.Count() is the LINQ method when you want a condition

// Sum() 
Console.WriteLine(line);
int total = numbers.Sum();
Console.WriteLine(total);


// with objects, you can tell it what property to add
List<Student> students = new()
{
    new Student("Ali", 17),
    new Student("bek", 20),
    new Student("Sarah", 22)
};

int totalAge = students
    .Sum(student => student.Age);
Console.WriteLine(totalAge); // students' total age

// Min()
Console.WriteLine(line);
int smallest = numbers
    .Min();
Console.WriteLine(smallest);

// for objects
Console.WriteLine(line);
int youngest = students
    .Min(student => student.Age);
Console.WriteLine(youngest);

// Max() same idea
Console.WriteLine(line);
int oldestAge = students
    .Max(student => student.Age);
Console.WriteLine(oldestAge);

// Min() Max() return the age value, not the actual Student

// Combining with Where()
Console.WriteLine(line);
int total1 = numbers
    .Where(number => number > 2)
    .Sum();
Console.WriteLine(total1);


// Practice

List<int> myNumbers = new()
{
    3, 7, 2, 10, 5, 8
};

// total number of items
Console.WriteLine(line);
int totalItems = myNumbers
    .Count();
Console.WriteLine(totalItems);

// count of even numbers
Console.WriteLine(line);
int evenNumbersCount = myNumbers
    .Count(number => number % 2 == 0);
Console.WriteLine(evenNumbersCount);

// sum of all 
Console.WriteLine(line);
int totalSum = myNumbers
    .Sum();
Console.WriteLine(totalSum);

// max number
Console.WriteLine(line);
int maxNumber = myNumbers.Max();
Console.WriteLine(maxNumber);

// min number 
Console.WriteLine(line);
int minNumber = myNumbers.Min();
Console.WriteLine(minNumber);

// sum of numbers grater than 5
Console.WriteLine(line);
int neededSum = myNumbers
    .Where(number => number > 5)
    .Sum();
Console.WriteLine(neededSum);

List<Student> students1 = new()
{
    new Student("Ali", 17),
    new Student("Bek", 20),
    new Student("Sara", 22),
    new Student("John", 20)
};

// number of adults
Console.WriteLine(line);
int numAdults = students1
    .Count(student => student.Age >= 18);
Console.WriteLine(numAdults);

// sum of all ages
Console.WriteLine(line);
int sumAllAges = students1
    .Sum(st => st.Age);
Console.WriteLine(sumAllAges);

// youngest age
Console.WriteLine(line);
int youngestAge = students1.Min(st => st.Age);
Console.WriteLine(youngestAge);

// oldest one
Console.WriteLine(line);
int oldestStudent = students1.Max(st => st.Age);
Console.WriteLine(oldestStudent);
*/




/*
// Lesson 11 - GroupBy()

// GroupBy() puts items into groups based on a key
string line = "\n-----------------------------------";


List<Student> students = new ()
{
    new Student("Ali", 20),
    new Student("Bek", 18),
    new Student("Sara", 20),
    new Student("John", 18),
    new Student("Anna", 22)
};

var groups = students
    .GroupBy(student => student.Age);
// student.Age becomes group key

// Console.WriteLine(groups);
foreach (var group in groups)
{
    Console.WriteLine($"Age: {group.Key}");
    foreach (Student student in group)
    {
        Console.WriteLine(student.Name);
    }
}

// the outer loop goes through the groups
// the inner loop goes through the students inside each group

// ex
List<string> names = new()
{
    "Ali",
    "Bek",
    "John",
    "Sara",
    "Alexander"
};
var groupedNames = names 
    .GroupBy(name => name.Length);

Console.WriteLine(line);
foreach (var group in groupedNames)
{
    Console.WriteLine($"Group by length - {group.Key}");
    foreach (string name in group)
    {
        Console.WriteLine(name);
    }
}

// GroupBy() can organize backend/business data for us (instead of creating lots of dictionaries and lists)

// type:
// Key 
// + 
// IEnumerable<T> of matching items

// practice

List<Student> students2 = new ()
{
    new Student("Ali", 20),
    new Student("Bek", 18),
    new Student("Sara", 20),
    new Student("John", 18),
    new Student("Anna", 22)
};

// group by age, print
Console.WriteLine(line);
var studentsByAge = students2
    .GroupBy(student => student.Age);

foreach (var group in studentsByAge)
{
    Console.WriteLine($"Ages - {group.Key}");
    Console.WriteLine("----------");
    foreach (Student student in group)
    {
        Console.WriteLine(student.Name);
    }

    Console.WriteLine("----------");
}


List<string> names2 = new()
{
    "Ali",
    "Bek",
    "John",
    "Sara",
    "Alexander",
    "Chingiz"
};

// by length
Console.WriteLine(line);

var grByLength = names2
    .GroupBy(name => name.Length);
foreach (var group in grByLength)
{
    Console.WriteLine($"Length: {group.Key}");
    Console.WriteLine("--------");
    foreach (string name in group)
    {
        Console.WriteLine(name);
    }

    Console.WriteLine("########");
}

*/



/*

// Lesson 12 - combining LINQ operations 

// LINQ chains run in the order you write them
string line = "\n-----------------------------------";


List<Student> students = new()
{
    new Student("Ali", 17),
    new Student("Bek", 20),
    new Student("Sarah", 22),
    new Student("John", 20),
    new Student("Alexander", 25)
};

// we want adult students only -> youngest first -> just their names

IEnumerable<string> result = students
    .Where(student => student.Age >= 18)
    .OrderBy(student => student.Age)
    .Select(student => student.Name);


foreach (var student in result)
{
    Console.WriteLine(student);
}

// useful mental model / a cheatsheet
// Where
// -> filters
// OrderBy
// -> sorts
// Select
// -> transforms
// toList
// -> materializes into a list

// always ask
// what type is each item at this stage?


List<Student> newStudents = new()
{
    new Student("Ali", 17),
    new Student("Yaseer", 21),
    new Student("Bek", 20),
    new Student("Sarah", 22),
    new Student("John", 20),
    new Student("Alexander", 25),
    new Student("Anna", 19),
    new Student("Ahmad", 25)
};

// 1. adults only, sorted by age ascending 
Console.WriteLine(line);
IEnumerable<Student> adultsOnly = newStudents
    .Where(student => student.Age >= 18)
    .OrderBy(student => student.Age);
foreach (var VARIABLE in adultsOnly)
{
    Console.WriteLine(VARIABLE.Name + " - " + VARIABLE.Age);
}

// 2. adults only, sorted by age, then by name
Console.WriteLine(line);
IEnumerable<Student> adultsOnly2 = newStudents
    .Where(student => student.Age >= 18)
    .OrderBy(student => student.Age)
    .ThenBy(student => student.Name);

foreach (var VARIABLE in adultsOnly2)
{
    Console.WriteLine(VARIABLE.Name + " - " + VARIABLE.Age);
}

// 3. Students older than 18, then select only their names
Console.WriteLine(line);
IEnumerable<string> onlyNames = newStudents
    .Where(student => student.Age > 18)
    .Select(student => student.Name);

foreach (var VARIABLE in onlyNames)
{
    Console.WriteLine(VARIABLE);
}

// 4. Students whose name length is greater than 3,
// sort alphabetically, then return only names

Console.WriteLine(line);
IEnumerable<string> onlyNamesLengthIsThree = newStudents
    .Where(student => student.Name.Length > 3)
    .OrderBy(student => student.Name)
    .Select(student => student.Name);

foreach (string name in onlyNamesLengthIsThree)
{
    Console.WriteLine(name);
}
// i think i messed up this one, forgot i think or is it correct?


// 5. count how many students are age 20 or older
Console.WriteLine(line);
int studentsTwentyPlus = newStudents
    .Count(student => student.Age >= 20);
Console.WriteLine("The number of students who are 20 or older is:");
Console.WriteLine(studentsTwentyPlus);

// 6. Get the oldest age
Console.WriteLine(line);
int oldestAge = newStudents.Max(student => student.Age);
Console.WriteLine("The oldest student's age is:");
Console.WriteLine(oldestAge);

// 7. Check whether there's any student younger than 18
Console.WriteLine(line);
bool hasStudetnMinor = newStudents
    .Any(student => student.Age < 18);
Console.WriteLine("Is there any student younger than 18?");
Console.WriteLine(hasStudetnMinor);

// 8. Create a List<string> of names for students age 20+, sorted alphabetically

Console.WriteLine(line);
Console.WriteLine(line);
List<string> studentsAgedTwentyPlus = newStudents
    .Where(student => student.Age >= 20)
    .OrderBy(student => student.Name)
    .Select(student => student.Name)
    .ToList();
foreach (string VARIABLE in studentsAgedTwentyPlus)
{
    Console.WriteLine(VARIABLE);
}

*/


// Mixed LINQ practice

string line = "\n-----------------------------------";


List<Student> students = new ()
{
    new Student("Ali", 19, "CS"),
    new ("Bek", 22, "Math"),
    new Student("Sara", 21, "CS"),
    new Student("John", 18, "Physics"),
    new Student("Anna", 23, "Math"),
    new Student("Alexander", 25, "CS"),
    new Student("Mary", 20, "Physics")
};

// 1. get all students ages 20+
Console.WriteLine(line);
IEnumerable<Student> studentsAged20Plus = students
    .Where(student => student.Age >= 20);

foreach (Student student in studentsAged20Plus)
{
    Console.WriteLine(student);
}

// 2. from those, select only their names
Console.WriteLine(line);
IEnumerable<string> studentsAged20PlusNames = students
    .Where(student => student.Age >= 20)
    .Select(student => student.Name);

foreach (string student in studentsAged20PlusNames)
{
    Console.WriteLine(student);
}

// 3. sort those names alphabetically
Console.WriteLine(line);
IEnumerable<string> sortedNamesAlphabetically = studentsAged20PlusNames
    .OrderBy(name => name);
foreach (var VARIABLE in sortedNamesAlphabetically)
{
    Console.WriteLine(VARIABLE);
}

// 4. turn the result into a List<string>
Console.WriteLine(line);
List<string> turnTotListNames = sortedNamesAlphabetically
    .ToList();
// Console.WriteLine(turnTotListNames); // list type
foreach (var VARIABLE in turnTotListNames)
{
    Console.WriteLine(VARIABLE);
}

// 5. find the first student studying CS
Console.WriteLine(line);
Student studentFirstCs = students
    .First(student => student.Course == "CS");
Console.WriteLine(studentFirstCs);

// 6. find the first student aged over 30 using FirsOrDefault()
Console.WriteLine(line);
Student? studentOver30 = students
    .FirstOrDefault(student => student.Age > 30);
Console.WriteLine(studentOver30); // null


// 7. check whether any student is under 18
Console.WriteLine(line);
bool hasAnyMinor = students
    .Any(student => student.Age < 18);
Console.WriteLine(hasAnyMinor); // false

// 8. check whether all students are at least 18
Console.WriteLine(line);
bool allAdults = students
    .All(student => student.Age >= 18);
Console.WriteLine(allAdults); // true

// 9. count how many students study "CS"
Console.WriteLine(line);
int studentsOnCs = students
    .Count(student => student.Course == "CS");
Console.WriteLine(studentsOnCs); // 3

// 10. find the oldest age
Console.WriteLine(line);
int oldestAge = students 
    .Max(student => student.Age);
Console.WriteLine(oldestAge); // 25


// 11. find the total of all ages
Console.WriteLine(line);
int totalAge = students
    .Sum(student => student.Age);
Console.WriteLine(totalAge); // 148

// 12. Group students by Course
Console.WriteLine(line);
var groupByCourse = students
    .GroupBy(student => student.Course);

foreach (var group in groupByCourse)
{
    Console.WriteLine(group.Key);
    Console.WriteLine("---         ---");
    foreach (var student in group)
    {
        // Console.WriteLine(student.Name + " - " + student.Age + " - " + student.Course);
        Console.WriteLine("- " + student.Name);
        
    }

    Console.WriteLine("+++++++++++++");
}


// 1, 2, 3, 4 in one query
Console.WriteLine(line);
Console.WriteLine(line);
List<string> studentsAll20 = students
    .Where(student => student.Age >= 20)
    .Select(student => student.Name)
    .OrderBy(student => student)
    .ToList();

Console.WriteLine(studentsAll20); // list type
foreach (var VARIABLE in studentsAll20)
{
    Console.WriteLine(VARIABLE);
}
    
    
// last one
Console.WriteLine(line);
List<string> specialOnes = students 
    .Where(student => student.Course == "CS")
    .Where(student => student.Age >= 20)
    .OrderBy(student => student.Age)
    .ThenBy(student => student.Name)
    .Select(student => student.Name)
    .ToList();

Console.WriteLine(specialOnes); // list type
foreach (var name in specialOnes)
{
    Console.WriteLine(name);
}