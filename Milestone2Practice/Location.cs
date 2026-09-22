namespace Milestone2Practice;

public struct Location
{
    public double Latitude { get; } // this means someone can change the values
    public double Longitude { get; }
    

    public Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
    
    public string GetInfo()
    {
        return $"{Latitude}, {Longitude}";
    }
}