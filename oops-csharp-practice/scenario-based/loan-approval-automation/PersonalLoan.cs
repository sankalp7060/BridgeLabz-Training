public class PersonalLoan : LoanApplication
{
    public PersonalLoan(double principal, int term)
        : base(principal, term, 12.5)
    {
        LoanType = "Personal Loan";
    }

    public override bool ApproveLoan(Applicant applicant)
    {
        isApproved = applicant.GetCreditScore() >= 650 && applicant.Income >= Principal * 0.4;
        return isApproved;
    }
}
