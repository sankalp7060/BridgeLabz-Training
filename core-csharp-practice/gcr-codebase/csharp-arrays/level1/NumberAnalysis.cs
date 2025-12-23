using System;

class NumberAnalysis{
    //Main()
    static void Main(){
        // Integer array of size 5
        int[] arr = new int[5];

        Console.WriteLine("Enter 5 numbers:- ");

        // User given input
        for (int i = 0; i < arr.Length; i++){
            arr[i] = int.Parse(Console.ReadLine());
        }

        // Analyze each number using loop
        for (int i = 0; i < arr.Length; i++){
            int num = arr[i];

            // Check for positive number
            if (num > 0)
            {
                // Check even or odd positive number
                if (num % 2 == 0)
                    Console.WriteLine($"{num} is Positive and Even");
                else
                    Console.WriteLine($"{num} is Positive and Odd");
            }
            // Check for negative number
            else if (num < 0){
                Console.WriteLine($"{num} is Negative");
            }
            // Check for zero number
            else{
                Console.WriteLine($"{num} is Zero");
            }
        }

        // Compare first and last element of array
        Console.WriteLine("\nComparison of first and last elements:");

        if (arr[0] == arr[arr.Length - 1])
            Console.WriteLine("First and last elements are Equal");
        else if (arr[0] > arr[arr.Length - 1])
            Console.WriteLine("First element is Greater");
        else
            Console.WriteLine("Last element is Greater");
    }
}
