using System;

class AreaOfTriangle{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter base: ");
        double baseVal = double.Parse(Console.ReadLine()); //Base of a triangle
        Console.Write("Enter height: ");
        double height = double.Parse(Console.ReadLine()); //Height of a traingle
        double area = 0.5 * baseVal * height; //formula to Calculate area of triangle
        double areaInCm = area * 6.4516; //formula to calculate area in centimetre
        Console.WriteLine($"Area in square inches is {area} and square centimeters is {areaInCm}"); //Output
    }
}
