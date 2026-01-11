using System;

class LinearSearch
{
    static void Main()
    {
        int[] arr = { 1, 45, 2, 3, 67, 90, 87, 54, 100, 2 };
        int ele = 100;
        int index = Search(arr, ele);
        Console.WriteLine($"Index of {ele}:- {index}");
    }

    static int Search(int[] arr, int ele)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == ele)
            {
                return i;
            }
        }
        return -1;
    }
}
