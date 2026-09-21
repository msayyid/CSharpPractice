namespace Milestone2Practice;

public struct Coordinate
{
    public int X { get; }
    public int Y { get; }

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public string GetInfo()
    {
        return $"X is {X}" +
               $"Y is {Y}";
    }
}