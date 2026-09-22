namespace Milestone2Practice;

public class Delivery
{
    public int Id { get; }
    public Customer Customer { get; }
    public Location Destination { get; }
    public string? Driver { get; private set; }
    

    public Delivery(int id, Customer customer, Location destination, string? driver)
    {
        Id = id;
        Customer = customer;
        Destination = destination;
        Driver = driver; // is this how a might be null should be done in a constructor?
    }

    public void AssignDriver(string driverName)
    {
        Driver = driverName;
    }

    public string GetDriverInfo()
    {
        return Driver ?? "No driver assigned";
    }
    

}