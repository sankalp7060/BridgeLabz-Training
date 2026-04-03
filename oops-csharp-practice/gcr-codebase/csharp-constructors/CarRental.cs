using System;

class CarRental
{
    string customerName;
    string carModel;
    int rentalDays;
    const int costPerDay = 1000;

    public CarRental() { }

    public CarRental(string name, string model, int days)
    {
        customerName = name;
        carModel = model;
        rentalDays = days;
    }

    public void TotalCost()
    {
        Console.WriteLine($"Total Cost: ₹{rentalDays * costPerDay}");
    }

    static void Main()
    {
        CarRental c = new CarRental("Sankalp", "BMW", 3);
        c.TotalCost();
    }
}
