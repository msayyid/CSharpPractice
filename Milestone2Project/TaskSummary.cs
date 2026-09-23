namespace Milestone2Project;

public record TaskSummary(
    int Id, 
    string Title, 
    WorkTaskStatus Status, 
    // Worker AssigneeName, 
    string AssigneeName, // i was not sure whether this was supposed to be Worker type or just a string for the name
    // i chose string, otherwise i couldn't have done the ?? "Unassigned"
    // answered -- it is fine, to have string, since we only care about the name not the whole class
    WorkEstimate Estimate
    );
    // i need you to remind me what this was for
    // answered --
    // records are like data containers
    
    // note
    // records use value-based equality by default, so equality is based
    // on their contained values rather than whether they're the exact
    // same object
    
    