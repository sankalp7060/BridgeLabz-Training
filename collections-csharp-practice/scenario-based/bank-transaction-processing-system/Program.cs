using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var db = new BankDatabase();
        db.Initialize();

        var processor = new TransactionProcessor(db);

        // Test 1: Simulate 50 parallel withdrawals on same account
        Console.WriteLine("Simulating 50 parallel withdrawals of 30 each on account 1...\n");

        var withdrawals = new Transaction[50];
        for (int i = 0; i < 50; i++)
        {
            withdrawals[i] = new Transaction
            {
                AccountId = 1,
                Amount = 30m,
                Type = TransactionType.Withdrawal,
            };
        }

        await processor.ProcessTransactionsAsync(withdrawals);

        db.DisplayAccounts();
        db.DisplayTransactions();

        // Test 2: Insufficient balance scenario
        Console.WriteLine("Testing insufficient balance scenario...\n");
        var txnFail = new Transaction
        {
            AccountId = 1,
            Amount = 2000m,
            Type = TransactionType.Withdrawal,
        };
        processor.ProcessTransaction(txnFail);

        db.DisplayAccounts();
    }
}
