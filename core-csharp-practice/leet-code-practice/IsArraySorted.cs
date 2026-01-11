using System;

class IsArraySorted
{
    static void Main()
    {
        int[] arr = { 2, 0, 8, 98, 567, 4, 5, 3, 45678, 1 };
        bool isSorted = IsSorted(arr, arr.Length);
        if (isSorted)
        {
            Console.WriteLine("Array is sorted");
        }
        else
        {
            Console.WriteLine("Array is not sorted");
        }
    }

    public static bool IsSorted(int[] arr, int n)
    {
        for (int i = 1; i < n; i++)
        {
            if (arr[i - 1] > arr[i])
            {
                return false;
            }
        }
        return true;
    }
}
