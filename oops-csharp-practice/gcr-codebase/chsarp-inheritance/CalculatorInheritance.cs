using System;

class Calculator
{
    public virtual int Add(int a, int b) => a + b;
}

class SafeCalculator : Calculator
{
    public override int Add(int a, int b) => base.Add(a, b);
}

class CalculatorInheritance
{
    static void Main()
    {
        Calculator c = new SafeCalculator();
        Console.WriteLine(c.Add(2, 3));
    }
}
