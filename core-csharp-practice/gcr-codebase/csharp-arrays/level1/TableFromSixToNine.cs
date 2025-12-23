using System;

class TableFromSixToNine{
    //Main()
    static void Main(){
        // User given number n
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        // Array to store multiplication results
        int[] arr = new int[4];

        int index = 0;

        // Loop from 6 to 9 to calculate multiplication
        for (int i = 6; i <= 9; i++){
            // Store multiplication result in array
            arr[index] = n * i;

            // Move to next index
            index++;
        }

        Console.WriteLine("\nMultiplication Table from 6 to 9:");

        // Reset index to display results
        index = 0;

        // Loop again to display the results
        for (int i = 6; i <= 9; i++){
            Console.WriteLine($"{n} * {i} = {arr[index]}");
            index++;
        }
    }
}
