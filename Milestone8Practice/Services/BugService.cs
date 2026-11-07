namespace Milestone8Practice.Services;

public class BugService : IBugService
// this means BugService promises to implement everything required by IBugService
{
    private readonly List<BugTicket> _bugs =
    [

        new(1, "Login button not working", "High", false),
        new(2, "Wrong page title", "Low", true),
        new(3, "Application crashes, ", "Critical", false)
    ];

    public List<BugTicket> GetAll()
    {
        return _bugs;
    }

    public BugTicket? GetById(int id)
    {
        return _bugs.FirstOrDefault(bug => bug.Id == id);
    }

    public BugTicket Create(BugTicket bug)
    {
        _bugs.Add(bug);
        return bug;
    }

    public BugTicket? Update(int id, BugTicket updatedBug)
    {
        BugTicket? bug = _bugs.FirstOrDefault(bug => bug.Id == id);
        if (bug is null)
        {
            return null;
        }

        int index = _bugs.IndexOf(bug);
        BugTicket replacement = updatedBug with { Id = id };
        _bugs[index] = replacement;
        return replacement;
    }

    public bool Delete(int id)
    {
        BugTicket? bug = _bugs.FirstOrDefault(bug => bug.Id == id);
        if (bug is null)
        {
            return false;
        }

        _bugs.Remove(bug);
        return true;
    }
    
}