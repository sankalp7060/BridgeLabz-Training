using System;

public class Power_Calculation{
    // Main
    public static void Main(string[] args){
        Console.WriteLine("Enter Base:- ");
        int baseValue = int.Parse(Console.ReadLine()); // take base
        Console.WriteLine("Enter Exponent:- ");
        int exponent = int.Parse(Console.ReadLine()); // take exponent
        long result = 1;
        for (int i = 1; i <= exponent; i++) // calculate power
        {
            result = result * baseValue;
        }
        Console.Write(result); // output
    }
}
