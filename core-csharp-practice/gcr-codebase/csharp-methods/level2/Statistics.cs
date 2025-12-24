using System;

class Statistics{
    //Main()
    static void Main(){
        int[] numbers = Generate4DigitRandomArray(5); //Generate random numbers
        double[] result = FindAverageMinMax(numbers); //Find average, min and max

        Console.WriteLine("Average value:- " + result[0]);
        Console.WriteLine("Minimum value:- " + result[1]);
        Console.WriteLine("Maximum value:- " + result[2]);
    }

    //Method to generate array of 4 digit random numbers
    static int[] Generate4DigitRandomArray(int size){
        int[] randomNumbers = new int[size];
        Random random = new Random();

        for(int i = 0; i < size; i++){
            randomNumbers[i] = random.Next(1000, 10000); //Generate 4 digit number
        }

        return randomNumbers; //Return array
    }

    //Method to find average, minimum and maximum
    static double[] FindAverageMinMax(int[] numbers){
        int sum = 0;
        int min = numbers[0];
        int max = numbers[0];

        foreach(int number in numbers){
            sum += number; //Calculate sum
            min = Math.Min(min, number); //Find minimum
            max = Math.Max(max, number); //Find maximum
        }

        double average = (double)sum / numbers.Length; //Calculate average
        return new double[]{ average, min, max }; //Return result
    }
}
