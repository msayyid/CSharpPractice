namespace Milestone2Project;

public abstract class Worker
{
    public string Name { get; }
    public string Email { get; }

    protected Worker(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public abstract string GetRoleInfo();
    
}