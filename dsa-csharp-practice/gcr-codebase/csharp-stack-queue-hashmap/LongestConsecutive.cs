using System;
using System.Collections.Generic;

class LongestConsecutive
{
    static int FindLongest(int[] arr)
    {
        HashSet<int> set = new HashSet<int>(arr);
        int maxLength = 0;

        foreach (int num in arr)
        {
            if (!set.Contains(num - 1))
            {
                int current = num;
                int count = 1;

                while (set.Contains(current + 1))
                {
                    current++;
                    count++;
                }

                maxLength = Math.Max(maxLength, count);
            }
        }
        return maxLength;
    }

    static void Main()
    {
        int[] arr = { 100, 4, 200, 1, 3, 2 };
        Console.WriteLine(FindLongest(arr));
    }
}
