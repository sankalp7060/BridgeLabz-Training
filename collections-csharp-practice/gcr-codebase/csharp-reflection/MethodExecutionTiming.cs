using System;
using System.Diagnostics;
using System.Reflection;

class MethodExecutionTiming
{
    static void Main()
    {
        Type type = typeof(MathOperations);

        object obj = Activator.CreateInstance(type)!; // null-forgiving operator

        foreach (
            var method in type.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly
            )
        ) // IMPORTANT
        {
            var parameters = method.GetParameters();

            // Filter only methods with 2 int parameters
            if (
                parameters.Length == 2
                && parameters[0].ParameterType == typeof(int)
                && parameters[1].ParameterType == typeof(int)
            )
            {
                Stopwatch sw = Stopwatch.StartNew();

                method.Invoke(obj, new object[] { 10, 5 });

                sw.Stop();

                Console.WriteLine($"{method.Name} executed in {sw.ElapsedTicks} ticks");
            }
        }
    }
}

public class MathOperations
{
    public int Add(int a, int b) => a + b;

    public int Subtract(int a, int b) => a - b;

    public int Multiply(int a, int b) => a * b;
}
