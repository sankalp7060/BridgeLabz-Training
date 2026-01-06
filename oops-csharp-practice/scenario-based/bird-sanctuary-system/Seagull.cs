using System;

class Seagull : Bird, IFlyable, ISwimmable
{
    public Seagull(string name)
        : base(name, "Seagull") { }

    public void Fly()
    {
        Console.WriteLine("I can fly");
    }

    public void Swim()
    {
        Console.WriteLine("I can swim");
    }
}
