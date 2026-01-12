using System;

public abstract class LoanApplication : IApprovable
{
    public string LoanType { get; protected set; }
    public int TermInMonths { get; protected set; }
    protected double InterestRate;
    protected double Principal;

    protected bool isApproved;

    protected LoanApplication(double principal, int term, double interestRate)
    {
        Principal = principal;
        TermInMonths = term;
        InterestRate = interestRate;
    }

    public abstract bool ApproveLoan(Applicant applicant);

    public virtual double CalculateEMI()
    {
        double monthlyRate = InterestRate / (12 * 100);
        double numerator = Principal * monthlyRate * Math.Pow(1 + monthlyRate, TermInMonths);
        double denominator = Math.Pow(1 + monthlyRate, TermInMonths) - 1;
        return numerator / denominator;
    }

    public bool IsApproved()
    {
        return isApproved;
    }
}
