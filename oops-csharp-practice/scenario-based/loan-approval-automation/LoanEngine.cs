using System;

public class LoanEngine
{
    public static void ProcessLoan(Applicant applicant, LoanApplication loan)
    {
        Console.WriteLine($"Processing {loan.LoanType} for {applicant.Name}");

        if (loan.ApproveLoan(applicant))
        {
            Console.WriteLine("Loan Approved ");
            Console.WriteLine($"Monthly EMI: ₹{loan.CalculateEMI():F2}");
        }
        else
        {
            Console.WriteLine("Loan Rejected ");
        }
    }
}
