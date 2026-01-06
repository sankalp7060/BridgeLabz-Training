using System;

abstract class Bird
{
    public string Name { get; private set; }
    public string Species { get; private set; }

    public Bird(string name, string species)
    {
        Name = name;
        Species = species;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Name:- {Name}, Species:- {Species}");
    }
}
