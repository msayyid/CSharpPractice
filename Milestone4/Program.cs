Console.WriteLine("Hello, World!");

// Milestone 4 - Practical .NET

// Lesson 1 - C# vs .NET vs ASP.NET Core


// C# is a programming language -> language
// .NET is the platform that runs C# applications and gives us a huge standard library -> platform/ecosystem
// ASP.NET Core is a framework built on top of .NET for building web applications and APIs.


// C#           = language
// .NET         = platform
// APS.NET Core = web framework


// Lesson 2 - Solution, Project, .csproj, namespaces, using, NuGet

// 1. Solution vs Project

// Solution = collection/container of projects
// Project = actual application/library

// question??
// when we say project, does it actually mean all the things one application will need?
// or is it like one solution is all the things application needed? 
// what i m trying to understand is that if project is like the whole application,
// why would we store differetn appcliaitons in one solutoin?
// like for example, one solution having 1 project to do app, 1 project step counter app
// wouldn't really be logical would it?
// ----- answered -----
// Solution is a container for related projects
// one application/system may contain multiple projects


// Project is one buildable unit
// could be an executable app, web API, class library, test project, etc.



// 2. What is .csproj?

// - think of it as:
// configuration/instructions for .NET about how this project should be built


// 3. What does dotnet run actually do

// when we run
// dotnet run
// .NET looks at the current project: .csproj
// figures out things like:
// which .NET version?
// which packages?
// what files belong to this project?
// how should it be built?
// then
// run application

// 4. Namespace

// A namespace is mainly a way of organizing types and avoiding name conflicts

// it is a logical address for classes/types
// question, i didn't really understand what the namespace is for
// i was thinking it was like a import command in pyhton, or using command in c++
// -- answered -------------------
// namespace = defines where a type logically belongs

// using = lets me refer to types in that namespace without writing the full namespace


// 5. Namespace is not the same thing as a folder



// 6. What does using mean

// - it basically says:
// i want to use types from this namespace without writing their full names every time

// namespace 
// =
// where a type logically belongs

// using
// =
// let me access that namespace conveniently


// 7. What is NuGet?

// NuGet is the main package manager for .NET

// NuGet -> download/install package -> .csproj -> your C# code can use that package

// Mental model for today:

// Solution
//     contains Projects
//
//     Project
// contains C# code + .csproj
//
//     .csproj
// tells .NET how the project is configured
//
// namespace
//     organizes classes/types
//
// using
//     lets you use a namespace conveniently
//
// NuGet
//     installs external packages/dependencies


// to remember ---------------------------

// Solution
//     contains related Projects
//
// Project
// has .csproj
//
// Classes/types
// belong to namespaces
//
// using
//     lets you refer to those namespaces conveniently
//
//     NuGet
// adds external packages to the project



