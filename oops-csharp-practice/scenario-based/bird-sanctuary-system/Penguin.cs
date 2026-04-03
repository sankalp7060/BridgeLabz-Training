using System;

class Penguin : Bird, ISwimmable
{
    public Penguin(string name)
        : base(name, "Penguin") { }

    public void Swim()
    {
        Console.WriteLine("I can swim");
    }
}
