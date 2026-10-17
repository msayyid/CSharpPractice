// Milestone 6 - ASP.NET Core Basics

// Lesson 1 - create and run your first ASP.NET Core server

// prepare/configure the ASP.NET Core application
var builder = WebApplication.CreateBuilder(args);

// okay, take the configuration we prepared and build the actual web application
var app = builder.Build();

// if a client sends a GET request to /, respond with "Hello world"
app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", () => "hello from ASP.NET Core!");

// this starts the server and keeps it running, waiting for HTTP requests
app.Run();



// Console app: start -> run code -> finish
// ASP.NET server: start -> listen -> request -> response -> keep listening


