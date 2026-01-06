using System;

class Duck : Bird, ISwimmable
{
    public Duck(string name)
        : base(name, "Duck") { }

    public void Swim()
    {
        Console.WriteLine("I can swim");
    }
}
