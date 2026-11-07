namespace Milestone8Practice.Services;

public interface IBugService
// any class that claims to be an IBugService must provide these operations
// IBugService = contract
// It promises the below methods exist, but doesn't say how they work
{
    List<BugTicket> GetAll();

    BugTicket? GetById(int id);
    BugTicket Create(BugTicket bug);

    BugTicket? Update(int id, BugTicket updatedBug);

    bool Delete(int id);
}