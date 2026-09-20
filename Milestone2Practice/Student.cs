namespace Milestone2Practice;

public class Student : Person
{
    public string University { get; set; }

    public Student(string name, int age, string nationality, string university)
        : base(name, age, nationality)
    {
        University = university;
    }

    public string GetInfo()
    {
        return $"{Name} is {Age} years old. From {Nationality}, studying at {University}";
    }
    
    // override
    public override string Introduce()
    {
        // return base.Introduce() $" I study at {University}";
        return $"My name is {Name}, I am {Age} years old. I am from {Nationality}. I study at {University}";
        // question? ---- answered
        // to extend instead of changing fully the parent's version, do we have to have virtual?
        // or does virtual needed for both extending and replacing?
        // answered:
        // override is needed for both
    }
}