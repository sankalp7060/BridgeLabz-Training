using System;

class SecondLargestElementInArray
{
    static void Main()
    {
        int[] arr = { 2, 0, 8, 98, 567, 4, 5, 3, 45678, 1 };
        int secondMax = FindSecondLargest(arr);
        Console.WriteLine("The second maximum element: " + secondMax);
    }

    public static int FindSecondLargest(int[] arr)
    {
        int max1 = int.MinValue;
        int max2 = int.MinValue;

        foreach (int i in arr)
        {
            if (i > max1)
            {
                max2 = max1;
                max1 = i;
            }
            else if (i > max2 && i != max1)
            {
                max2 = i;
            }
        }

        return max2;
    }
}
