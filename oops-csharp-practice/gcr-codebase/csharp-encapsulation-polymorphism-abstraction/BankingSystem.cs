using System;

interface ILoanable
{
    void ApplyForLoan(double amount);
    double CalculateLoanEligibility();
}

abstract class BankAccount
{
    public string Number { get; private set; }
    public string Name { get; private set; }
    protected double Balance { get; private set; }

    public BankAccount(string number, string name, double balance)
    {
        Number = number;
        Name = name;
        Balance = balance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
            Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= Balance && amount > 0)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
    }

    public abstract double CalculateInterest();

    public void DisplayAccountInfo()
    {
        Console.WriteLine(
            $"Account: {Number}, Holder: {Name}, Balance: {Balance}, Interest: {CalculateInterest()}"
        );
    }
}

class SavingsAccount : BankAccount, ILoanable
{
    public SavingsAccount(string number, string name, double balance)
        : base(number, name, balance) { }

    public override double CalculateInterest()
    {
        return Balance * 0.04;
    }

    public void ApplyForLoan(double amount)
    {
        Console.WriteLine($"Loan applied for amount: {amount}");
    }

    public double CalculateLoanEligibility()
    {
        return Balance * 5;
    }
}

class CurrentAccount : BankAccount
{
    public CurrentAccount(string number, string name, double balance)
        : base(number, name, balance) { }

    public override double CalculateInterest()
    {
        return Balance * 0.01;
    }
}

class BankingSystem
{
    static void Main()
    {
        BankAccount[] accounts = new BankAccount[3];

        accounts[0] = new SavingsAccount("SA101", "Rahul", 50000);
        accounts[1] = new CurrentAccount("CA201", "Anita", 100000);
        accounts[2] = new SavingsAccount("SA102", "Aman", 30000);

        Console.WriteLine("Bank Account Details:\n");

        for (int i = 0; i < accounts.Length; i++)
        {
            accounts[i].DisplayAccountInfo();
            if (accounts[i] is ILoanable loanable)
            {
                Console.WriteLine($"Loan Eligibility: {loanable.CalculateLoanEligibility()}");
            }

            Console.WriteLine();
        }
    }
}
