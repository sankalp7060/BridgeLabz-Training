using System;

class Shape
{
    public virtual void Draw() => Console.WriteLine("Drawing shape");
}

class Circle : Shape
{
    public override void Draw() => Console.WriteLine("Drawing circle");
}

class Shapes
{
    static void Main()
    {
        Shape s = new Circle();
        s.Draw();
    }
}
