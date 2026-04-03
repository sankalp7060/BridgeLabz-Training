using System;

class FindRotationPoint
{
    static void Main()
    {
        int[] arr = { 4, 5, 6, 7, 0, 1, 2 };
        int index = Search(arr);
        Console.WriteLine(index);
    }

    static int Search(int[] arr)
    {
        int l = 0;
        int r = arr.Length - 1;
        while (l < r)
        {
            int mid = (l + r) / 2;
            if (arr[mid] > arr[r])
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
