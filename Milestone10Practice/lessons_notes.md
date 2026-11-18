# Milestone 10 — Entity Framework Core

## Lessons 1–5

---

# 1. What is Entity Framework Core?

Entity Framework Core (EF Core) is a .NET library used to work with relational databases from C#.

Instead of manually writing SQL for every database operation, we can often use C# and LINQ.

Example SQL:

```sql
SELECT *
FROM SupportTickets
WHERE IsClosed = false;
```

With EF Core:

```csharp
var tickets = context.SupportTickets
    .Where(t => !t.IsClosed)
    .ToList();
```

EF Core translates the C# LINQ query into SQL and sends it to the database.

Mental model:

```text
C# / LINQ
    ↓
EF Core
    ↓
SQL
    ↓
Database
```

EF Core does NOT replace the database.

It is a layer between our C# application and the relational database.

---

# ORM

EF Core is an ORM.

ORM means:

```text
Object-Relational Mapper
```

The basic idea is to map C# objects to relational database data.

Rough mapping:

```text
C# entity class
↔ database table structure

C# object
↔ database row

C# property
↔ database column
```

Example:

```csharp
public class SupportTicket
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Category { get; set; } = "";
    public bool IsClosed { get; set; }
}
```

Could correspond to:

```text
SupportTickets

Id | Title          | Category | IsClosed
---|----------------|----------|---------
1  | Cannot log in  | Account  | 0
```

Important:

```text
SupportTicket class
→ describes what a SupportTicket looks like

one SupportTicket object
→ roughly represents one database row
```

The class itself is NOT one row.

---

# Why SQL was still important

EF Core may generate SQL for us, but the database still uses relational database concepts.

We still need to understand:

- tables
- rows
- columns
- primary keys
- foreign keys
- relationships
- joins
- NULL
- constraints
- filtering
- grouping

Understanding SQL makes EF Core much easier to understand and debug.

---

# 2. Entity, DbContext, and DbSet

These are three major EF Core concepts.

## Entity

An entity is normally a C# class representing data that EF Core can store in the database.

Example:

```csharp
public class SupportTicket
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Category { get; set; } = "";
    public bool IsClosed { get; set; }
}
```

`SupportTicket` is an entity.

---

# DbContext

`DbContext` is one of the most important EF Core classes.

Our application created its own context:

```csharp
public class AppDbContext : DbContext
{
}
```

Because of inheritance:

```text
AppDbContext IS A DbContext
```

`DbContext` comes from EF Core.

A useful beginner mental model:

```text
AppDbContext
=
our application's gateway/workspace for the database
```

The context is the main object our C# application uses when working with the database through EF Core.

Conceptually:

```text
C# application
      ↓
AppDbContext
      ↓
EF Core
      ↓
database
```

The context knows/manages things such as:

- what entities exist
- what database provider is being used
- how to access the database
- what entities were loaded
- which entities changed
- what should be inserted
- what should be updated
- what should be deleted
- when changes should be saved

Later we use things such as:

```csharp
context.SupportTickets
```

and:

```csharp
context.SaveChanges();
```

So `AppDbContext` is not the database itself.

It is the C# object through which EF Core works with the database.

---

# DbSet<T>

Inside our context we wrote:

```csharp
public DbSet<SupportTicket> SupportTickets { get; set; } = null!;
```

Beginner mental model:

```text
DbSet<SupportTicket>
≈ database-backed collection of SupportTicket entities
```

It roughly represents access to the `SupportTickets` table.

So:

```csharp
context.SupportTickets
```

can be mentally read as:

```text
access the SupportTickets data in the database
```

Comparison with what we used before:

```csharp
List<SupportTicket>
```

was an in-memory C# collection.

The data disappeared when the program stopped.

With EF Core:

```csharp
context.SupportTickets
```

works with persistent database data.

Very rough comparison:

```text
List<SupportTicket>
→ collection stored in RAM

DbSet<SupportTicket>
→ database-backed collection/table-like access
```

They are NOT literally the same thing, but this is a useful beginner mental model.

---

# Our first entity

File:

```text
Models/SupportTicket.cs
```

Code:

```csharp
namespace EfCorePractice.Models;

public class SupportTicket
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Category { get; set; } = "";
    public bool IsClosed { get; set; }
}
```

---

# Our first DbContext

File:

```text
Data/AppDbContext.cs
```

Code:

```csharp
using EfCorePractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCorePractice.Data;

public class AppDbContext : DbContext
{
    public DbSet<SupportTicket> SupportTickets { get; set; } = null!;

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            "Data Source=supporttickets.db"
        );
    }
}
```

---

# Understanding the connection/configuration

This is an important part.

```csharp
protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite(
        "Data Source=supporttickets.db"
    );
}
```

For now, read this as:

```text
When AppDbContext needs a database:

use SQLite

and use the database file:

supporttickets.db
```

So:

```csharp
UseSqlite(...)
```

selects SQLite as the database provider.

And:

```text
Data Source=supporttickets.db
```

tells SQLite which database file to use.

Overall:

```text
AppDbContext
    ↓
Use SQLite
    ↓
supporttickets.db
```

For this learning project, we configure it directly inside `OnConfiguring`.

Later, in ASP.NET Core, we will learn the more common real-world approach using:

- dependency injection
- configuration
- connection strings
- `Program.cs`

So do not worry about thinking `OnConfiguring` is the only way to connect EF Core.

---

# What is `null!` here?

We wrote:

```csharp
public DbSet<SupportTicket> SupportTickets { get; set; } = null!;
```

The `!` is the null-forgiving operator that we learned earlier.

We are essentially telling the compiler:

```text
EF Core will initialize this property.
Do not warn me about it being null here.
```

---

# EF Core packages

For SQLite:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version "10.*"
```

For EF Core design-time functionality such as migrations:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version "10.*"
```

Because the terminal uses zsh, `"10.*"` should be quoted.

Without quotes:

```bash
--version 10.*
```

zsh may try to interpret `*` as a filename wildcard.

---

# EF Core command-line tool

We installed:

```bash
dotnet tool install --global dotnet-ef --version "10.*"
```

We can check it with:

```bash
dotnet ef --version
```

Our installed version was:

```text
10.0.15
```

The EF CLI lets us perform operations such as:

```text
create migrations
apply migrations
inspect migrations
```

---

# 3. Migrations

At first we had our C# entity:

```csharp
public class SupportTicket
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Category { get; set; } = "";
    public bool IsClosed { get; set; }
}
```

But simply creating the class does NOT automatically create the SQLite table.

Our C# says what our data model should look like.

The actual database still needs to be changed.

That is where migrations come in.

---

# What is a migration?

A migration describes a change to the database schema.

Mental model:

```text
C# model/entities
      ↓
migration
      ↓
database schema instructions
      ↓
apply migration
      ↓
actual database structure
```

Instead of manually writing:

```sql
CREATE TABLE SupportTickets (...);
```

we can define the model in C#, generate a migration, and let EF Core produce the schema changes.

---

# Creating the first migration

We ran:

```bash
dotnet ef migrations add InitialCreate
```

Breakdown:

```text
dotnet ef
→ use EF Core CLI

migrations
→ work with migrations

add
→ create a migration

InitialCreate
→ migration name
```

This created a `Migrations` folder.

One generated migration contained:

```csharp
protected override void Up(
    MigrationBuilder migrationBuilder)
{
    migrationBuilder.CreateTable(
        name: "SupportTickets",
        columns: table => new
        {
            Id = table.Column<int>(
                    type: "INTEGER",
                    nullable: false)
                .Annotation(
                    "Sqlite:Autoincrement",
                    true),

            Title = table.Column<string>(
                type: "TEXT",
                nullable: false),

            Category = table.Column<string>(
                type: "TEXT",
                nullable: false),

            IsClosed = table.Column<bool>(
                type: "INTEGER",
                nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey(
                "PK_SupportTickets",
                x => x.Id);
        });
}
```

EF Core looked at our entity and generated instructions such as:

```text
SupportTicket.Id
→ INTEGER
→ PRIMARY KEY
→ AUTOINCREMENT

SupportTicket.Title
→ TEXT NOT NULL

SupportTicket.Category
→ TEXT NOT NULL

SupportTicket.IsClosed
→ INTEGER NOT NULL
```

---

# Up() and Down()

A migration normally contains:

```csharp
Up()
```

and:

```csharp
Down()
```

Mental model:

```text
Up()
→ apply the database change

Down()
→ reverse the database change
```

Our `Up()` created the `SupportTickets` table.

Our `Down()` contained:

```csharp
protected override void Down(
    MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropTable(
        name: "SupportTickets");
}
```

So:

```text
Up
→ create SupportTickets

Down
→ remove SupportTickets
```

---

# Applying the migration

Creating a migration does NOT yet modify the database.

We then ran:

```bash
dotnet ef database update
```

This means:

```text
Apply any migrations that have not yet
been applied to the database.
```

After this, the real file appeared:

```text
supporttickets.db
```

---

# Inspecting the real database

We opened it with:

```bash
sqlite3 supporttickets.db
```

Then:

```sql
.tables
```

showed:

```text
SupportTickets
__EFMigrationsHistory
__EFMigrationsLock
```

The actual schema was:

```sql
CREATE TABLE IF NOT EXISTS "SupportTickets" (
    "Id" INTEGER NOT NULL
        CONSTRAINT "PK_SupportTickets"
        PRIMARY KEY AUTOINCREMENT,

    "Title" TEXT NOT NULL,
    "Category" TEXT NOT NULL,
    "IsClosed" INTEGER NOT NULL
);
```

This proved that:

```text
C# entity
↓
migration
↓
database update
↓
real SQLite table
```

---

# __EFMigrationsHistory

EF Core creates:

```text
__EFMigrationsHistory
```

This keeps track of which migrations have already been applied.

Mental model:

```text
EF Core:
"Has InitialCreate already been applied?"

__EFMigrationsHistory:
"Yes."
```

Therefore EF Core does not repeatedly apply the same migration.

Usually we do not manually modify this table.

---

# Why migrations are useful

Imagine we later change:

```csharp
public class SupportTicket
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";
}
```

Adding the C# property does NOT automatically modify an existing database.

We would create another migration, for example:

```bash
dotnet ef migrations add AddTicketDescription
```

Then:

```bash
dotnet ef database update
```

The new migration would describe how the existing database should change.

So migrations let the database schema evolve alongside our C# code.

---

# 4. Adding data with EF Core

We created our first database row from C#.

Code:

```csharp
using EfCorePractice.Data;
using EfCorePractice.Models;

using var context = new AppDbContext();

var ticket = new SupportTicket
{
    Title = "Cannot log in",
    Category = "Account",
    IsClosed = false
};

context.SupportTickets.Add(ticket);

context.SaveChanges();

Console.WriteLine(
    $"Ticket saved with Id: {ticket.Id}"
);
```

---

# Step 1 — create the context

```csharp
using var context = new AppDbContext();
```

We create an `AppDbContext` object.

Mental model:

```text
context
=
our current EF Core database workspace/gateway
```

Through it we can access:

```csharp
context.SupportTickets
```

---

# Step 2 — create a normal C# object

```csharp
var ticket = new SupportTicket
{
    Title = "Cannot log in",
    Category = "Account",
    IsClosed = false
};
```

At this moment:

```text
ticket
→ normal C# object in memory
```

It is NOT yet stored in SQLite.

---

# Step 3 — Add()

```csharp
context.SupportTickets.Add(ticket);
```

This does not immediately send an INSERT to SQLite.

It tells EF Core:

```text
This is a new entity.
This needs to be inserted when changes are saved.
```

Mental model:

```text
Add()
→ mark/track this entity as new
```

---

# Step 4 — SaveChanges()

```csharp
context.SaveChanges();
```

This is the important step.

Now EF Core looks at its tracked changes and sends the required SQL to SQLite.

Conceptually:

```text
new SupportTicket object
        ↓
Add(ticket)
        ↓
EF Core tracks it as new
        ↓
SaveChanges()
        ↓
INSERT SQL
        ↓
SQLite
```

A useful rule:

```text
Add()
→ tell EF what changed

SaveChanges()
→ actually persist changes
```

---

# Database-generated Id

We did NOT set:

```csharp
ticket.Id
```

manually.

SQLite generated it because the column was:

```text
PRIMARY KEY AUTOINCREMENT
```

After:

```csharp
context.SaveChanges();
```

EF Core populated:

```csharp
ticket.Id
```

with the generated value.

Our output was:

```text
Ticket saved with Id: 1
```

The actual SQLite row was:

```text
Id  Title          Category  IsClosed
--  -------------  --------  --------
1   Cannot log in  Account   0
```

---

# 5. Reading data with EF Core

We then learned to read database rows back into C# objects.

---

# Reading all rows

```csharp
var tickets =
    context.SupportTickets.ToList();
```

Mental model:

```text
context.SupportTickets
→ access SupportTickets data

ToList()
→ execute query and load results into C#
```

Rough SQL equivalent:

```sql
SELECT *
FROM SupportTickets;
```

After `ToList()`:

```csharp
tickets
```

is now a normal C# collection in memory.

---

# Printing the results

```csharp
foreach (var ticket in tickets)
{
    Console.WriteLine(
        $"{ticket.Id} - " +
        $"{ticket.Title} - " +
        $"{ticket.Category} - " +
        $"{ticket.IsClosed}"
    );
}
```

---

# Filtering database data

We can use LINQ directly on the DbSet.

Example:

```csharp
var unresolvedTickets =
    context.SupportTickets
        .Where(t => !t.IsClosed)
        .ToList();
```

Roughly:

```sql
SELECT *
FROM SupportTickets
WHERE IsClosed = false;
```

Another example:

```csharp
var accountTickets =
    context.SupportTickets
        .Where(t => t.Category == "Account")
        .ToList();
```

Roughly:

```sql
SELECT *
FROM SupportTickets
WHERE Category = 'Account';
```

---

# Very important: DbSet query vs List query

These look similar:

```csharp
tickets.Where(...)
```

and:

```csharp
context.SupportTickets.Where(...)
```

but there is an important difference.

## Querying an already loaded list

```csharp
tickets.Where(t => !t.IsClosed)
```

Here:

```text
tickets
→ List<SupportTicket>
→ already loaded into RAM
```

So filtering happens in C#.

Flow:

```text
database
↓
load ALL rows
↓
C# List
↓
filter in memory
```

---

## Querying the DbSet

```csharp
context.SupportTickets
    .Where(t => !t.IsClosed)
    .ToList();
```

Here EF Core can translate the query into SQL.

Flow:

```text
LINQ query
↓
EF Core
↓
SQL WHERE
↓
database filters rows
↓
only matching rows are returned
```

This is an extremely important EF Core distinction.

---

# Query construction vs execution

Example:

```csharp
var query =
    context.SupportTickets
        .Where(t => !t.IsClosed);
```

At this point, EF Core has essentially built a query description.

Then:

```csharp
var tickets = query.ToList();
```

causes the query to execute and retrieve the data.

Beginner mental model:

```text
Where(...)
→ build/filter the query

ToList()
→ execute it and get the results
```

We will learn more about this later.

---

# Finding one row

If we want one ticket:

```csharp
var ticket =
    context.SupportTickets
        .FirstOrDefault(t => t.Id == 2);
```

Mental model:

```text
FirstOrDefault
→ first matching entity

if none exists
→ null
```

Therefore:

```csharp
if (ticket != null)
{
    Console.WriteLine(ticket.Title);
}
```

---

# Where() vs FirstOrDefault()

Important rule:

```text
Where()
→ potentially many results

FirstOrDefault()
→ one result or null
```

Example:

```csharp
var tickets =
    context.SupportTickets
        .Where(t => t.Category == "Account")
        .ToList();
```

This is for multiple tickets.

But:

```csharp
var ticket =
    context.SupportTickets
        .FirstOrDefault(t => t.Id == 2);
```

is better when we expect one ticket.

---

# Why ToString() on a Where query did not print the ticket

We tried something like:

```csharp
var result =
    context.SupportTickets
        .Where(t => t.Id == 2);

Console.WriteLine(result);
```

`Where()` returns a sequence/query, not one ticket.

Calling:

```csharp
result.ToString()
```

does NOT mean:

```text
turn all items into readable strings
```

It calls `ToString()` on the query/sequence object itself.

That is why it can print something resembling an enumerable/query type instead of ticket information.

If we need one object:

```csharp
var ticket =
    context.SupportTickets
        .FirstOrDefault(t => t.Id == 2);
```

---

# Current EF Core architecture

At this point our practice program roughly looks like:

```text
Program.cs
    ↓
AppDbContext
    ↓
DbSet<SupportTicket>
    ↓
EF Core
    ↓
SQLite
    ↓
supporttickets.db
```

---

# Full connection/setup flow to remember

This is the important routine to become comfortable with.

## 1. Install EF Core provider

For SQLite:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version "10.*"
```

## 2. Install design package

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version "10.*"
```

## 3. Create entity

```csharp
public class SupportTicket
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
}
```

## 4. Create DbContext

```csharp
public class AppDbContext : DbContext
{
}
```

## 5. Add DbSet

```csharp
public DbSet<SupportTicket> SupportTickets
    { get; set; } = null!;
```

## 6. Configure database provider

For our current console practice project:

```csharp
protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite(
        "Data Source=supporttickets.db"
    );
}
```

## 7. Create migration

```bash
dotnet ef migrations add InitialCreate
```

## 8. Apply migration

```bash
dotnet ef database update
```

## 9. Use DbContext

```csharp
using var context = new AppDbContext();
```

## 10. Work with DbSet

Add:

```csharp
context.SupportTickets.Add(ticket);
```

Read:

```csharp
context.SupportTickets.ToList();
```

Filter:

```csharp
context.SupportTickets
    .Where(...)
    .ToList();
```

Find one:

```csharp
context.SupportTickets
    .FirstOrDefault(...);
```

## 11. Save changes when modifying data

```csharp
context.SaveChanges();
```

---

# Current mental model

The most important picture so far:

```text
SupportTicket
→ describes one type of database entity

DbSet<SupportTicket>
→ access to SupportTicket data

AppDbContext
→ application's EF Core database gateway/workspace

UseSqlite(...)
→ tells EF Core which database/provider to use

Migration
→ describes database schema changes

database update
→ applies those changes to SQLite

Add()
→ tell EF Core about new data

SaveChanges()
→ persist tracked changes

Where()
→ filter

FirstOrDefault()
→ get one match or null

ToList()
→ execute query and load results
```

---

# Important distinction: schema vs data

This is useful to keep clear.

## Schema

The structure of the database:

```text
tables
columns
types
keys
relationships
constraints
```

We change schema using migrations.

Example:

```text
Add Description column
```

→ migration.

## Data

The actual rows:

```text
1 | Cannot log in | Account | false
```

We work with data using:

```csharp
Add()
Where()
FirstOrDefault()
SaveChanges()
```

So:

```text
Migrations
→ database structure/schema

DbSet + queries + SaveChanges
→ database data
```

---

# What I should eventually be able to do without AI

I do NOT need to memorize every exact method signature.

But I should eventually be comfortable with this thought process:

```text
I need EF Core
↓
install provider
↓
create entity
↓
create DbContext
↓
add DbSet
↓
configure database
↓
create migration
↓
update database
↓
use context to query/change data
```

Exact package names, unusual configuration options, or less common syntax can always be checked in documentation.

What should become natural is:

- what each component does
- how the components connect
- what order the setup happens in
- when migrations are needed
- when `SaveChanges()` is needed
- whether I am querying the database or an in-memory list

With repeated practice, this should become routine.