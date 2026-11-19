// Console.WriteLine("Hello, World!");

// Microsoft.EntityFrameworkCore.Sqlite
// → lets EF Core work with SQLite
// 
// Microsoft.EntityFrameworkCore.Design
// → tools needed for things like migrations


// SupportTicket => Shape of one row
// DbSet<SupportTicket> => the SupportTickets  collection/table
// AppDbContext => object containing/mapping our database data

// SupportTicket.cs
//     → "This is what one ticket looks like."
//
//
// AppDbContext.csda
//     → "This is my application's database context."
//
//
// DbSet<SupportTicket> SupportTickets
//     → "My database has SupportTicket data."
//
//
// UseSqlite(...)
//     → "Store that database using SQLite."



// What does “my app's database context” actually mean?
//     This phrase is annoyingly abstract at first.
//
//     Think of AppDbContext as the main EF Core object your application uses to work with its database.
//
//     It knows things such as:
// Which database am I using?
//     → SQLite
//
// Where is it?
//     → supporttickets.db
//
//     What kinds of data/tables does my app have?
//     → SupportTickets
//
//     What objects have been added/changed/deleted?
//     → EF Core keeps track of these
//
// How do I send those changes to the database?
//     → through the DbContext

// Lesson 3 - Migrations

// Migration is a set of instructions describing how to change the database structure



// Lesson 4 - populate the database using EF Core

//
// using System.Runtime.CompilerServices;
// using EfCorePractice.Data;
// using EfCorePractice.Models;

// create the context
// we are creating the object through which the program will work with the database
// so, context => my current EF Core database workspace/gateway
// using var context = new AppDbContext();

// create a normal C# object
// at this exact moment, this is still just a normal C# object in memory
// Id isn't specified, because sqlite will generate it automatically
// var ticket = new SupportTicket
// {
//     Title = "Cannot log in",
//     Category = "Account",
//     IsClosed = false
// };

// tell EF Core we want to add it
// this tells EF Core:
// this new SupportTicket should be inserted when changes are saved
// context.SupportTickets.Add(ticket);

// actually save
// now EF Core looks at what changed and sends the necessary SQL to SQLite
// context.SaveChanges();
// Console.WriteLine("Ticket saved");
// Console.WriteLine($"Ticket saved with Id: {ticket.Id}");




// __________
// we define our database structure in C# using entities and DbContext, then
// migrations translate those model changes into database schema changes for SQLite
// __________

// Lesson 5 - Reading data with EF Core
// we have so far: C# object => Add() => SaveChanges() => SQLite row

// now we go the other direction
// SQLite rows => EFCore => C# Objects

// Read All Tickets

// context.SupportTickets.Add(new SupportTicket
// {
//     Title = "Payment failed",
//     Category = "Billing",
//     IsClosed = false
// });
//
// context.SupportTickets.Add(new SupportTicket
// {
//     Title = "Application crashes",
//     Category = "Technical",
//     IsClosed = true
// });
// context.SaveChanges();

// var tickets = context.SupportTickets.ToList();
// access the SupportTickets data
// and load all rows into a C# list

// foreach (var t in tickets)
// {
//     Console.WriteLine($"{t.Id} - {t.Title} - {t.Category} - {t.IsClosed}");
//     
// }



/*
// task 1 
// get all tickets
var tickets = context.SupportTickets.ToList();
foreach (var ticket in tickets)
{
    Console.WriteLine($"{
        ticket.Id
    }, {
        ticket.Category
    }, {
        ticket.Title
    }, {
        ticket.IsClosed
    }");
}


// task 2
// get only tickets where IsClosed = false
Console.WriteLine();
Console.WriteLine("false Closed tickets only");
foreach (var ticket in tickets)
{
    if (!ticket.IsClosed)
    {
        Console.WriteLine($"{ticket.Id} - {ticket.Title} - {ticket.Category} - {ticket.IsClosed}");
    }
}

// task3 
// get only tickets where category = 'account'
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Account category tickets");
foreach (var ticket in tickets)
{
    if (ticket.Category == "Account")
    {
        Console.WriteLine($"{ticket.Id} - {ticket.Title} - {ticket.Category} - {ticket.IsClosed}");
    }
}


// task 4 
// find ticket with id == 2
Console.WriteLine();
Console.WriteLine();
var ticketId2 = tickets.Where(t => t.Id == 2).ToArray();
// var ticketId2 = tickets.Where(t => t.Id == 2).ToString();
// Console.WriteLine(ticketId2); // i treid this, this gave me enumarable even tho i made it a string, i m not sure honestly
foreach (var VARIABLE in ticketId2)
{
    Console.WriteLine(VARIABLE.Id);
    Console.WriteLine(VARIABLE.Category);
    Console.WriteLine(VARIABLE.Title);
    Console.WriteLine(VARIABLE.IsClosed);
    
}
// i didn't really understand what happened in here, it worked, but still

// here's the correct one my friend
var ticketWithId2 = tickets.FirstOrDefault(t => t.Id == 2);
if (ticketWithId2 != null)
{
    
    Console.WriteLine($"{ticketWithId2.Id}, {ticketWithId2.Title}, {ticketWithId2.Category}, {ticketWithId2.IsClosed}");
    
}
// this worked


// task 5
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

foreach (var ticket in tickets)
{
    Console.WriteLine($"{ticket.Id} - {ticket.Title} - {ticket.Category} - {ticket.IsClosed}");
}


Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("#################################################");
// fixed task 2
var unresolvedTickets = context.SupportTickets.Where(t => !t.IsClosed).ToList();
foreach (var ut in unresolvedTickets)
{
    Console.WriteLine($"{ut.Id} - {ut.Title} - {ut.Category} - {ut.IsClosed}");
}


Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("#################################################");
// fixed task 2
var accountTickets = context.SupportTickets.Where(t => t.Category == "Account").ToList();
foreach (var at in accountTickets)
{
    Console.WriteLine($"{at.Id} - {at.Title} - {at.Category} - {at.IsClosed}");
}


Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("#################################################");
// task 4
var ticketWithCorrectId2 = context.SupportTickets.FirstOrDefault(t => t.Id == 2);
if (ticketWithCorrectId2 != null)
{
    Console.WriteLine(
        $"{ticketWithCorrectId2.Id} - {ticketWithCorrectId2.Title} - {ticketWithCorrectId2.Category} - {ticketWithCorrectId2.IsClosed}"
    );
}
*/



/*
 
// Lesson 6 - updating data with EF Core


// using var context = new AppDbContext();
//
// var ticket = context.SupportTickets.FirstOrDefault(t => t.Id == 1);
//
// if (ticket != null)
// {
//     ticket.IsClosed = true;
//     context.SaveChanges();
// }

// mental model:
// EF loads the entity
// ticket.IsClosed = true
// -> C# object changes
// SaveChanges()
// -> EF notices the change
// -> generates UPDATE SQL
// -> database row changes


// practice
// 1.
using var context = new AppDbContext(); 
// AppDbContext = our app's EF Core gateway/workspace for the database
// it knows which database, which file (supporttickets.db), and what data i can access
// when we say context.SupportTickets = we are basically saying:
// through my database context, access the SupportTickets data

// using var; means:
// create this context, use it, adn automatically clean/dispose it when the scope finishes

var ticket1 = context.SupportTickets.FirstOrDefault(t => t.Id == 1);
if (ticket1 != null)
{
    ticket1.Category = "Technical";
    // context.SaveChanges();
}


// 2.
var ticket2 = context.SupportTickets.FirstOrDefault(t => t.Id == 2);
if (ticket2 != null)
{
    ticket2.IsClosed = true;
    context.SaveChanges(); // so us doing this once is enough if i understadn correctly??
}




*/


/*

// Lesson 7 - Deleting data with EF Core

// using var context = new AppDbContext();
// var ticket = context.SupportTickets.FirstOrDefault(t => t.Id == 3);
// if (ticket != null)
// {
//     context.SupportTickets.Remove(ticket); // mark this ticket for deletion
//     context.SaveChanges();
// }


// practice

// 1.
using var context = new AppDbContext();

var ticket1 = context.SupportTickets.FirstOrDefault(t => t.Id == 3);
if (ticket1 != null)
{
    context.SupportTickets.Remove(ticket1);
}

context.SaveChanges();

*/




// Lesson 8: Async EF Core
// the main idea is:
// database work is I/O, so in ASP.NET Core we usually prefer async database operations

// when ef core asks sqlite or another database for data, the application may have to wait
// for the database

// ToList() -> synchronous database query
// ToListAsync() -> asynchronous database query

/*
 *var ticket = await context.supporttickets.firstordefaultAsync(t => t.id == 1);
 *
 * the database operation is awaited asynchronously
 *
 *
 * SaveChangesAsync()
 * 
 */
 
//  // example async create
//  using EfCorePractice.Data;
//  using EfCorePractice.Models;
//  using Microsoft.EntityFrameworkCore;
//
//  using var context = new AppDbContext();
//  
//  var ticket = new SupportTicket
//  {
//      Title = "Password reset failed",
//      Category = "Account",
//      IsClosed = false
//  };
//  
//  context.SupportTickets.Add(ticket); // add is not async, because it changes ef core's in-memory tracking state
//  await context.SaveChangesAsync();
//  Console.WriteLine($"Created ticket {ticket.Id}");
//  
//  
//  // example async READ
//  var tickets = await context.SupportTickets
//      .Where(t => !t.IsClosed) // build query
//      .ToListAsync(); // send query to db asynchronously
//                      // wait for result
//                      // return List<SupportTicket>
//
// // example async UPDATE
// var ticket1 = await context.SupportTickets
//     .FirstOrDefaultAsync(t => t.Id == 1); // load identity
//
// if (ticket1 != null)
// {
//     ticket1.IsClosed = true; // modify property
//     await context.SaveChangesAsync(); // SaveChangesAsync()
//     
//     
// }
//
//
// // example async DELETE
// var ticket2 = await context.SupportTickets
//     .FirstOrDefaultAsync(t => t.Id == 4);
//
//
// if (ticket2 != null)
// {
//     context.SupportTickets.Remove(ticket2);
//     await context.SaveChangesAsync();
// }

using EfCorePractice.Data;
using EfCorePractice.Models;
using Microsoft.EntityFrameworkCore;

await using var context = new AppDbContext();

// 1 get all tickets
var tickets = await context.SupportTickets.ToListAsync();
foreach (var VARIABLE in tickets) 
{
    Console.WriteLine(VARIABLE.Title);
}

Console.WriteLine();
// 2. get unresolved tickets
var unresolvedTickets = await context.SupportTickets.Where(t => !t.IsClosed).ToListAsync();
foreach (var ticket in unresolvedTickets)
{
    Console.WriteLine(ticket.Title + " " + ticket.IsClosed);
}


Console.WriteLine();
// 3. find ticket with id = 1
var ticket3 = await context.SupportTickets.FirstOrDefaultAsync(t => t.Id == 3);
if (ticket3 != null)
{
    Console.WriteLine(ticket3.Id + " " + ticket3.Title);
}

// 4. 
Console.WriteLine();
var ticket1 = await context.SupportTickets.FirstOrDefaultAsync(t => t.Id == 1);
if (ticket1 != null)
{
    ticket1.Category = "Account";
    await context.SaveChangesAsync();
}

// 5. add a new ticket
context.SupportTickets.Add(new SupportTicket
{
    Title = "Cannot update profile",
    Category = "Account",
    IsClosed = false
});
await context.SaveChangesAsync();




// Lesson 9 - EF Core + ASP.NET Core Dependency Injection

// the architecture we are moving toward:
// HTTP Request -> Controller -> IService -> Service -> AppDbContext -> EF Core -> SQLite

// -> new project