using System;

class CountingSort
{
    static void Main()
    {
        int[] age = { 15, 12, 18, 14, 10, 13, 16, 12, 11 };
        Console.WriteLine("Original array:- ");
        Print(age);
        Sort(age);
        Console.WriteLine("Sorted array:- ");
        Print(age);
    }

    public static void Sort(int[] age)
    {
        int n = age.Length;

        int max = age[0];
        int min = age[0];
        for (int i = 1; i < n; i++)
        {
            max = age[i] > max ? age[i] : max;
            min = age[i] < min ? age[i] : min;
        }
        int[] count = new int[max - min + 1];
        for (int i = 0; i < n; i++)
        {
            count[age[i] - min]++;
        }
        for (int i = 1; i < (max - min + 1); i++)
        {
            count[i] += count[i - 1];
        }
        int[] ans = new int[n];
        for (int i = n - 1; i >= 0; i--)
        {
            ans[--count[age[i] - min]] = age[i];
        }
        Array.Copy(ans, age, age.Length);
    }

    public static void Print(int[] age)
    {
        foreach (double i in age)
        {
            Console.WriteLine("age:- " + i);
        }
        Console.WriteLine();
    }
}
