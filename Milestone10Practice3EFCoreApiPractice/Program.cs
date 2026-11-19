using Microsoft.EntityFrameworkCore;
using Milestone10Practice3EFCoreApiPractice.Data;
using Milestone10Practice3EFCoreApiPractice.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<SupportTicketService>(); // register SupportTicketService with DI
// Scoped -> one service instance per HTTP request

builder.Services.AddDbContext<AppDbContext>(options => // register AppDbContext with DI and configure it
{
    options.UseSqlite( // configure AppDbContext to use SQLite
        builder.Configuration.GetConnectionString("DefaultConnection") // find the database connection information from appsettings.json
    );
});

builder.Services.AddControllers(); // Add/register the services ASP.NET Core needs for controller-based APIs
// -> enable/setup controller functionality
/*
builder.services.addbcontext<appdbcontext>()
means:
register AppDbContext with ASP.NET Core's Dependency Injection system
// we are saying DI:
my application uses AppDbContext

-- 
options.UseSqlite()

-- GetConnectionString("DefaultConnection") means:
go into application configuration and find the connection string named DefaultConnection


// full connection flow
   appsettings.json
   
   "DefaultConnection"
   "Data Source=supporttickets.db"
   
           ↓
   
   Program.cs
   
   AddDbContext<AppDbContext>
   UseSqlite(connection string)
   
           ↓
   
   Dependency Injection
   
           ↓
   
   AppDbContext
   
           ↓
   
   DbSet<SupportTicket>
   
           ↓
   
   SQLite database

 */



var app = builder.Build();

app.MapControllers(); // find the routes defined by controller attributes and connect them to HTTP routing
// expose/connect controller routes

app.MapGet("/", () => "Hello World!");


app.Run();


/*
the goal is:
ASP.NET application -> creates/manages AppDbContext -> AppDbContext -> EF Core -> SQLite database


-- mental picture for now:

appsettings.json -> where is my database?

program.cs -> register/configure AppDbContext with DI

AppDbContext -> my application's gateway to the database

DbSet<SupportTicket> -> SupportTicket data/table

EF Core -> translates C# operations to SQL

SQLite -> actual database
*/



/*
Program.cs
→ creates configuration/options

DI
→ gives options to AppDbContext.

AppDbContext constructor
→ passes options to parent DbContext.

DbContext
→ now knows how to connect/use SQLite
*/

// Lesson 11 - EF Core-Backed Service


// ------------------------------------------------

// Models
//         → describe the data shape
//         → e.g. SupportTicket
//
// Controllers
//         → handle HTTP requests/responses
//
// Services
//         → contain application/business logic
//
// Data
//         → database access setup
//         → AppDbContext / EF Core

// ------------------------------------------------



// ------------------------------------------------

// DI builds the chain for us:
// Controller asks for SupportTicketService
//         ↓
// DI creates/provides SupportTicketService
//         ↓
// SupportTicketService needs AppDbContext
//         ↓
// DI provides AppDbContext too
//
// That is one of the nicest parts of DI.

// ------------------------------------------------




// IMPORTANT ARCHITECTURE PICTURE:
// HTTP
//         ↓
// Controller
//         ↓
// Service
//         ↓
// AppDbContext
//         ↓
// EF Core
//         ↓
// SQLite