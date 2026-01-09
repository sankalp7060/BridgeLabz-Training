using System;

class MergeSort
{
    static void Main()
    {
        double[] bookPrices = { 399.50, 249.99, 599.00, 199.75, 449.25 };
        Console.WriteLine("Original Array:- ");
        PrintArray(bookPrices);
        Sort(bookPrices, 0, bookPrices.Length - 1);
        Console.WriteLine("Sorted array:- ");
        PrintArray(bookPrices);
    }

    public static void Sort(double[] bookPrices, int start, int end)
    {
        if (start < end)
        {
            int middle = start + (end - start) / 2;
            Sort(bookPrices, start, middle);
            Sort(bookPrices, middle + 1, end);
            Merge(bookPrices, start, middle, end);
        }
    }

    public static void Merge(double[] bookPrices, int start, int middle, int end)
    {
        int n1 = middle - start + 1;
        int n2 = end - middle;

        double[] left = new double[n1];
        double[] right = new double[n2];

        for (int i = 0; i < n1; i++)
        {
            left[i] = bookPrices[start + i];
        }
        for (int i = 0; i < n2; i++)
        {
            right[i] = bookPrices[middle + 1 + i];
        }
        int m = 0;
        int n = 0;
        int k = start;
        while (m < n1 && n < n2)
        {
            if (left[m] <= right[n])
            {
                bookPrices[k++] = left[m++];
            }
            else
            {
                bookPrices[k++] = right[n++];
            }
        }
        while (m < n1)
        {
            bookPrices[k++] = left[m++];
        }
        while (n < n2)
        {
            bookPrices[k++] = right[n++];
        }
    }

    public static void Swap(double[] arr, int i, int j)
    {
        double temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static void PrintArray(double[] bookPrices)
    {
        foreach (double i in bookPrices)
        {
            Console.WriteLine("bookPrices:- " + i);
        }
        Console.WriteLine();
    }
}
