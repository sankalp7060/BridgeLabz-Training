using System;

public class Kilometers_To_Miles{
    // Main
    public static void Main(string[] args){
        Console.WriteLine("Enter Kilometers:- ");
        int KM = int.Parse(Console.ReadLine()); // Kilometer input
        double miles = KM * 0.621371; // calculate kilometers to miles
        Console.Write(miles); // output
    }
}
