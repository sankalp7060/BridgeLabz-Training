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
