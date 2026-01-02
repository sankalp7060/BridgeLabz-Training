using System;

class Animal
{
    public virtual void Speak() => Console.WriteLine("Animal sound");
}

class Dog : Animal // Dog IS-A Animal
{
    public override void Speak() => Console.WriteLine("Dog barks");
}

class AnimalDog
{
    static void Main()
    {
        Animal a = new Dog();
        a.Speak();
    }
}
