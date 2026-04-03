using System;
using System.Collections.Generic;

class SetEquality
{
    static void Main()
    {
        HashSet<int> s1 = new HashSet<int>() { 1, 2, 3 };
        HashSet<int> s2 = new HashSet<int>() { 3, 2, 1 };

        Console.WriteLine(s1.SetEquals(s2));
    }
}
