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
        
}