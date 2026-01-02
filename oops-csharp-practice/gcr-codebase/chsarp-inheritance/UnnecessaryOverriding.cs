using System;

class Base
{
    public virtual void Show() => Console.WriteLine("Base show");
}

class Derived : Base
{
    // No override needed
}

class UnnecessaryOverriding
{
    static void Main()
    {
        Base b = new Derived();
        b.Show();
    }
}
