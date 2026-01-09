using System;

class InsertionSort
{
    static void Main()
    {
        double[] productPrices = { 499.99, 1299.50, 299.00, 799.75, 199.99 };
        Console.WriteLine("Original Array:- ");
        PrintArray(productPrices);
        Sort(productPrices, 0, productPrices.Length - 1);
        Console.WriteLine("Sorted array:- ");
        PrintArray(productPrices);
    }

    public static void Sort(double[] productPrices, int start, int end)
    {
        if (start < end)
        {
            int pivot = Partition(productPrices, start, end);

            Sort(productPrices, start, pivot - 1);
            Sort(productPrices, pivot + 1, end);
        }
    }

    public static int Partition(double[] productPrices, int start, int end)
    {
        double pivot = productPrices[end];
        int i = start - 1;
        for (int j = start; j < end; j++)
        {
            if (productPrices[j] < pivot)
            {
                i++;
                Console.WriteLine(string.Join(" ,", productPrices));
                Swap(productPrices, i, j);
                Console.WriteLine(string.Join(" ,", productPrices) + "\n");
            }
        }
        Console.WriteLine(string.Join(" ,", productPrices));
        Swap(productPrices, i + 1, end);
        Console.WriteLine(string.Join(" ,", productPrices) + "/");
        return i + 1;
    }

    public static void Swap(double[] arr, int i, int j)
    {
        double temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static void PrintArray(double[] productPrices)
    {
        foreach (double i in productPrices)
        {
            Console.WriteLine("productPrices:- " + i);
        }
        Console.WriteLine();
    }
}
