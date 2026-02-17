using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

public class BankDatabase
{
    // In-memory cache for accounts
    public Dictionary<int, Account> Accounts = new Dictionary<int, Account>();

    // In-memory transaction log (thread-safe)
    public ConcurrentBag<Transaction> Transactions = new ConcurrentBag<Transaction>();

    // Initialize with a sample account
    public void Initialize()
    {
        Accounts[1] = new Account
        {
            AccountId = 1,
            HolderName = "John Doe",
            Balance = 1000m,
        };
    }

    public void DisplayAccounts()
    {
        Console.WriteLine("\n--- Accounts ---");
        foreach (var acc in Accounts.Values)
            Console.WriteLine(
                $"AccountId: {acc.AccountId}, Holder: {acc.HolderName}, Balance: {acc.Balance}"
            );
        Console.WriteLine("----------------\n");
    }

    public void DisplayTransactions()
    {
        Console.WriteLine("\n--- Transactions ---");
        foreach (var txn in Transactions)
            Console.WriteLine(
                $"{txn.TransactionId} | Account: {txn.AccountId} | Type: {txn.Type} | Amount: {txn.Amount} | Date: {txn.CreatedDate}"
            );
        Console.WriteLine("-------------------\n");
    }
}
