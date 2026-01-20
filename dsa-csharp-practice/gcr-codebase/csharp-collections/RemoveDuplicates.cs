using System;
using System.Collections.Generic;

class RemoveDuplicates
{
    static void Main()
    {
        List<int> list = new List<int>() { 3, 1, 2, 2, 3, 4 };

        HashSet<int> seen = new HashSet<int>();
        List<int> result = new List<int>();

        foreach (int x in list)
        {
            if (!seen.Contains(x))
            {
                seen.Add(x);
                result.Add(x);
            }
        }

        foreach (int x in result)
            Console.Write(x + " ");
    }
}
