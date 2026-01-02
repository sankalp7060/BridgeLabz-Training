using System;

class Bird
{
    public virtual void Fly() => Console.WriteLine("Bird flying");
}

class Sparrow : Bird
{
    public override void Fly() => Console.WriteLine("Sparrow flying");
}

class SparrowBird
{
    static void Main()
    {
        Bird bird = new Sparrow(); // substitutable
        bird.Fly();
    }
}
