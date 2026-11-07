using Milestone8Practice.Services;

var builder = WebApplication.CreateBuilder(args);

// enable controllers
builder.Services.AddControllers(); 

// 
// builder.Services.AddSingleton<BugService>();
// ASP.NET, please know how to create and provide a BugService.
// this is what it means for now

builder.Services.AddSingleton<IBugService, BugService>();
// whenever somebody asks for an IBugService, give them a BugService


var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

// Milestone 8 - Dependency Injection + Services

// we introduce another layer
// Services

// Lesson 1 - What is a service??
// a service is usually a class that contains the application's
// actual/business logic

// Conceptually:
// Controller: "Someone requested bug 3."

// Services:
// "I'll find bug 3."

// Controller:
// "Okay, i'll return 200 or 404"


// Controller - HTTP stuff
// Service - Application/business logic


// Controller = handles HTTP
// Service = does the work

// ------
// Service
// = a class that contains application/business logic.

// Controller
// = handles HTTP requests and responses.

// Instead of putting all logic in the controller:
//
// Controller -> does everything
//
// we move toward:
//
// HTTP -> Controller -> Service -> Data
//
// Controller handles HTTP.
// Service does the actual work.
// ------


// Lesson 2 - First Service Class (without dependency injection yet)

// Who handles what now?
// HTTP request
//     ↓
// BugsController
//     ↓
// _bugService.GetById(2)
//     ↓
// BugService searches the list
//     ↓
// returns BugTicket
//     ↓
// Controller returns 200 OK


// _____

// Service
// = class that contains application/business logic.

// Controller
// = handles HTTP requests and responses.

// Controller asks WHAT it needs.
// Service handles HOW to do it.

// Example:
// Controller -> _bugService.GetById(id)
// Service -> searches for the bug

// Service should not normally return HTTP things like:
// Ok(), NotFound(), BadRequest().
//
// It returns normal C# data/null.
// The controller decides which HTTP response to return.

// For now:
// private readonly BugService _bugService = new();
//
// means the controller creates its own service.
// This is NOT Dependency Injection yet.
// _____



// Lesson 3 - Dependency Injection

// A class receives the dependency it needs instead of creating it itself
// that is the main idea of dependency injection


// mental model
// Dependency = something a class needs

// BugsController needs BugService -> BugService is a dependency

// Dependency Injection = give the dependency to the class
// and instead of the class creating it itself

// and
// Program.cs
// -> registers BugService

// ASP.NET
// -> creates BugService

// _bugService
// -> store it for use

// ____________________
// Dependency = something a class needs.
// BugsController needs BugService.

// Dependency Injection = the class receives the dependency
// instead of creating it with new.

// Program.cs:
// builder.Services.AddSingleton<BugService>();

// Controller constructor:
// public BugsController(BugService bugService)
// {
//     _bugService = bugService;
// }

// ASP.NET creates/provides BugService for us.

// ____________________


// Lesson 4 - Service Lifetimes
// asp.net can create services in different ways:
// singleton, scoped, transient

// simple mental model
// singleton
// -> one shared service object for the whole application

// scoped
// -> one service object for per HTTP request

// transient
// -> new service object every time it is requested


// builder.Services.AddSingleton<BugService>();
// means:
// create one BugService, and keep reusing that same object,
// this matters because the service we currently have contains:
// private readonly List<BugTicket> _bugs = ...
// if we kept creating brand-new BugService objects constantly, each
// one would start with a fresh list again

// with singleton:
// application starts -> BugService created once -> request1 uses it, request2 uses same one and on and on

//
// Scoped
// we can also register:
// builder.Services.AddScoped<BugService>();
//
// Meaning:
// HTTP request 1
//     → BugService A
//
// HTTP request 2
//     → BugService B
//
// HTTP request 3
//     → BugService C
//
// Inside one request, ASP.NET reuses the same scoped object.
//
// This is extremely common in real ASP.NET applications,
// especially once we use Entity Framework Core / database contexts.

//
//

// Transient
// builder.Services.AddTransient<BugService>();
//
// means:
// Give me a brand-new BugService every time one is requested.
//
// So conceptually:
// need BugService
//     → new one
//
// need BugService again
//     → another new one
//
//
// revision rule
// singleton = 
//              one shared instance for the whole application
// scoped = 
//          one instance per HTTP request
// transient =
            // new instance every time the service is requested

// for our current in-memory BugService, Singleton makes sense
// because we want the same list to survive across requests


// Lesson 5 - Move CRUD logic into the service


// Controller handles HTTP.
// Service handles data/business operations.

// Service returns normal C# values:
// BugTicket, null, bool, etc.

// Controller converts those results into:
// 200, 201, 404, 204, etc.



// Lesson 6 - INterfaces with services

// Architecture now
// Before:
// BugsController -> BugService

// Now:
// BugsController -> IBugService -> BugService

// Controller depends on interface
// DI decides which implementation gets supplied


// Revision Notes:
// IBugService
// = contract describing what a bug service must be able to do

// BugService : IBugService
// = BugService implements that contract

// Controller depends on IBugService,
// not directly on BugService

// DI registration:
//
// AddSingleton<IBugService, BugService>();
//
// means: 
// when something asks for IBugService,
// ASP.NET should provide BugService

// This lets us replace the implementation later
// without changing the controller

app.Run();