using System;
using System.Threading.Tasks;

public class TransactionProcessor
{
    private readonly BankDatabase _db;

    public TransactionProcessor(BankDatabase db)
    {
        _db = db;
    }

    public bool ProcessTransaction(Transaction txn)
    {
        if (!_db.Accounts.TryGetValue(txn.AccountId, out var account))
        {
            Console.WriteLine($"Account {txn.AccountId} not found.");
            return false;
        }

        lock (account.BalanceLock) // Ensure atomicity
        {
            try
            {
                if (txn.Type == TransactionType.Withdrawal)
                {
                    if (account.Balance < txn.Amount)
                        throw new Exception(
                            $"Insufficient balance for account {account.AccountId}"
                        );
                    account.Balance -= txn.Amount;
                }
                else if (txn.Type == TransactionType.Deposit)
                {
                    account.Balance += txn.Amount;
                }

                // Log transaction
                _db.Transactions.Add(txn);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Transaction failed: {ex.Message}");
                return false;
            }
        }
    }

    // Async processing to simulate multiple parallel transactions
    public async Task ProcessTransactionsAsync(Transaction[] transactions)
    {
        var tasks = new Task[transactions.Length];
        for (int i = 0; i < transactions.Length; i++)
        {
            int index = i;
            tasks[i] = Task.Run(() => ProcessTransaction(transactions[index]));
        }
        await Task.WhenAll(tasks);
    }
}
