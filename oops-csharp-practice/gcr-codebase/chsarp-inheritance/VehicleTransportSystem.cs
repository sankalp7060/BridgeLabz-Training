using System;

class Vehicle
{
    public int MaxSpeed { get; set; }
    public string FuelType { get; set; }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Speed: {MaxSpeed}, Fuel: {FuelType}");
    }
}

class Car : Vehicle
{
    public int SeatCapacity { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Seats: {SeatCapacity}");
    }
}

class Truck : Vehicle
{
    public int PayloadCapacity { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Payload: {PayloadCapacity}");
    }
}

class Motorcycle : Vehicle
{
    public bool HasSidecar { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Sidecar: {HasSidecar}");
    }
}

class VehicleTransportSystem
{
    static void Main()
    {
        Vehicle[] vehicles =
        {
            new Car
            {
                MaxSpeed = 180,
                FuelType = "Petrol",
                SeatCapacity = 5,
            },
            new Truck
            {
                MaxSpeed = 120,
                FuelType = "Diesel",
                PayloadCapacity = 5000,
            },
            new Motorcycle
            {
                MaxSpeed = 160,
                FuelType = "Petrol",
                HasSidecar = false,
            },
        };

        foreach (Vehicle v in vehicles)
            v.DisplayInfo();
    }
}
