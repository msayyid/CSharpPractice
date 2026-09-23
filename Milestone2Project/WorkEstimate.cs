namespace Milestone2Project;

public struct WorkEstimate
// represents how long a task is expected to take
{
    public int Hours { get; }
    public int Minutes { get; }

    public WorkEstimate(int hours, int minutes)
    {
        if (hours < 0)
        {
            throw new ArgumentException("Hours cannot be negative");
        }

        if (minutes > 59 || minutes < 0)
        {
            throw new ArgumentException("Minutes must be within 0-59");
        }
        // and i chose to throw error because these inputs break the flow
        // throwing makes sense here
        Hours = hours;
        Minutes = minutes;
    }

    public string GetInfo()
    {
        return $"{Hours}h {Minutes}m";
    }
}