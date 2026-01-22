using System;

class ExceptionPropagationDemo
{
    static void Method1()
    {
        int result = 10 / 0;
    }

    static void Method2()
    {
        Method1();
    }

    static void Main()
    {
        try
        {
            Method2();
        }
        catch (ArithmeticException)
        {
            Console.WriteLine("Handled exception in Main");
        }
    }
}
