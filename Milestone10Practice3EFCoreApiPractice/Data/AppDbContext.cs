namespace Milestone10Practice3EFCoreApiPractice.Data;
using Microsoft.EntityFrameworkCore;
using Milestone10Practice3EFCoreApiPractice.Models;

public class AppDbContext : DbContext 
// AppDbContext IS a DbContext
// Ef Core gives us DbContext, and we make our app's specific version: AppDbContext
// Why? because our context needs to know what data our app has.
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    // AppDbContext receives its database configuration from somewhere else
    // it includes things like: use sqlite,  database: supporttickets.db
    // the configuration comes from program.cs
    // and  : base(options) means:
    // pass those options to the parent DbContext class
    
    // DbContextOptions<AppDbContext>
    // = configuration for AppDbContext
    //
    // : base(options)
    // = give that configuration to EF Core's DbContext
    // -- : base(options) means:
    // -- call the DbContext constructor and give it these database options
    // ________________________________________________________
    
    public DbSet<SupportTicket> SupportTickets { get; set; } = null!;
}