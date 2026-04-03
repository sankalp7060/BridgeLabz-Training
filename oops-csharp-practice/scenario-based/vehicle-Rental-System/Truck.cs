class Truck : Vehicle
{
    public Truck(string number, double rentalCost)
        : base(number, "Truck", rentalCost) { }

    public override double CalculateRentalCost(int days)
    {
        return RentalCost * days * 1.5;
    }
}
