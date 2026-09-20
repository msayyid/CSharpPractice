namespace Milestone2Practice;

public class Robot : IWorker
{
    public string Model { get; }

    public Robot(string model)
    {
        Model = model;
    }

    public void Work()
    {
        Console.WriteLine($"{Model} is working");
    }
}