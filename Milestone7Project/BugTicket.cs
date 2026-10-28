namespace Milestone7Project;

public record BugTicket(
    int Id, 
    string Title,
    string Severity,
    bool IsResolved
);