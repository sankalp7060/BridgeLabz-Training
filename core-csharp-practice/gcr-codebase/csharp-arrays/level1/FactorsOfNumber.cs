using System;

class FactorsOfNumber{
    //Main()
    static void Main(){
        // User given number n
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        // Initial maximum size of factors array
        int maxFactor = 10;

        // Array to store factors
        int[] arr = new int[maxFactor];

        // Index to track number of factors
        int index = 0;

        // Loop to find factors
        for (int i = 1; i <= n; i++){
            // Check if i is a factor of number
            if (n % i == 0){
                // If array is full, increase its size
                if (index == maxFactor){
                    maxFactor = maxFactor * 2;

                    // Create temporary array with increased size
                    int[] temp = new int[maxFactor];

                    // Copy old array values to new array
                    Array.Copy(arr, temp, arr.Length);

                    // Assign new array back to factors
                    arr = temp;
                }

                // Store factor in array
                arr[index] = i;
                index++;
            }
        }

        // Display factors
        Console.WriteLine("\nFactors of the number:");
        for (int i = 0; i < index; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
}
