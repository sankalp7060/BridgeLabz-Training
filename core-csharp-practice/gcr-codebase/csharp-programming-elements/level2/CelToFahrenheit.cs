using System;

class CelToFahrenheit{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter temperature in Celsius: ");
        double celsius = double.Parse(Console.ReadLine()); //user given temperature on celsius
        double fahrenheitResult = (celsius * 9 / 5) + 32; //Formula to convert celsius to fahrenheit
        Console.WriteLine("The " + celsius + " Celsius is " + fahrenheitResult + " Fahrenheit"); //Output
    }
}
