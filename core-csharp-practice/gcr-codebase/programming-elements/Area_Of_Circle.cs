using System;

class Area_Of_Circle{
    public static void Main(string[] args){
        Console.WriteLine("Enter the radius:- ");
        double radius = double.Parse(Console.ReadLine()); // radius input from user
        double area = Math.PI * radius * radius; // variable to store the area of circle
        Console.WriteLine("Area of circle:- " + area); // display the area of circle
    }
}
