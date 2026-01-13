using System;
using System.Diagnostics;

class LinearVsBinarySearch
{
    static void Main()
    {
        int[] sizes = { 1000, 10000, 1_000_000 };
        int target = -1;
        foreach (int n in sizes)
        {
            Console.WriteLine($"\nDataset Size: {n}");

            int[] data = new int[n];
            for (int i = 0; i < n; i++)
                data[i] = i * 2;

            Stopwatch sw = Stopwatch.StartNew();
            LinearSearch(data, target);
            sw.Stop();
            Console.WriteLine($"Linear Search Time: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            BinarySearch(data, target);
            sw.Stop();
            Console.WriteLine($"Binary Search Time: {sw.ElapsedMilliseconds} ms");
        }
    }

    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
                return i;
        }
        return -1;
    }

    static int BinarySearch(int[] arr, int target)
    {
        int left = 0,
            right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
                return mid;
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
}
