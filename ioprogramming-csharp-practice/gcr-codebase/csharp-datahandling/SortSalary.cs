using System;
using System.IO;
using System.Linq;

class SortSalary
{
    static void Main()
    {
        var lines = File.ReadAllLines("employees.csv").Skip(1);

        var sorted = lines.OrderByDescending(x => int.Parse(x.Split(',')[3]));

        foreach (var emp in sorted.Take(5))
            Console.WriteLine(emp);
    }
}
