using System;

class Circle
{
    // Attribute
    public double Radius;

    // Method to calculate area
    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    // Method to calculate circumference
    public double CalculateCircumference()
    {
        return 2 * Math.PI * Radius;
    }

    // Method to display area and circumference
    public void Display()
    {
        Console.WriteLine("Circle Details:");
        Console.WriteLine("Radius: " + Radius);
        Console.WriteLine("Area: " + CalculateArea());
        Console.WriteLine("Circumference: " + CalculateCircumference());
    }
}

class AreaOfCircle
{
    static void Main()
    {
        Circle circle = new Circle();

        Console.Write("Enter Radius of Circle: ");
        circle.Radius = double.Parse(Console.ReadLine());

        circle.Display();
    }
}
