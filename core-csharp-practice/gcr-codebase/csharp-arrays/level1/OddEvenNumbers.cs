using System;

class OddEvenNumbers{
    //Main()
    static void Main(){
        // User given number n
        Console.Write("Enter a natural number:- ");
        int n = int.Parse(Console.ReadLine());

        // Validate natural number
        if (n <= 0){
            Console.WriteLine("Invalid input. Enter a natural number.");
            return;
        }

        // Create arrays for odd and even numbers
        int[] oddNumbers = new int[n / 2 + 1];
        int[] evenNumbers = new int[n / 2 + 1];

        // Index variables to keep track of odd and even array's elements
        int oddIndex = 0;
        int evenIndex = 0;

        // Loop from 1 to the given number
        for (int i = 1; i <= n; i++){
            // Check if number is even
            if (i % 2 == 0){
                evenNumbers[evenIndex] = i;
                evenIndex++;
            }
            // Otherwise, number is odd
            else{
                oddNumbers[oddIndex] = i;
                oddIndex++;
            }
        }

        // Display odd numbers
        Console.WriteLine("\nOdd Numbers:");
        for (int i = 0; i < oddIndex; i++){
            Console.Write(oddNumbers[i] + " ");
        }

        // Display even numbers
        Console.WriteLine("\n\nEven Numbers:");
        for (int i = 0; i < evenIndex; i++){
            Console.Write(evenNumbers[i] + " ");
        }
    }
}
