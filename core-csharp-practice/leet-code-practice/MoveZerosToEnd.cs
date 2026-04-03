using System;

class MoveZerosToEnd
{
    static void Main()
    {
        int[] arr = { 0, 1, 0, 3, 12 };
        Move(arr, arr.Length);
        Console.WriteLine($"Array:- {string.Join(", ", arr)}");
    }

    static void Move(int[] arr, int n)
    {
        int k = 0;
        foreach (int i in arr)
        {
            if (i != 0)
            {
                arr[k++] = i;
            }
        }
        for (int i = k; i < n; i++)
        {
            arr[i] = 0;
        }
    }
}
