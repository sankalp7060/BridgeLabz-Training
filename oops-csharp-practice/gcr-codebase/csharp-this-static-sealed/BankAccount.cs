using System;

class BankAccount
{
    public static string BankName = "State Bank";
    private static int totalAccounts = 0;

    public string AccountHolderName;
    public readonly int AccountNumber;

    public BankAccount(string accountHolderName, int accountNumber)
    {
        this.AccountHolderName = accountHolderName;
        this.AccountNumber = accountNumber;
        totalAccounts++;
    }

    public static void GetTotalAccounts()
    {
        Console.WriteLine("Total Accounts: " + totalAccounts);
    }

    public void Display(object obj)
    {
        if (obj is BankAccount)
        {
            Console.WriteLine(
                $"Bank: {BankName}, Name: {AccountHolderName}, Account No: {AccountNumber}"
            );
        }
    }

    static void Main()
    {
        BankAccount acc = new BankAccount("Sankalp", 1001);
        acc.Display(acc);
        BankAccount.GetTotalAccounts();
    }
}
