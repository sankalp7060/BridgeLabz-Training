using System;

public class Average_Of_Three_Numbers{
    // Main
    public static void Main(string[] args){
        Console.WriteLine("Enter three numbers:- ");
        int num1 = int.Parse(Console.ReadLine()); // take number 1
        int num2 = int.Parse(Console.ReadLine()); // take number 2
        int num3 = int.Parse(Console.ReadLine()); // take number 3
        double average = (num1 + num2 + num3) / 3.0; // calculate average of three numbers
        Console.Write("Average of three numbers:- " + average); // output
    }
}
