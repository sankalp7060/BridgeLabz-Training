using System;

class TripInfo{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter name: ");
        string name = Console.ReadLine(); //User name
        Console.Write("Enter fromCity: ");
        string fromCity = Console.ReadLine(); //user's city
        Console.Write("Enter viaCity: ");
        string viaCity = Console.ReadLine(); //User's via city
        Console.Write("Enter toCity: ");
        string toCity = Console.ReadLine(); //User's destination city
        Console.Write("Enter distance from fromCity to viaCity (miles): ");
        double fromToVia = double.Parse(Console.ReadLine()); //User's from to via city
        Console.Write("Enter distance from viaCity to toCity (miles): ");
        double viaToFinalCity = double.Parse(Console.ReadLine()); //User's vis to final city
        Console.Write("Enter total time taken (hours): ");
        double timeTaken = double.Parse(Console.ReadLine()); //Time taken to reach final city
        Console.WriteLine("The results of the trip are: " + name + ", " + fromCity + " to " + toCity + " via " + viaCity + ", total distance " + (fromToVia + viaToFinalCity) + " miles in " + timeTaken + " hours"); //Output
    }
}
