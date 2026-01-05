using System;

interface IInsurable
{
    double CalculateInsurance();
    string GetInsuranceDetails();
}

abstract class Vehicle
{
    public string Number { get; private set; }
    public string Type { get; private set; }
    public double RentalCost { get; private set; }

    public Vehicle(string number, string type, double rentalCost)
    {
        Number = number;
        Type = type;
        RentalCost = rentalCost;
    }

    public abstract double CalculateRentalCost(int days);

    public void Display()
    {
        Console.WriteLine($"{Number}, {Type}, {RentalCost}");
    }

    public void DisplayDetails(int days)
    {
        double rentalCost = CalculateRentalCost(days);
        double insuranceCost = 0;

        if (this is IInsurable insurable)
        {
            insuranceCost = insurable.CalculateInsurance();
            Console.WriteLine(insurable.GetInsuranceDetails());
        }

        double totalCost = rentalCost + insuranceCost;

        Console.WriteLine(
            $"Vehicle: {Number}, Type: {Type}, Rental Cost: {rentalCost}, Insurance: {insuranceCost}, Total: {totalCost}"
        );
    }
}

class Car : Vehicle, IInsurable
{
    private string policyNumber;

    public Car(string number, double rentalCost, string policyNumber)
        : base(number, "Car", rentalCost)
    {
        this.policyNumber = policyNumber;
    }

    public override double CalculateRentalCost(int days)
    {
        return RentalCost * days;
    }

    public double CalculateInsurance()
    {
        return RentalCost * 0.1;
    }

    public string GetInsuranceDetails()
    {
        return $"Car Insurance Policy: {policyNumber}";
    }
}

class Bike : Vehicle, IInsurable
{
    private string policyNumber;

    public Bike(string number, double rentalCost, string policyNumber)
        : base(number, "Bike", rentalCost)
    {
        this.policyNumber = policyNumber;
    }

    public override double CalculateRentalCost(int days)
    {
        return RentalCost * days;
    }

    public double CalculateInsurance()
    {
        return RentalCost * 0.05;
    }

    public string GetInsuranceDetails()
    {
        return $"Bike Insurance Policy: {policyNumber}";
    }
}

class Truck : Vehicle
{
    public Truck(string number, double rentalCost)
        : base(number, "Truck", rentalCost) { }

    public override double CalculateRentalCost(int days)
    {
        return RentalCost * days * 1.5;
    }
}

class VehicleRentalSystem
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

        for (int i = 0; i < vehicles.Length; i++)
        {
            vehicles[i].DisplayDetails(rentalDays);
        }
    }
}
