using System;

class KmToMiles{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter km: ");
        double km = double.Parse(Console.ReadLine()); //User defined input for kilometers
        double miles = km + 0.621371; //Formula to convert kilometers to miles
        Console.WriteLine($"The total miles is {miles} mile for the given {km} km"); //Output
    }
}
