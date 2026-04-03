using System;
using System.IO;

class SearchEmployee
{
    static void Main()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        var lines = File.ReadAllLines("employees.csv");

        foreach (var line in lines)
        {
            if (line.Contains(name))
            {
                var d = line.Split(',');
                Console.WriteLine($"Department: {d[2]} Salary: {d[3]}");
            }
        }
    }
}
