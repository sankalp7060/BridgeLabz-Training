using System;

class FeetToYardAndMiles{
    static void Main(String[] args){
        Console.Write("Enter distance in feet: ");
        double feet = double.Parse(Console.ReadLine()); //User given feet value
        double yards = feet / 3; //Formula to calculate yard
        double miles = yards / 1760; //Formula to calculate miles
        Console.WriteLine($"Distance in yards is {yards} and in miles is {miles}"); //Output
    }
}
