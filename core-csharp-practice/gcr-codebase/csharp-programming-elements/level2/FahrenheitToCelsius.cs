using System;

class FahrenheitToCelsius{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter temperature in Fahrenheit: ");
        double fahrenheit = double.Parse(Console.ReadLine()); //User given temperature in fahrenheit
        double celsiusResult = (fahrenheit - 32) * 5 / 9; //Formula to convert fahrenheit to celsius
        Console.WriteLine("The " + fahrenheit + " Fahrenheit is " + celsiusResult + " Celsius"); //Output
    }
}
