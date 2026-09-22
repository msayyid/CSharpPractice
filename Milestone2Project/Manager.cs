namespace Milestone2Project;

public class Manager : Worker, IWorkable
{
    public string Department { get; }

    public Manager(string name, string email, string department)
        : base(name, email)
    {
        Department = department;
    }

    public override string GetRoleInfo()
    {
        return $"{Name} - Manager - {Department} Department";
    }

    public void DoWork()
    {
        Console.WriteLine($"{Name} is managing {Department} department");
    }
}