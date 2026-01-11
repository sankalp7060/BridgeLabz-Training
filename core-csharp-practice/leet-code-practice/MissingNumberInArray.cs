using System;

class MissingNumberInArray
{
    static void Main()
    {
        int[] arr = { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
        int num = MissingNumber(arr);
        Console.WriteLine("Missing Number is:- " + num);
    }

    static int MissingNumber(int[] arr)
    {
        int n = arr.Length;
        int totalSum = (n * (n + 1)) / 2;
        int elementSum = 0;
        foreach (int i in arr)
        {
            elementSum += i;
        }
        return (totalSum - elementSum);
    }
}
