using System;

class Volume_Of_Cylinder{
    // Main
    public static void Main(string[] args){
        Console.WriteLine("Enter Radius:- ");
        int radius = int.Parse(Console.ReadLine()); // take radius
        Console.WriteLine("Enter Height:- ");
        int height = int.Parse(Console.ReadLine()); // take height
        double volume = Math.PI * radius * radius * height; // calculate volume of cylinder
        Console.Write("Volume of cylinder:- " + volume); // output
    }
}
