using System;

public class BankAccount
{
    // Fields
    public int AccountNumber;
    public string Name;
    private string Password;
    private double Balance;

    // Constructor
    public BankAccount(int accNum, string name, string password, double initialBalance)
    {
        AccountNumber = accNum;
        Name = name;
        Password = password;
        Balance = initialBalance;
    }

    // Verify password
    public bool VerifyPassword(string pass)
    {
        return Password == pass;
    }

    // Deposit
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine("Amount deposited: " + amount);
        }
        else
        {
            Console.WriteLine("Invalid deposit amount!");
        }
    }

    // Withdraw
    public void Withdraw(double amount)
    {
        if (amount <= Balance && amount > 0)
        {
            Balance -= amount;
            Console.WriteLine("Amount withdrawn: " + amount);
        }
        else
        {
            Console.WriteLine("Insufficient balance or invalid amount!");
        }
    }

    // Check balance
    public void CheckBalance()
    {
        Console.WriteLine("Current balance: " + Balance);
    }

    // Show account info
    public void ShowAccountInfo()
    {
        Console.WriteLine("Account Number: " + AccountNumber);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Balance: " + Balance);
    }
}
