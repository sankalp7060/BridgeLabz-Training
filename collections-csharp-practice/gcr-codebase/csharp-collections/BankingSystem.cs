using System;
using System.Collections.Generic;

class BankingSystem
{
    static void Main()
    {
        Dictionary<int, double> accounts = new Dictionary<int, double>();

        accounts[101] = 5000;
        accounts[102] = 12000;
        accounts[103] = 8000;

        Queue<int> withdrawQueue = new Queue<int>();

        withdrawQueue.Enqueue(101);
        withdrawQueue.Enqueue(103);

        Console.WriteLine("Withdrawal Processing:");

        while (withdrawQueue.Count > 0)
        {
            int acc = withdrawQueue.Dequeue();
            accounts[acc] -= 1000;
            Console.WriteLine("Processed Account: " + acc);
        }

        SortedDictionary<double, int> sorted = new SortedDictionary<double, int>();

        foreach (var acc in accounts)
            sorted[acc.Value] = acc.Key;

        Console.WriteLine("\nCustomers Sorted By Balance:");

        foreach (var s in sorted)
            Console.WriteLine("Account: " + s.Value + " Balance: " + s.Key);
    }
}
