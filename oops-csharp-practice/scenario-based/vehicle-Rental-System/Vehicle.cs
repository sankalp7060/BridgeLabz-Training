using System;

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
