using System;

class WindChillTemp{
    //Main()
    static void Main(){
        Console.WriteLine("Enter temperature (F):- ");
        double temp = double.Parse(Console.ReadLine()); //User input temperature
        Console.WriteLine("Enter wind speed (mph):- ");
        double windSpeed = double.Parse(Console.ReadLine()); //User input wind speed
        double windChill = CalculateWindChill(temp, windSpeed); //Call method to calculate wind chill
        Console.WriteLine("Wind Chill Temperature:- " + windChill); //Output
    }

    //Method to calculate wind chill temperature
    static double CalculateWindChill(double temperature, double windSpeed){

        //Formula to check for wind chill temperature
        double windChill = 35.74 + 0.6215 * temperature + (0.4275 * temperature - 35.75) * Math.Pow(windSpeed, 0.16); 
        return windChill; //return result
    }
}
