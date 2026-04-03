public class AutoLoan : LoanApplication
{
    public AutoLoan(double principal, int term)
        : base(principal, term, 9.5)
    {
        LoanType = "Auto Loan";
    }

    public override bool ApproveLoan(Applicant applicant)
    {
        isApproved = applicant.GetCreditScore() >= 680 && applicant.Income >= Principal * 0.35;
        return isApproved;
    }
}
