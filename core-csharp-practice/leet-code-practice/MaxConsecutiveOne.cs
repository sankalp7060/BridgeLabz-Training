using System;

class MaxConsecutiveOne
{
    static void Main()
    {
        int[] arr = { 1, 0, 1, 1, 0, 1 };
        int numberOfOne = ConsecutiveOne(arr);
        Console.WriteLine("Maximum number of consecutive one:- " + numberOfOne);
    }

    static int ConsecutiveOne(int[] arr)
    {
        int n = arr.Length;
        int c = 0;
        int max = 0;
        foreach (int i in arr)
        {
            if (i == 1)
            {
                c++;
                max = Math.Max(max, c);
            }
            else
            {
                c = 0;
            }
        }
        return max;
    }
}
