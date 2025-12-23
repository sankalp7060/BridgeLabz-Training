using System;

class StoreNumbersAndSum{
    //Main()
    static void Main(){
        // Double array to store maximum 10 numbers
        double[] arr = new double[10];

        // Variable to calculate sum of numbers
        double total = 0.0;

        // Index i to track array position
        int i = 0;

        // Infinite loop
        while (true){
            Console.Write("Enter a number: ");
            double ele = double.Parse(Console.ReadLine()); //Element input from user

            // Break loop if element is 0 or less than 0
            if (ele <= 0)
                break;

            // Break if array size reaches limit
            if (i == 10)
                break;

            // Store element value in array
            arr[i] = ele;

            // Increment index
            i++;
        }

        Console.WriteLine("\nStored Numbers:");

        // Calculate sum using loop
        for (int j = 0; j < i; j++){
            Console.WriteLine(arr[j]);
            total += arr[j];
        }

        // Display total sum
        Console.WriteLine($"Total Sum = {total}");
    }
}
