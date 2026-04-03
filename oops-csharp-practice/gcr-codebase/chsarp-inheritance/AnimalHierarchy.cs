using System;

class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Cat meows");
    }
}

class Bird : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Bird chirps");
    }
}

class Animalhierarchy
{
    static void Main()
    {
        Animal[] animals =
        {
            new Dog { Name = "Bruno", Age = 3 },
            new Cat { Name = "Kitty", Age = 2 },
            new Bird { Name = "Tweety", Age = 1 },
        };

        foreach (Animal a in animals)
            a.MakeSound();
    }
}
