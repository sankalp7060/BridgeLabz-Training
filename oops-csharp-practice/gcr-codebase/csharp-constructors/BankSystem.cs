using System;

class BankAccount
{
    public int accountNumber;
    protected string accountHolder;
    private double balance;

    // Constructor
    public BankAccount(int accNo, string holder, double bal)
    {
        accountNumber = accNo;
        accountHolder = holder;
        balance = bal;
    }

    public double GetBalance()
    {
        return balance;
    }
}

class SavingsAccount : BankAccount
{
    public SavingsAccount(int accNo, string holder, double bal)
        : base(accNo, holder, bal) { }

    public void Display()
    {
        Console.WriteLine($"Account No: {accountNumber}");
        Console.WriteLine($"Account Holder: {accountHolder}");
    }
}

class BankSystem
{
    static void Main()
    {
        SavingsAccount sa = new SavingsAccount(101, "Sankalp", 5000);

        sa.Display();
        Console.WriteLine("Balance: " + sa.GetBalance());
    }
}
