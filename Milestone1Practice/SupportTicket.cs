namespace Milestone1Practice;
//
// public class SupportTicket
// {
//     public string Title { get; private set; }
//     public TicketStatus Status { get; private set; }
//
//     public SupportTicket(string title)
//     {
//         Title = title;
//         Status = TicketStatus.Open;
//     }
//
//     public override string ToString()
//     {
//         return $"{Title} - {Status}";
//     }
//     
//     // The rules are:
//     //
//     // Open → InProgress
//     // InProgress → Resolved
//     // Resolved → Closed
//     
//     // Start
//     
//     // question, i chose void method, i wanted bool, but chose void because
//     // we kinda do not return anything just change the status, i mean i m not sure
//     public void Start() // question, why in here we are choosing to not pass any parameters
//     {
//         if (Status != TicketStatus.Open)
//         {
//             Console.WriteLine("The issue cannot be started");
//             return;
//
//         }
//
//         Status = TicketStatus.InProgress;
//     }
//     
//     
//     // resolve
//     public void Resolve()
//     {
//         if (Status != TicketStatus.InProgress)
//         {
//             Console.WriteLine("The issue is not in progress -> cannot be resolved");
//             return;
//         }
//
//         Status = TicketStatus.Resolved;
//     }
//     
//     // close
//     public void Close()
//     {
//         if (Status != TicketStatus.Resolved)
//         {
//             Console.WriteLine("The issue is not resolved -> cannot be closed");
//             return;
//         }
//
//         Status = TicketStatus.Closed;
//     }
//     
//     // show status
//     public void ShowStatus()
//     {
//         string message = Status switch
//         {
//             TicketStatus.Open => $"\"{Title}\" is open.",
//             TicketStatus.InProgress => $"\"{Title}\" is currently being worked on.",
//             TicketStatus.Resolved => $"\"{Title}\" has been resolved.",
//             TicketStatus.Closed => $"\"{Title}\" is closed.",
//             _ => "Unknown status."
//         };
//
//         Console.WriteLine(message);
//     }
// }

public class SupportTicket
{
    public string Title { get; private set; }
    public TicketStatus Status { get; private set; }

    public SupportTicket(string title)
    {
        Title = title;
        Status = TicketStatus.Open;
    }

    public override string ToString()
    {
        return $"\"{Title}\" - {Status}";
    }
    
    // open
    public bool Start()
    {
        if (Status != TicketStatus.Open)
        {
            return false;
        }

        Status = TicketStatus.InProgress;
        return true;
    }
    
    // resolve
    public bool Resolve()
    {
        if (Status != TicketStatus.InProgress)
        {
            return false;
        }

        Status = TicketStatus.Resolved;
        return true;
    }

    public bool Close()
    {
        if (Status != TicketStatus.Resolved)
        {
            return false;
        }

        Status = TicketStatus.Closed;
        return true;
    }

    public string GetStatusMessage()
    {
        return Status switch
        {
            TicketStatus.Open => $"\"{Title}\" is open.",
            TicketStatus.InProgress => $"\"{Title}\" is in progress.",
            TicketStatus.Resolved => $"\"{Title}\" is resolved.",
            TicketStatus.Closed => $"\"{Title}\" is closed.",
            _ => "Unknown status."
        };
    }
}