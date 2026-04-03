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
