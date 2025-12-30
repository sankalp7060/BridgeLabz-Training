using System;

class Circle
{
    double radius;

    public Circle()
        : this(1.0) { }

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double Area()
    {
        return Math.PI * radius * radius;
    }

    static void Main()
    {
        Circle c1 = new Circle();
        Circle c2 = new Circle(5);

        Console.WriteLine(c1.Area());
        Console.WriteLine(c2.Area());
    }
}
