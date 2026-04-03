using System;

class UnitConverter1{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the kilometers:- ");
        double km = double.Parse(Console.ReadLine()); //User given kilometer value
        double kmToMiles = ConvertKmToMiles(km); //Conversion of kilometers to miles
        double milesToKM = ConvertMilesToKm(kmToMiles); //Conversion of miles to kilometers
        double kmToMeters = km * 1000; //Conversion of kilometers into meters
        double meterToFeet = ConvertMetersToFeet(kmToMeters); //Conversion of meters to feet
        double feetToMeters = ConvertFeetToMeters(meterToFeet); //Conversion of feet to meters

        Console.WriteLine("Kilometers to Miles:- "+ kmToMiles);
        Console.WriteLine("Miles to Kilometers:- "+ milesToKM);
        Console.WriteLine("Meters to feets:- "+meterToFeet);
        Console.WriteLine("Feet to meters:- "+ feetToMeters);
    }

    //Method to convert kilometers to miles
    static double ConvertKmToMiles(double km){
        return km * 0.621371;
    }

    //Method to convert miles to kilometers
    static double ConvertMilesToKm(double miles){
        return miles * 1.60934;
    }

    //Method to convert meters to feet
    static double ConvertMetersToFeet(double meters){
        return meters * 3.28084;
    }

    //Method to convert feet to meters
    static double ConvertFeetToMeters(double feet){
        return feet * 0.3048;
    }
}
