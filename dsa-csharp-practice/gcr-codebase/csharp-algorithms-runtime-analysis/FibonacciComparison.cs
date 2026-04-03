using System;
using System.Diagnostics;

class FibonacciComparison
{
    static void Main()
    {
        int n = 30;

        Stopwatch sw = Stopwatch.StartNew();
        Console.WriteLine($"Recursive: {FibonacciRecursive(n)}");
        sw.Stop();
        Console.WriteLine($"Recursive Time: {sw.ElapsedMilliseconds} ms");

        sw.Restart();
        Console.WriteLine($"Iterative: {FibonacciIterative(n)}");
        sw.Stop();
        Console.WriteLine($"Iterative Time: {sw.ElapsedMilliseconds} ms");
    }

    static int FibonacciRecursive(int n)
    {
        if (n <= 1)
            return n;
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    static int FibonacciIterative(int n)
    {
        if (n <= 1)
            return n;
        int a = 0,
            b = 1;
        for (int i = 2; i <= n; i++)
            (a, b) = (b, a + b);
        return b;
    }
}
