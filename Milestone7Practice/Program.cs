var builder = WebApplication.CreateBuilder(args);

// this means:
// ASP.NET, i want to use controllers in this application
builder.Services.AddControllers(); // enable/register controller functionality

var app = builder.Build();


// this means:
// look at my controller classes and create HTTP routes from them
app.MapControllers(); // connect controller endpoints to HTTP routing


app.MapGet("/", () => "Hello World!");


// Milestone 7 starts here
// Lesson 1 - controllers
// most worked in TasksController.cs


// Lesson 2 - Router Parameters + Returning Real Objects
// mostly worked in TasksController.cs and created TaskItem.cs for temporary testing data


// Lesson 3 - POST in controllers + [FromBody] + CreatedAtAction
// this is where controllers start to feel more "framework-y" than Minimal APIs.

// [FromBody] means: get this parameter from the JSON request body.
// With [ApiController], ASP.NET usually figures this out automatically.
// So [FromBody] is often optional for complex objects like TaskItem.


// Lesson 4 - PUT and DELETE in Controllers



// Milestone 7 mixed practice



app.Run();