var builder = WebApplication.CreateBuilder(args);

// bring the controller support
builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");


// Milestone 7 Project 
// Bug Tracker API

app.Run();