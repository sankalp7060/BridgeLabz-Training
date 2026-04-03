using System;

class AthleteRun{
    static void Main(String[] args){
        Console.Write("Enter side1 (m): ");
        double side1 = double.Parse(Console.ReadLine()); //length of first side of triangle
        Console.Write("Enter side2 (m): ");
        double side2 = double.Parse(Console.ReadLine()); //length of second side of triangle
        Console.Write("Enter side3 (m): ");
        double side3 = double.Parse(Console.ReadLine()); ///length of third side of triangle
        double perimeter = side1 + side2 + side3; //Calculate perimerter
        double totalDistance = 5000; //Total distance in meter
        double rounds = totalDistance / perimeter; //Total rounds of athlete
        Console.WriteLine("The total number of rounds the athlete will run is " + rounds + " to complete 5 km"); //Output
    }
}
