using System;

class Parent
{
    public Parent()
    {
        Console.WriteLine("Parent constructor");
    }
}

class Child : Parent
{
    public Child()
        : base()
    {
        Console.WriteLine("Child constructor");
    }
}

class Constructor
{
    static void Main()
    {
        Child c = new Child();
    }
}
