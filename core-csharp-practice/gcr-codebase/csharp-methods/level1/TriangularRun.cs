using System;

class TriangularRun{
    //Main()
    static void Main(){
        Console.WriteLine("Enter side1 of triangle in meters:- ");
        double side1 = double.Parse(Console.ReadLine()); //User input side1
        Console.WriteLine("Enter side2 of triangle in meters:- ");
        double side2 = double.Parse(Console.ReadLine()); //User input side2
        Console.WriteLine("Enter side3 of triangle in meters:- ");
        double side3 = double.Parse(Console.ReadLine()); //User input side3
        double rounds = CalculateRounds(side1, side2, side3); //Call method to calculate rounds
        Console.WriteLine("Rounds to complete 5 km run:- " + rounds); //Output
    }

    //Method to calculate number of rounds
    static double CalculateRounds(double a, double b, double c){
        double perimeter = a + b + c; //Perimeter of triangle
        double distance = 5000; //5 km in meters
        double rounds = distance / perimeter; //Calculate number of rounds
        return rounds; //return result
    }
}
