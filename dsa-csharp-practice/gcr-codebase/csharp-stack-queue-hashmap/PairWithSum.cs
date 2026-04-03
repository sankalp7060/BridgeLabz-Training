using System;
using System.Collections.Generic;

class PairWithSum
{
    static bool HasPair(int[] arr, int target)
    {
        HashSet<int> set = new HashSet<int>();
        bool isContains = false;

        foreach (int num in arr)
        {
            if (set.Contains(target - num))
            {
                Console.WriteLine($"Pair is {num} and {target - num}");
                isContains = true;
            }
            set.Add(num);
        }
        return isContains;
    }

    static void Main()
    {
        int[] arr = { 8, 7, 2, 5, 3, 1 };
        int target = 10;
        Console.WriteLine(HasPair(arr, target));
    }
}
