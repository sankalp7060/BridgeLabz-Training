using System;
using System.Collections.Generic;

class SubsetCheck
{
    static void Main()
    {
        HashSet<int> small = new HashSet<int>() { 2, 3 };
        HashSet<int> big = new HashSet<int>() { 1, 2, 3, 4 };

        Console.WriteLine(small.IsSubsetOf(big));
    }
}
