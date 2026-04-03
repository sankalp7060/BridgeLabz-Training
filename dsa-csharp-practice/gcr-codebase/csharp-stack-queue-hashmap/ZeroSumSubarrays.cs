using System;
using System.Collections.Generic;

class ZeroSumSubarrays
{
    static void FindZeroSum(int[] arr)
    {
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        int sum = 0;

        map[0] = new List<int> { -1 };

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];

            if (map.ContainsKey(sum))
            {
                foreach (int start in map[sum])
                    Console.WriteLine($"Subarray: {start + 1} to {i}");
            }

            if (!map.ContainsKey(sum))
                map[sum] = new List<int>();

            map[sum].Add(i);
        }
        Console.WriteLine("All subarray whose sum is equal to zero:- ");
        foreach (int key in map.Keys)
        {
            Console.WriteLine($"Key: {key}, Value: {string.Join(", ", map[key])}");
        }
    }

    static void Main()
    {
        int[] arr = { 3, 4, -7, 3, 1, 3, 1, -4 };
        FindZeroSum(arr);
    }
}
