using System;

class Celsius_To_Fahrenheit{
    //Main
    public static void Main(string[] args){
        double celsius = double.Parse(Console.ReadLine()); // Take celsius input from user
        double fahrenheit = ((9.0 / 5) * celsius) + 32; // variable to store the result
        Console.Write(fahrenheit); // output
    }
}
