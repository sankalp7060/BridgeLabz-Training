using System;
using System.Reflection;

class DynamicMethodInvocation
{
    static void Main()
    {
        MathOperations math = new MathOperations();
        Type type = typeof(MathOperations);

        Console.Write("Enter method name (Add/Subtract/Multiply): ");
        string methodName = Console.ReadLine();

        MethodInfo method = type.GetMethod(methodName);
        if (method != null)
        {
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            object result = method.Invoke(math, new object[] { a, b });
            Console.WriteLine("Result: " + result);
        }
        else
        {
            Console.WriteLine("Method not found!");
        }
    }
}

public class MathOperations
{
    public int Add(int a, int b) => a + b;

    public int Subtract(int a, int b) => a - b;

    public int Multiply(int a, int b) => a * b;
}
