using System;

interface IFly
{
    void Fly();
}

interface ISwim
{
    void Swim();
}

class Duck : IFly, ISwim
{
    public void Fly() => Console.WriteLine("Duck flying");

    public void Swim() => Console.WriteLine("Duck swimming");
}

class MultipleInheritance
{
    static void Main()
    {
        Duck d = new Duck();
        d.Fly();
        d.Swim();
    }
}
