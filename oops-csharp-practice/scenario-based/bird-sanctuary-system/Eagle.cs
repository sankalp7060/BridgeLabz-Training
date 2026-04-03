using System;

class Eagle : Bird, IFlyable
{
    public Eagle(string name)
        : base(name, "Eagle") { }

    public void Fly()
    {
        Console.WriteLine("I can fly");
    }
}
