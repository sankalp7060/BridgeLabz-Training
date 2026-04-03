public class HomeLoan : LoanApplication
{
    public HomeLoan(double principal, int term)
        : base(principal, term, 8.2)
    {
        LoanType = "Home Loan";
    }

    public override bool ApproveLoan(Applicant applicant)
    {
        isApproved = applicant.GetCreditScore() >= 700 && applicant.Income >= Principal * 0.3;
        return isApproved;
    }

    public override double CalculateEMI()
    {
        return base.CalculateEMI() * 0.98;
    }
}
