using System;

class UnitConverter2{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the yards:- ");
        double yards = double.Parse(Console.ReadLine()); //User given yards value

        double yardsToFeet = ConvertYardsToFeet(yards); //Conversion of yards to feet
        double feetToYards = ConvertFeetToYards(yardsToFeet); //Conversion of feet to yards
        double metersToInches = ConvertMetersToInches(1); //Conversion of meters to inches
        double inchesToMeters = ConvertInchesToMeters(metersToInches); //Conversion of inches to meters
        double inchesToCm = ConvertInchesToCentimeters(metersToInches); //Conversion of inches to centimeters

        Console.WriteLine("Yards to Feet:- " + yardsToFeet);
        Console.WriteLine("Feet to Yards:- " + feetToYards);
        Console.WriteLine("Meters to Inches:- " + metersToInches);
        Console.WriteLine("Inches to Meters:- " + inchesToMeters);
        Console.WriteLine("Inches to Centimeters:- " + inchesToCm);
    }

    //Method to convert yards to feet
    static double ConvertYardsToFeet(double yards){
        return yards * 3;
    }

    //Method to convert feet to yards
    static double ConvertFeetToYards(double feet){
        return feet * 0.333333;
    }

    //Method to convert meters to inches
    static double ConvertMetersToInches(double meters){
        return meters * 39.3701;
    }

    //Method to convert inches to meters
    static double ConvertInchesToMeters(double inches){
        return inches * 0.0254;
    }

    //Method to convert inches to centimeters
    static double ConvertInchesToCentimeters(double inches){
        return inches * 2.54;
    }
}
