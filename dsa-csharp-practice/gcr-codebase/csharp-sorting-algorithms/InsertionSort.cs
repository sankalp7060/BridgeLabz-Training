using System;

class InsertionSort
{
    static void Main()
    {
        int[] employeeIds = { 1045, 1021, 1090, 1012, 1056 };
        Console.WriteLine("Original Array:- ");
        PrintArray(employeeIds);
        Sort(employeeIds);
        Console.WriteLine("Sorted array:- ");
        PrintArray(employeeIds);
    }

    public static void Sort(int[] employeeIds)
    {
        int n = employeeIds.Length;
        for (int i = 1; i < n; i++)
        {
            int key = employeeIds[i];
            int j = i - 1;
            while (j >= 0 && employeeIds[j] > key)
            {
                employeeIds[j + 1] = employeeIds[j];
                j--;
            }
            employeeIds[j + 1] = key;
        }
    }

    public static void PrintArray(int[] employeeIds)
    {
        foreach (int i in employeeIds)
        {
            Console.WriteLine("employeeIds:- " + i);
        }
        Console.WriteLine();
    }
}
