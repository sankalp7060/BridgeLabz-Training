using System;

class Sparrow : Bird, IFlyable
{
    public Sparrow(string name)
        : base(name, "Sparrow") { }

    public void Fly()
    {
        Console.WriteLine("I can fly");
    }
}
