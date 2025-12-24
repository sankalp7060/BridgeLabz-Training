using System;

class UnitConverter3{
    //Main()
    static void Main(){
        Console.WriteLine("Enter temperature in Fahrenheit:- ");
        double fahrenheit = double.Parse(Console.ReadLine()); //User given temperature

        double fahrenheitToCelsius = ConvertFahrenheitToCelsius(fahrenheit); //F to C
        double celsiusToFahrenheit = ConvertCelsiusToFahrenheit(fahrenheitToCelsius); //C to F

        Console.WriteLine("Fahrenheit to Celsius:- " + fahrenheitToCelsius);
        Console.WriteLine("Celsius to Fahrenheit:- " + celsiusToFahrenheit);
    }

    //Method to convert Fahrenheit to Celsius
    static double ConvertFahrenheitToCelsius(double fahrenheit){
        return (fahrenheit - 32) * 5 / 9;
    }

    //Method to convert Celsius to Fahrenheit
    static double ConvertCelsiusToFahrenheit(double celsius){
        return (celsius * 9 / 5) + 32;
    }
}
