class Program
{
    static void Main()
    {
        Applicant applicant = new Applicant(
            name: "Sankalp",
            creditScore: 720,
            income: 90000,
            loanAmount: 1500000
        );

        LoanApplication loan = new HomeLoan(principal: applicant.LoanAmount, term: 240);

        LoanEngine.ProcessLoan(applicant, loan);
    }
}
