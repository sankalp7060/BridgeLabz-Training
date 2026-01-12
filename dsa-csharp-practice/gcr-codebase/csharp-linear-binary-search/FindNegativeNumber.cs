using System;

class FindNegativeNumber
{
    static void Main()
    {
        int[] arr = { 4, 2, -5, 7 };
        foreach (int x in arr)
        {
            if (x < 0)
            {
                Console.WriteLine(x);
                return;
            }
        }
        Console.WriteLine("No negative number");
    }
}
