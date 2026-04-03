using System;
using System.Reflection;

class InvokePrivateMethod
{
    static void Main()
    {
        Calculator calc = new Calculator();
        Type type = typeof(Calculator);

        // Access private method
        MethodInfo multiplyMethod = type.GetMethod(
            "Multiply",
            BindingFlags.NonPublic | BindingFlags.Instance
        );

        // Invoke method
        object result = multiplyMethod.Invoke(calc, new object[] { 6, 7 });
        Console.WriteLine("Result: " + result);
    }
}

public class Calculator
{
    private int Multiply(int a, int b)
    {
        return a * b;
    }
}
