using System;
using System.IO;

class CountRowsCSV
{
    static void Main()
    {
        string file = "employees.csv";

        var lines = File.ReadAllLines(file);

        Console.WriteLine("Total Records = " + (lines.Length - 1));
    }
}
