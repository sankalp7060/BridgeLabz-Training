using System;

class BubbleSort
{
    static void Main()
    {
        int[] marks = { 3, 2, 5, 4, 80, 21 };
        Console.WriteLine("Original Array:- ");
        PrintArray(marks);
        Sort(marks);
        Console.WriteLine("Sorted array:- ");
        PrintArray(marks);
    }

    public static void Sort(int[] marks)
    {
        bool isSwapped = false;
        int n = marks.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (marks[j] > marks[j + 1])
                {
                    int temp = marks[j];
                    marks[j] = marks[j + 1];
                    marks[j + 1] = temp;
                    isSwapped = true;
                }
            }
            if (!isSwapped)
            {
                return;
            }
        }
    }

    public static void PrintArray(int[] marks)
    {
        foreach (int i in marks)
        {
            Console.WriteLine("Marks:- " + i);
        }
        Console.WriteLine();
    }
}
