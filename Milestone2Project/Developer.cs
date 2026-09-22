namespace Milestone2Project;

public class Developer : Worker, IWorkable
{
    public string ProgrammingLanguage { get; }

    public Developer(string name, string email, string programmingLanguage)
        : base(name, email)
    {
        ProgrammingLanguage = programmingLanguage;
    }

    public override string GetRoleInfo()
    {
        return $"{Name} - Developer - {ProgrammingLanguage}";
    }

    public void DoWork()
    {
        Console.WriteLine($"{Name} is writing code");
    }
}