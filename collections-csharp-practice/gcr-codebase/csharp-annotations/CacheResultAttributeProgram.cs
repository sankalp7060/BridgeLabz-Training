using System;
using System.Collections.Generic;

[AttributeUsage(AttributeTargets.Method)]
class CacheResultAttribute : Attribute { }

class Calculator
{
    static Dictionary<int, int> cache = new Dictionary<int, int>();

    [CacheResult]
    public int Square(int x)
    {
        if (cache.ContainsKey(x))
        {
            Console.WriteLine("From Cache");
            return cache[x];
        }

        Console.WriteLine("Computing...");
        int result = x * x;
        cache[x] = result;

        return result;
    }
}

class CacheResultAttributeProgram
{
    static void Main()
    {
        Calculator c = new Calculator();

        Console.WriteLine(c.Square(5));
        Console.WriteLine(c.Square(5));
    }
}
