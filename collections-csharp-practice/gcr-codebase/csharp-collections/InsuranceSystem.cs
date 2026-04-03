using System;
using System.Collections.Generic;

class Policy
{
    public int PolicyNo;
    public string CoverageType;
    public DateTime ExpiryDate;

    public Policy(int no, string type, DateTime expiry)
    {
        PolicyNo = no;
        CoverageType = type;
        ExpiryDate = expiry;
    }

    public override int GetHashCode()
    {
        return PolicyNo.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        Policy p = obj as Policy;
        return p != null && PolicyNo == p.PolicyNo;
    }

    public override string ToString()
    {
        return $"{PolicyNo} | {CoverageType} | {ExpiryDate.ToShortDateString()}";
    }
}

class InsuranceSystem
{
    static void Main()
    {
        HashSet<Policy> uniquePolicies = new HashSet<Policy>();

        List<Policy> insertionOrder = new List<Policy>();

        SortedSet<Policy> sortedPolicies = new SortedSet<Policy>(
            Comparer<Policy>.Create((a, b) => a.ExpiryDate.CompareTo(b.ExpiryDate))
        );

        AddPolicy(new Policy(101, "Health", DateTime.Now.AddDays(10)));
        AddPolicy(new Policy(102, "Car", DateTime.Now.AddDays(40)));
        AddPolicy(new Policy(103, "Health", DateTime.Now.AddDays(20)));
        AddPolicy(new Policy(101, "Life", DateTime.Now.AddDays(5))); // Duplicate

        void AddPolicy(Policy p)
        {
            if (uniquePolicies.Add(p))
            {
                insertionOrder.Add(p);
                sortedPolicies.Add(p);
            }
            else
            {
                Console.WriteLine("Duplicate Policy Found: " + p.PolicyNo);
            }
        }

        Console.WriteLine("\nAll Unique Policies:");
        foreach (var p in uniquePolicies)
            Console.WriteLine(p);

        Console.WriteLine("\nPolicies Expiring in 30 Days:");
        foreach (var p in uniquePolicies)
            if ((p.ExpiryDate - DateTime.Now).Days <= 30)
                Console.WriteLine(p);

        Console.WriteLine("\nHealth Policies:");
        foreach (var p in uniquePolicies)
            if (p.CoverageType == "Health")
                Console.WriteLine(p);

        Console.WriteLine("\nSorted By Expiry:");
        foreach (var p in sortedPolicies)
            Console.WriteLine(p);
    }
}
