namespace Milestone2Project;

public class WorkTask
{
    public int Id { get; }
    public string Title { get; }
    public WorkTaskStatus Status { get; private set; }
    public Worker? Assignee { get; private set; }

    public WorkEstimate Estimate { get; }

    public WorkTask(int id, string title, WorkEstimate estimate)
    {
        Id = id;
        Title = title;
        Assignee = null;
        Status = WorkTaskStatus.Pending;
        // question?? -- answered --
        // can i have this like only 2 params but more things assigned inside the constructor?
        // answered -----
        // yes it is fine, 
        // the parameters are just the information the caller needs to provide. the class can decide the rest itself

        // question ???? --- answered ---
        // for the estimate, i do not need another validation do i? 
        // because i put one in the struct???
        // answer -- no, we do not need more validation for WorkEstimate
        // since its constructor handles it, we get the valid inputs
        
        Estimate = estimate;
        
    }

    public void AssignWorker(Worker worker)
    {
        Assignee = worker;
    }

    public string GetAssigneeInfo()
    {
        return Assignee?.Name ?? "Unassigned";
    }
    
    // status methods
    public bool Start()
    {
        if (Status == WorkTaskStatus.Pending)
        {
            Status = WorkTaskStatus.InProgress;
            return true;
        }

        return false;
    }

    public bool Complete()
    {
        if (Status == WorkTaskStatus.InProgress)
        {
            Status = WorkTaskStatus.Completed;
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"Task {Id} - {Title}\n" +
               $"Status: {Status}\n" +
               $"Assignee: {Assignee?.Name ?? "Unassigned"}\n" +
               $"Estimated time: {Estimate.Hours}h {Estimate.Minutes}m";
    }

    public TaskSummary GetSummary()
    {
        TaskSummary taskSummary = new(Id, Title, Status, Assignee?.Name ?? "Unassigned", Estimate);
        return taskSummary;
    }
}