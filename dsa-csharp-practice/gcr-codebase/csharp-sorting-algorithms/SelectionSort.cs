using System;

class SelectionSort
{
    static void Main()
    {
        int[] scores = { 72, 88, 64, 91, 56, 79 };
        Console.WriteLine("Original Array:- ");
        PrintArray(scores);
        Sort(scores);
        Console.WriteLine("Sorted array:- ");
        PrintArray(scores);
    }

    public static void Sort(int[] scores)
    {
        int n = scores.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (scores[j] < scores[minIndex])
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                int temp = scores[i];
                scores[i] = scores[minIndex];
                scores[minIndex] = temp;
            }
        }
    }

    public static void PrintArray(int[] scores)
    {
        foreach (int i in scores)
        {
            Console.WriteLine("Scores:- " + i);
        }
        Console.WriteLine();
    }
}
