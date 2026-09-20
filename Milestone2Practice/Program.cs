// Milestone 2

// Inheritance

using System.IO.Pipes;
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
Employee employee = new("Ali", 20, "UZB", "Bayraktar");

List <IWorker> workers = new()
{
    employee,
    new Robot("R2D2")
};

foreach (IWorker w in workers)
{
    w.Work();
}


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

