using System;

class MultiplicationTable{
    //Main()
    static void Main(){
        // User given number
        Console.Write("Enter a number: ");
        int arr = int.Parse(Console.ReadLine());

        // Integer array to store multiplication results
        int[] table = new int[10];

        // Loop from 1 to 10
        for (int i = 1; i <= 10; i++){
            // Store result in array
            table[i - 1] = arr * i;

            // Display the result
            Console.WriteLine($"{arr} * {i} = {table[i - 1]}");
        }
    }
}
