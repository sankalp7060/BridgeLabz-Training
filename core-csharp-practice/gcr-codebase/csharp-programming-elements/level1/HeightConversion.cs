using System;

class HeightConversion{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter height in cm: ");
        double cm = double.Parse(Console.ReadLine()); //User given height in centimetre
        double inches = cm / 2.54; //Formula to convert centimetre to inches
        int feet = (int)(inches / 12); //formula to convert inchesto feet
        double remainingInches = inches % 12; //Formula to calculate inches
        Console.WriteLine($"Your Height in cm is {cm} while in feet is {feet} and inches is {remainingInches}"); //Output
    }
}
