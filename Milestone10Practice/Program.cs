var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

// Milestone 10 
// Lesson 1 - What is Entity Framework Core?
// we want :
// controller -> service -> EF Core -> database

// Entity Framework Core (EF Core) is a .NET library
// that lets you work with relational databases using .NET objects

// EF Core is more like:
// a C# layer over SQL/database operations


// What does ORM mean?
// EF Core is an ORM.
// ORM = Object Relational Mapper
// it basically means: map C# objects to database tables and vice versa

// example
/*
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

could be mapped to a database table like this:
CREATE TABLE Products (
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    Price DECIMAL(18, 2)
    );
*/

// List<SupportTicket>
// -> data in RAM

// DbSet<SupportTicket>
// -> data in database


/*
example
private readonly AppDbContext _context;
public async Task<List<SupportTicket>> GetAllTicketsAsync()
{
    return await _context.SupportTickets.ToListAsync();
}

// _context.SupportTickets - represents teh SupportTickets table in the database
// and ToListAsync() - fetches all the records from that table and returns them as a List<SupportTicket>
// or loads rows from the database into C# objects in RAM

So conceptually:
_context.supportTickets -> SupportTickets table -> .toListAsync() -> SELECT * FROM SupportTickets -> List<SupportTicket> in RAM


*/

// Entity, DbContext, DbSet<T>
// Entity.
// an entity is usually a C# class that represents a table in the database
/*
example:
public class SupportTicket
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
// SupportTicket is an entity that represents a SupportTickets table in the database
*/

// DbContext.
// DbContext is a class that represents a session/connection with the database
// DbContext = the main object EF Core uses to interact with the database
// we will make something like:
// public class AppDbContext : DbContext {}


// DbSet<T>.
// DbSet<T> is a property of the DbContext class that represents a table in the database
// or DbSet<T> represents a table-like collection of entities in the database


// DbSet<SupportTicket> = SupportTickets table


// So
/*
Entity -> what one row looks like
DbSet<T> -> what the table looks like / collection/table of those rows
// DbContext -> the session/connection to the database / manges access to the database
*/


/*
Full mental picture

    Think of:
SupportTicket class
    ↓
describes one ticket

DbSet<SupportTicket>
    ↓
represents SupportTickets table

    AppDbContext
        ↓
contains/manages DbSets
    ↓
talks to database

    And later:
Controller
    ↓
Service
    ↓
AppDbContext
    ↓
DbSet<SupportTicket>
    ↓
SQLite database

That is the architecture we're building toward.
*/

// Entity Framework Core
//     = .NET ORM for working with relational databases.
//
//         ORM
//     = Object-Relational Mapper.
//
//         Entity
//     = C# class representing database data.
//
//         DbContext
//     = main EF Core object that manages database access.
//
//         DbSet<T>
//     = represents a table-like collection of entities.
//
//     Rough mapping:
//
// C# class      ↔ database table
// C# object     ↔ database row
// C# property   ↔ database column
// LINQ          → EF Core → SQL


// Quick practice
// Answer these in your own words:
// 1. What problem does EF Core solve compared with using List<SupportTicket>?
// with ef core we can have a database that won't disappear when we close the program


// 2. What does ORM stand for?
// Object Relational Mapping


//     3. What is an entity?
// entity is basically a class representing database data for example we could have users table
// and Users class in csharp, Users would be the entity

//         4. What is DbContext responsible for?
// it is EF Core object that manages database access

//     5. What does DbSet<SupportTicket> roughly represent?
// it represents table like entities, i am like not fully understanding but i think when we start practice 
// things will get clearer, i mean i understand, it is just i can't really imagine them in my head instantly
// like other things

//     6. Why was learning SQL still important even though EF Core can generate SQL for us?
// because we still need to understand how the SQL works i guess


