// namespace Mileston10PracticeEFCorePractice.Models;

namespace EfCorePractice.Models;

public class SupportTicket
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Category { get; set; } = "";
    public bool IsClosed { get; set; }
}

