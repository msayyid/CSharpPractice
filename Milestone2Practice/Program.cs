// Milestone 2

// Inheritance

using Milestone2Practice;

Student student = new("Ali", 22, "Kyrgyzstan", "Roehampton");
Console.WriteLine(student.Name);
Console.WriteLine(student.Age);
Console.WriteLine(student.University);
Console.WriteLine(student.Introduce());

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
Console.WriteLine(student.GetInfo());

