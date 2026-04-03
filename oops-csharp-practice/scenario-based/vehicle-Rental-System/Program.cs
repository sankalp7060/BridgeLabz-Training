using System;

class Program
{
    static void Main()
    {
        Vehicle[] vehicles = new Vehicle[4];

        vehicles[0] = new Car("CAR123", 2000, "POLICY-CAR1");
        vehicles[1] = new Bike("BIKE456", 500, "POLICY-BIKE1");
        vehicles[2] = new Truck("TRUCK789", 5000);
        vehicles[3] = new Car("CAR999", 2500, "POLICY-CAR2");

        Console.WriteLine("Vehicle Rental Details:\n");

        int rentalDays = 3;

        foreach (var vehicle in vehicles)
        {
            vehicle.DisplayDetails(rentalDays);
        }
    }
}
