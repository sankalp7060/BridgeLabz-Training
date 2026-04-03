using System;

namespace Code;

public class BankAccount
{
    public double Balance { get; private set; } = 0;

    public void Deposit(double amount)
    {
        if (amount < 0) throw new ArgumentException("Amount must be positive");
        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount > Balance) throw new InvalidOperationException("Insufficient funds");
        Balance -= amount;
    }

    public double GetBalance() => Balance;
}
