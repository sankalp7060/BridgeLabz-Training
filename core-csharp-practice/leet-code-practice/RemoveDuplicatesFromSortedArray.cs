using System;

class RemoveDuplicatesFromSortedArray
{
    static void Main()
    {
        int[] arr = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
        int size = RemoveDuplicates(arr, arr.Length);
        Console.WriteLine($"\nArray:- {string.Join(", ", arr[..size])} and It's size:- {size}\n");
    }

    static int RemoveDuplicates(int[] arr, int n)
    {
        int k = 0;
        for (int i = 1; i < n; i++)
        {
            if (arr[k] != arr[i])
            {
                arr[++k] = arr[i];
            }
        }
        return k + 1;
    }
}
