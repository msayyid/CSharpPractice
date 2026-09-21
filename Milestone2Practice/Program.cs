// Milestone 2

// Inheritance

using System.IO.Pipes;
using System.Runtime.InteropServices;
using Milestone2Practice;

// Student student = new("Ali", 22, "Kyrgyzstan", "Roehampton");
// Console.WriteLine(student.Name);
// Console.WriteLine(student.Age);
// Console.WriteLine(student.University);
// Console.WriteLine(student.Introduce());

// Lesson 2 - protected and base
// : base() means:
// call the constructor of the parent class

// 1 - protected
// public - accessible from anywhere
// private - accessible only inside the class
// protected - accessible inside this class AND 
// inside classes that inherit from it

// protected = private to the inheritance family

// 2 - base
// this.Name - this current object
// base.Name - the parent-class part of this current object

// Console.WriteLine(student.Nationality); // protected, error
// Console.WriteLine(student.GetInfo());


// Lesson 3 - virtual and override

// virtual + override are there so that child class could replace the parent's version
// virtual - child classes are allowed to provide their own version of this method
// in the parent - virtual 
// in the child - override

// Person person = new("John", 40, "UK");
// Student student = new("Ali", 22, "Kyrgyzstan", "Roehampton");

// Console.WriteLine(person.Introduce());
// Console.WriteLine(student.Introduce());
// Console.WriteLine(student.University); // can access as it is accessed through the Student class


// Lesson 4 - polymorphism

// Person reference -> Student object -> virtual method call -> student override runs
// this is polymorphism
// Person person1 = new Student(...)
// Person person2 = new Employee(...)
// Person person3 = new Teacher(...)

// Person person1 = new Person("Ali", 22, "UZB");
// Person person2 = new Student("Alibek", 23, "KGZ", "MSU");
// Console.WriteLine(person1.Introduce());
// Console.WriteLine(person2.Introduce());
// Console.WriteLine(person2.University); // no access, as it is referenced through the Person class, and Person class does not have University

// ----- DEFINTION -----
// Polymorphism means one parent type can refer to different child objects,
// and each child can behave in its own way

// List<Person> people = new()
// {
//     person1,
//     person2,
//     new Employee("Bek", 25, "KAZ", "Bayraktar")
// };
// foreach (Person p in people)
// {
//     Console.WriteLine(p.Introduce());
// }


// note:
// if behavior is common to all Persons
// -> put it in the Person and override it

// if data/behavior only makes sense for Student
// -> keep it in Student.


// Lesson 5 - abstract classes

// abstract:
// this class is meant to be inherited from, not instantiated directly
// it also can say every child MUST provide its own version of this method

// virtual <-> abstract
// virtual means:
// here's a default implementation; child classes may override it
// abstract means:
// no default implementation; child classes must override it

// rule:
// if a class contains an abstract method,
// the class itself must also be abstract

// Person student = new Person("Ali", 22, "UZB"); // error, abstract class

// Person student = new Student("Ali", 20, "KGZ", "MIT");
// Person employee = new Employee("Bek", 23,"MNG", "Bayraktar");
// Console.WriteLine(student.Introduce());
// Console.WriteLine(employee.Introduce());

// why abstract:
// the parent represents a general concept, but creating that general thing 
// by itself would not make sense, and you want to force every child
// to provide certain behavior

// ----- DEFINITION -----
// An abstract class is a parent blueprint that can share data/logic
// but cannot be created directly, and can force child classes
// to implement certain behavior



// Lesson 6 - interfaces

// An interface is a contract that says what a class must be able to do
// it usually focuses on behavior, not shared state 

// Employee : Person, IWork
// means:
// Employee inherits form Person
// and 
// Employee implements IWorker
//
// Person gives it a shared state/implementation
// IWorker says: you promise to have the behavior described by this contract

// Differences:
// abstract class:
// -> "What you are"
// -> can share fields, properties, constructors, method implementation
// Student IS a Person, Employee IS a Person

// interface:
// -> "what you can do"
// -> defines a contract/capability
// Employee CAN Work
// Robot CAN Work

// Rule
// a C# class can inherit only one class, but it can implement multiple interfacees

// Employee employee = new("Ali", 20, "UZB", "Bayraktar");
// employee.Work();
// Console.WriteLine(employee.Introduce()); // accessible as referenced through Employee class
//
//
// IWorker worker = new Employee("Bek", 21, "KGZ", "Baykar");
// // this lets us create because Employee promises that it implements the IWorker contract
// // so an Employee can be referenced as an IWorker
//
// worker.Work();
// worker.Introduce(); // inaccessible as referenced through IWorker interface

// interface - unrelated classes
// Employee employee = new("Ali", 20, "UZB", "Bayraktar");
//
// List <IWorker> workers = new()
// {
//     employee,
//     new Robot("R2D2")
// };
//
// foreach (IWorker w in workers)
// {
//     w.Work();
// }


// Lesson 7 - Abstract class vs Interface

// Abstract class
// use an abstract class when classes are part of the same
// family and should share common state or implementation

// Interface
// use an interface when you care about a capability/contract,
// even across unrelated classes

// Abstract class = what something is
// Interface      = waht something can do

// Abstract class
// - can have fields
//     - can have properties
//     - can have constructors
//     - can have normal implemented methods
//     - can have abstract methods
//     - a class can inherit from only one class
//
//     Interface
// - mainly defines a contract
//     - no normal instance constructor
//     - classes can implement multiple interfaces
//     - unrelated classes can share the same interface


// Lesson 8 - records

// are mainly for data-focused types

// class
// -> are these the same object?
// record
// -> do these contain the same values?

// StudentRecord s1 = new("Ali", 22, "Roehampton");
// StudentRecord s2 = new("Ali", 22, "Roehampton");
// Console.WriteLine(s1 == s2); // true
//
// StudentRecord s3 = s1 with
// {
//     Age = 23
// };
//
// List<StudentRecord> students = new()
// {
//     s1,
//     s2,
//     s3
// };
// foreach (var s in students)
// {
//     Console.WriteLine(s);
// }


// Lesson 9 - structs
// A struct is a value type, while a class is a reference type

// class vs struct
// class
// -> reference semantics
// assignment usually copies the reference
// two variables can refer to the same object

// struct
// value semantics
// assignment copies the value
// each variable has its own copy

// struct = value type
// class = reference type

// Coordinate c1 = new(10, 20);
// Coordinate c2 = c1;
// Console.WriteLine(c1.GetInfo());
// Console.WriteLine(c2.GetInfo());
// // c2.X = 123; // error
// // Console.WriteLine(c2.X); 
//
// Counter ct1 = new();
// ct1.Value = 10;
//
//
// Counter ct2 = ct1;
// ct2.Value = 11;
//
// Console.WriteLine(ct1.Value);
// Console.WriteLine(ct2.Value);


// IMPORTANT, RULE, NOTE

// most business objects -> class
// mostly immutable/data-focused model where value equality is useful -> consider record
// small genuine value type -> maybe struct
// shared capability/contract -> interface



// Lesson 10 - deeper nullability

// 
// 1. string vs string?
// string name = "ALI";
// name is intended to always contain a string
// string? name = null;

// 2. ? is mostly compiler protection for reference types
// name is allowed to contain either a string or null

// C# compiler tracks whether something might be null and warns you

// 3. ! - null-forgiving operator
// string name = Console.ReadLine()!;
// "!" means: compiler, trust me. i know this isn't null
// but "!" does not prevent null, it only suppresses the compiler warning

// ex
// string? name = null;
// Console.WriteLine(name!.Length);
// no warning because of !, but at runtime: error exception

// so
// ? = this may be null
// ! = i am telling the compiler i believe this isn't null
// ! is not "remove null"


// 4. ? - null-conditional operator
// Student? student = null;
// Console.WriteLine(student.Name); // this could crash
// // but
// Console.WriteLine(student?.Name);
// ?. means:
// if student isn't null, access Name; otherwise return null

// ex:
// string? name = null;
// int? length = name?.Length;
// if name is null, there is no length, so the result is null


// 5. ?? - null-coalescing operator
// string? name = null;
// string result = name ?? "Unknown";
// means:
// use name if it has a value; otherwise use "Unknown";

// string displayName = Console.ReadLine() ?? "Guest";
// Console.WriteLine(displayName); // this one didn't really work


// 6. ?. and ?? together
// Student? student = null;
// string university = student?.University ?? "No university";
// student?.University
// -> if student exists, get University
// otherwise null

// ?? "No university"
// -> if result was null, use "No university"


// 7. ??= -- assign only if null
// string? name = null;
// name ??= "Unknown";
// means:
// if name is null, assign "Unknown" to it

// ?? -> give me a fallback VALUE
// ??= assign a fallback if currently null

// 8. Nullable value types

// int age = null; // not good
// int? age = null; // good

// int is a value type
// int? is integer OR null

/*
// CHEAT SHEET NULLABLES 
string 
-> should not be null

string!
-> may be null

!
-> suppress compiler null warning
-> does not prevent runtime null

?.
-> access something only if object isn't null

??
-> use fallback if value is null

??=
-> assign fallback if currently null

int?
-> nullable value type: int OR null
*/


// Student? student = null;
// // string university = student?.University ?? "Unknown university";
// // Console.WriteLine(university); // "Unknown university"
//
// student = new Student("Ali", 22, "MNG", "MIT");
// string university = student.University ?? "Unknown university";
//
// Console.WriteLine(university);
//
// int? score = null;
// Console.WriteLine(score ?? 0);
//
//
// score ??= 100;
// // why did it assign 100 to score?, we are doing score ?? 0 why would it assign 100 because score is no longer null??
// // i was expecting 0 0 in the output
// Console.WriteLine(score);

// ? = means might be null
// ! = means trust me won't be null (does not actually remove null)
// ?. = means if the object exists, access the member; otherwise produce null
// ?? = if the value is null, USE this other value instead
// ??= = if the variable is null, ASSIGN this other value to it

// ?? 
// int? score = null;
// Console.WriteLine(score ?? 0):
// if score is null, use 0 for this expression
// but score itself is still null, nothing is assigned

// ??= means 
// if score is currently null, assign 100 to it

// ex:
Student? student = null;
string? university1 = student?.University;
// student is null => university1 becomes null

string university2 = student?.University ?? "Unknown";
// student is null -> university2 becomes "Unknown"
// student itself is NOT changed

student ??= new Student("Ali", 22, "MNG", "MIT");
// student was null -> now a Student object is assigned to it

