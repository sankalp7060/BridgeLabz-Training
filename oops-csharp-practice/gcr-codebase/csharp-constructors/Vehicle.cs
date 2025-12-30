using System;

class Vehicle
{
    string ownerName;
    string vehicleType;
    static double registrationFee = 5000;

    public Vehicle(string owner, string type)
    {
        ownerName = owner;
        vehicleType = type;
    }

    public void DisplayVehicleDetails()
    {
        Console.WriteLine($"{ownerName} | {vehicleType} | Fee: ₹{registrationFee}");
    }

    public static void UpdateRegistrationFee(double fee)
    {
        registrationFee = fee;
    }

    static void Main()
    {
        Vehicle.UpdateRegistrationFee(7000);
        Vehicle v = new Vehicle("Sankalp", "Bike");
        v.DisplayVehicleDetails();
    }
}
