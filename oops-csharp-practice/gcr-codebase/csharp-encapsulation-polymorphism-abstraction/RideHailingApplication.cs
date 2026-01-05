using System;

interface IGPS
{
    string GetCurrentLocation();
    void UpdateLocation(string newLocation);
}

abstract class Vehicle
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public double Rate { get; private set; }
    protected string currentLocation;

    public Vehicle(int id, string name, double rate)
    {
        Id = id;
        Name = name;
        Rate = rate;
        currentLocation = "Unknown";
    }

    public abstract double CalculateFare(double distance);

    public void GetVehicleDetails()
    {
        Console.WriteLine($"Id:- {Id}, Name:- {Name}, Rate:- {Rate}");
    }
}

class Car : Vehicle, IGPS
{
    public Car(int id, string name)
        : base(id, name, 15) { }

    public override double CalculateFare(double distance)
    {
        return Rate * distance;
    }

    public string GetCurrentLocation()
    {
        return currentLocation;
    }

    public void UpdateLocation(string newLocation)
    {
        currentLocation = newLocation;
    }
}

class Bike : Vehicle, IGPS
{
    public Bike(int id, string name)
        : base(id, name, 7) { }

    public override double CalculateFare(double distance)
    {
        return Rate * distance;
    }

    public string GetCurrentLocation()
    {
        return currentLocation;
    }

    public void UpdateLocation(string newLocation)
    {
        currentLocation = newLocation;
    }
}

class Auto : Vehicle, IGPS
{
    public Auto(int id, string name)
        : base(id, name, 10) { }

    public override double CalculateFare(double distance)
    {
        return Rate * distance;
    }

    public string GetCurrentLocation()
    {
        return currentLocation;
    }

    public void UpdateLocation(string newLocation)
    {
        currentLocation = newLocation;
    }
}

class RideHailingApplication
{
    static void Main()
    {
        Vehicle[] vehicles = new Vehicle[3];

        vehicles[0] = new Car(101, "Rahul");
        vehicles[1] = new Bike(102, "Amit");
        vehicles[2] = new Auto(103, "Suresh");

        double distance = 12.5;

        Console.WriteLine("Ride Details:\n");

        foreach (Vehicle v in vehicles)
        {
            v.GetVehicleDetails();
            Console.WriteLine("Fare: " + v.CalculateFare(distance));

            if (v is IGPS gps)
            {
                gps.UpdateLocation("Sector 21");
                Console.WriteLine("Current Location: " + gps.GetCurrentLocation());
            }

            Console.WriteLine();
        }
    }
}
