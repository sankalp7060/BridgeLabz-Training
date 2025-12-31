using System;

class Vehicle
{
    public static double RegistrationFee = 1500;

    public string OwnerName;
    public string VehicleType;
    public readonly string RegistrationNumber;

    public Vehicle(string ownerName, string vehicleType, string regNumber)
    {
        this.OwnerName = ownerName;
        this.VehicleType = vehicleType;
        this.RegistrationNumber = regNumber;
    }

    public static void UpdateRegistrationFee(double fee)
    {
        RegistrationFee = fee;
    }

    public void Display(object obj)
    {
        if (obj is Vehicle)
        {
            Console.WriteLine(
                $"{OwnerName} - {VehicleType}, Reg No: {RegistrationNumber}, Fee: {RegistrationFee}"
            );
        }
    }

    static void Main()
    {
        Vehicle v = new Vehicle("Sankalp", "Bike", "MH12AB1234");
        UpdateRegistrationFee(2000);
        v.Display(v);
    }
}
