using System;
using System.Diagnostics;

class SortingComparison
{
    static void Main()
    {
        int[] sizes = { 1000, 10000 };
        foreach (int n in sizes)
        {
            int[] arr = GenerateArray(n);
            Console.WriteLine($"\nDataset Size: {n}");

            int[] bubble = (int[])arr.Clone();
            Measure("Bubble Sort", () => BubbleSort(bubble));

            int[] merge = (int[])arr.Clone();
            Measure("Merge Sort", () => MergeSort(merge, 0, merge.Length - 1));

            int[] quick = (int[])arr.Clone();
            Measure("Quick Sort", () => QuickSort(quick, 0, quick.Length - 1));
        }
    }

    static int[] GenerateArray(int n)
    {
        Random rnd = new Random();
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
            arr[i] = rnd.Next();
        return arr;
    }

    static void Measure(string name, Action action)
    {
        Stopwatch sw = Stopwatch.StartNew();
        action();
        sw.Stop();
        Console.WriteLine($"{name}: {sw.ElapsedMilliseconds} ms");
    }

    static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        for (int j = 0; j < arr.Length - i - 1; j++)
            if (arr[j] > arr[j + 1])
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
    }

    static void MergeSort(int[] arr, int l, int r)
    {
        if (l >= r)
            return;
        int m = (l + r) / 2;
        MergeSort(arr, l, m);
        MergeSort(arr, m + 1, r);
        Merge(arr, l, m, r);
    }

    static void Merge(int[] arr, int l, int m, int r)
    {
        int[] temp = new int[r - l + 1];
        int i = l,
            j = m + 1,
            k = 0;

        while (i <= m && j <= r)
            temp[k++] = arr[i] < arr[j] ? arr[i++] : arr[j++];

        while (i <= m)
            temp[k++] = arr[i++];
        while (j <= r)
            temp[k++] = arr[j++];

        Array.Copy(temp, 0, arr, l, temp.Length);
    }

    static void QuickSort(int[] arr, int low, int high)
    {
        if (low >= high)
            return;
        int p = Partition(arr, low, high);
        QuickSort(arr, low, p - 1);
        QuickSort(arr, p + 1, high);
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low;
        for (int j = low; j < high; j++)
            if (arr[j] < pivot)
                (arr[i++], arr[j]) = (arr[j], arr[i]);
        (arr[i], arr[high]) = (arr[high], arr[i]);
        return i;
    }
}
