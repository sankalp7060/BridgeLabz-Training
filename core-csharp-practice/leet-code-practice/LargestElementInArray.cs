using System;

class LargestElementInArray
{
    static void Main()
    {
        int[] arr = { 2, 0, 8, 98, 567, 4, 5, 3, 45678, 1 };
        int max = FindLargest(arr);
        Console.WriteLine("The maximum element: " + max);
    }

    public static int FindLargest(int[] arr)
    {
        int max = int.MinValue;
        foreach (int i in arr)
        {
            if (i > max)
                max = i;
        }
        return max;
    }
}
