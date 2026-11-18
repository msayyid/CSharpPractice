// namespace Mileston10PracticeEFCorePractice.Data;
using EfCorePractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCorePractice.Data;

public class AppDbContext : DbContext // we are saying AppDbContext is a DbContext
// we are creating our own version called AppDbContext, because our application needs its own database context
{
    public DbSet<SupportTicket> SupportTickets { get; set; } = null!; // EF Core will initialize this property; don't warn me about it being null initially
    // my database contains a collection/table of SupportTicket entities called SupportTickets
    
    
    // OnConfiguring => configure how EF Core connects to the database
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=supporttickets.db");
        // use sqlite and store the database in a file called supporttickets.db
    }
}