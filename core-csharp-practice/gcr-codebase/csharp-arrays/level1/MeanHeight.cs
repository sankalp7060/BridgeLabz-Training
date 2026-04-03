using System;

class MeanHeight{
    //Main()
    static void Main(){
        // Double array to store heights of 11 players
        double[] arr = new double[11];

        // Variable to store sum of heights
        double sum = 0.0;

        Console.WriteLine("Enter heights of 11 football players:");

        // User given players
        for (int i = 0; i < arr.Length; i++){
            Console.Write($"Player {i + 1} height: ");
            arr[i] = double.Parse(Console.ReadLine());

            // Add height to sum
            sum += arr[i];
        }

        // Calculate mean height
        double meanHeight = sum / arr.Length;

        // Display the result
        Console.WriteLine($"\nMean Height of Football Team = {meanHeight}");
    }
}
