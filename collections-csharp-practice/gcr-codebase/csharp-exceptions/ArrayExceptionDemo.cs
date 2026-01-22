using System;

class ArrayExceptionDemo
{
    static void Main()
    {
        try
        {
            int[] numbers = { 10, 20, 30 };

            Console.Write("Enter index: ");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Value at index {index}: {numbers[index]}");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid index!");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Array is not initialized!");
        }
    }
}
