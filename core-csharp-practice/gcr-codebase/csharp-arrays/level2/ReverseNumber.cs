using System;

class ReverseNumber{
    //Main()
    static void Main(){
        Console.Write("Enter a number: ");
        long num = long.Parse(Console.ReadLine()); //User given number

        // Find digits and store in array
        int[] digits = new int[20]; // assuming max 20 digits
        int index = 0; //Index to keep the track of the array index
        long temp = num;

        //Store every digits of a number in an array
        while (temp != 0){
            digits[index] = (int)(temp % 10);
            temp /= 10;
            index++;
        }

        // Display number in reverse
        Console.WriteLine("\nNumber in Reverse:");
        for (int i = 0; i < index; i++){
            Console.Write(digits[i]);
        }
        Console.WriteLine();
    }
}
