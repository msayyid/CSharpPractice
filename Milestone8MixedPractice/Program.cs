// Mixed Practice - Inventory API

using Milestone8MixedPractice.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // means: register the ASP.NET functionality needed to use controller classes
builder.Services.AddSingleton<IInventoryService, InventoryService>(); // means: whenever something asks for an IInventoryService, provide an InventoryService
// because it is Singleton, ASP.NET keeps using teh same InventoryService
// instance across requests


var app = builder.Build();

app.MapControllers(); // means: find teh controller routes such as [Route], [HttpGet], etc. and actually connect them to HTTP requests.

app.MapGet("/", () => "Hello World!");



app.Run();


// The architecture should be:
//    HTTP
//     ↓
//  InventoryController
//     ↓
//  IInventoryService
//     ↓
//  InventoryService
//     ↓
//  List<InventoryItem>