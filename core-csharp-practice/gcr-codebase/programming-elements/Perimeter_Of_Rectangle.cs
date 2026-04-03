using System;

public class Perimeter_Of_Rectangle{
    // Main
    public static void Main(string[] args){
        Console.WriteLine("Enter length:- ");
        int length = int.Parse(Console.ReadLine()); // length input
        Console.WriteLine("Enter breadth:- ");
        int breadth = int.Parse(Console.ReadLine()); // breadth input
        double perimeter = 2 * (length + breadth); // calculate perimeter of rectangle
        Console.Write("Perimeter of Rectangle:- " + perimeter); // output
    }
}
