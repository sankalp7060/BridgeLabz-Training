public class Applicant
{
    public string Name { get; private set; }
    private int creditScore;
    public double Income { get; private set; }
    public double LoanAmount { get; private set; }

    public Applicant(string name, int creditScore, double income, double loanAmount)
    {
        Name = name;
        this.creditScore = creditScore;
        Income = income;
        LoanAmount = loanAmount;
    }

    internal int GetCreditScore()
    {
        return creditScore;
    }
}
