using System;

public class AccountDatabase
{
    public BankAccount[] accounts;
    public int count;
    private int nextAccountNumber;

    public AccountDatabase(int size)
    {
        accounts = new BankAccount[size];
        count = 0;
        nextAccountNumber = 1001; // Start account numbers from 1001
    }

    // Add account
    public BankAccount AddAccount(string name, string password, double initialBalance)
    {
        if (count < accounts.Length)
        {
            BankAccount newAccount = new BankAccount(
                nextAccountNumber,
                name,
                password,
                initialBalance
            );
            accounts[count] = newAccount;
            count++;
            nextAccountNumber++;
            return newAccount;
        }
        else
        {
            Console.WriteLine("Database full! Cannot add more accounts.");
            return null;
        }
    }

    // Find account by account number
    public BankAccount FindAccount(int accNum)
    {
        for (int i = 0; i < count; i++)
        {
            if (accounts[i].AccountNumber == accNum)
            {
                return accounts[i];
            }
        }
        return null;
    }
}
