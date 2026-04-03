using System;

public enum TransactionType
{
    Deposit,
    Withdrawal,
}

public class Transaction
{
    public Guid TransactionId { get; set; } = Guid.NewGuid();
    public int AccountId { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
