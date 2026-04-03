using System;

class BankAccount
{
    public int AccountNumber { get; set; }
    public double Balance { get; set; }
}

class SavingsAccount : BankAccount
{
    public double InterestRate { get; set; }

    public void DisplayAccountType()
    {
        Console.WriteLine($"Savings Account | Interest: {InterestRate}% | Balance: {Balance}");
    }
}

class CheckingAccount : BankAccount
{
    public int WithdrawalLimit { get; set; }

    public void DisplayAccountType()
    {
        Console.WriteLine(
            $"Checking Account | Withdrawal Limit: {WithdrawalLimit} | Balance: {Balance}"
        );
    }
}

class FixedDepositAccount : BankAccount
{
    public int LockPeriod { get; set; }

    public void DisplayAccountType()
    {
        Console.WriteLine($"Fixed Deposit | Lock Period: {LockPeriod} months | Balance: {Balance}");
    }
}

class BankSystem
{
    static void Main()
    {
        SavingsAccount sa = new SavingsAccount
        {
            AccountNumber = 101,
            Balance = 50000,
            InterestRate = 5.0,
        };
        CheckingAccount ca = new CheckingAccount
        {
            AccountNumber = 102,
            Balance = 30000,
            WithdrawalLimit = 20000,
        };
        FixedDepositAccount fd = new FixedDepositAccount
        {
            AccountNumber = 103,
            Balance = 100000,
            LockPeriod = 12,
        };

        sa.DisplayAccountType();
        ca.DisplayAccountType();
        fd.DisplayAccountType();
    }
}
