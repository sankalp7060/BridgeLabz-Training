using System;

class FindPeakElement
{
    static void Main()
    {
        int[] arr = { 1, 2, 1, 3, 5, 6, 4 };
        int index = FindElement(arr);
        Console.WriteLine(index);
    }

    static int FindElement(int[] arr)
    {
        int l = 0;
        int r = arr.Length;
        while (l < r)
        {
            int mid = (l + r) / 2;
            if (arr[mid] < arr[mid + 1])
            {
                l = mid + 1;
            }
            else
            {
                r = mid;
            }
        }
        return l;
    }
}
