using System;

class TemperatureConverter{
    static void Main(){
        Console.WriteLine("Enter temperature value:- ");
        double temp = double.Parse(Console.ReadLine());

        Console.WriteLine("Choose conversion:");
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");

        int choice = int.Parse(Console.ReadLine());

        if(choice == 1)
            Console.WriteLine("Result: " + CelsiusToFahrenheit(temp));
        else
            Console.WriteLine("Result: " + FahrenheitToCelsius(temp));
    }

    // Converts Celsius to Fahrenheit
    static double CelsiusToFahrenheit(double c){
        return (c * 9 / 5) + 32;
    }

    // Converts Fahrenheit to Celsius
    static double FahrenheitToCelsius(double f){
        return (f - 32) * 5 / 9;
    }
}
