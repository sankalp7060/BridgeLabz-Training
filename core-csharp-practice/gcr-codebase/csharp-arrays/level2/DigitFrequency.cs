using System;

class DigitFrequency{
    //Main()
    static void Main(){
        Console.Write("Enter a number:- ");
        long num = long.Parse(Console.ReadLine()); //User given number

        int[] digits = new int[20]; //Int array to store each digit of a number n
        int index = 0;
        long temp = num;

        // Extract digits and store them in digits array
        while (temp != 0){
            digits[index++] = (int)(temp % 10);
            temp /= 10;
        }

        // Frequency array for digits 0-9
        int[] frequency = new int[10];

        // Find the frequency of each digit and store the frequency in the frequency array
        for (int i = 0; i < index; i++){
            frequency[digits[i]]++;
        }

        Console.WriteLine("\nDigit  Frequency:- ");
        for (int i = 0; i < 10; i++){
            if (frequency[i] > 0)
                Console.WriteLine($"{i}      {frequency[i]}");
        }
    }
}
