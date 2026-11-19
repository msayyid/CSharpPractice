namespace Milestone10Practice3EFCoreApiPractice.Models;

public class SupportTicket
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Category { get; set; } = ""; // = ""; means when a new SupportTicket is created, initialize Title with an empty string instead of null
    public bool IsClosed { get; set; } 
}

