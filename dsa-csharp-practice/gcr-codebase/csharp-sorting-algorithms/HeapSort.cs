using System;

class HeapSort
{
    static void Main()
    {
        int[] salaries = { 45000, 70000, 55000, 90000, 60000 };
        Console.WriteLine("Original Array:- ");
        PrintArray(salaries);
        Sort(salaries);
        Console.WriteLine("Sorted array:- ");
        PrintArray(salaries);
    }

    public static void Sort(int[] salaries)
    {
        int n = salaries.Length;
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(salaries, n, i);
        }
        for (int i = n - 1; i >= 0; i--)
        {
            Swap(salaries, 0, i);
            Heapify(salaries, i, 0);
        }
    }

    public static void Heapify(int[] salaries, int n, int i)
    {
        int largest = i;
        int l = 2 * i + 1;
        int r = 2 * i + 2;
        if (l < n && salaries[l] > salaries[largest])
        {
            largest = l;
        }
        if (r < n && salaries[r] > salaries[largest])
        {
            largest = r;
        }
        if (largest != i)
        {
            Swap(salaries, i, largest);
            Heapify(salaries, n, largest);
        }
    }

    public static void Swap(int[] salaries, int i, int j)
    {
        int temp = salaries[i];
        salaries[i] = salaries[j];
        salaries[j] = temp;
    }

    public static void PrintArray(int[] salaries)
    {
        foreach (double i in salaries)
        {
            Console.WriteLine("salaries:- " + i);
        }
        Console.WriteLine();
    }
}
