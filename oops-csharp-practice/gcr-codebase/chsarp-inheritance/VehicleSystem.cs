using System;

interface Refuelable
{
    void Refuel();
}

class Vehicle
{
    public int MaxSpeed { get; set; }
    public string Model { get; set; }
}

class ElectricVehicle : Vehicle
{
    public void Charge()
    {
        Console.WriteLine($"Charging electric vehicle: {Model}");
    }
}

class PetrolVehicle : Vehicle, Refuelable
{
    public void Refuel()
    {
        Console.WriteLine($"Refueling petrol vehicle: {Model}");
    }
}

class VehicleSystem
{
    static void Main()
    {
        PetrolVehicle pv = new PetrolVehicle { Model = "Suzuki", MaxSpeed = 180 };
        pv.Refuel();

        ElectricVehicle ev = new ElectricVehicle { Model = "Tesla", MaxSpeed = 250 };
        ev.Charge();
    }
}
