using System;

public class Account
{
    public int AccountId { get; set; }
    public string HolderName { get; set; }
    public decimal Balance { get; set; }

    // Lock object for thread-safety during updates
    public object BalanceLock = new object();
}
