using System;
using System.IO;

class FilterStudents
{
    static void Main()
    {
        var lines = File.ReadAllLines("students.csv");

        for (int i = 1; i < lines.Length; i++)
        {
            var data = lines[i].Split(',');

            int marks = int.Parse(data[3]);

            if (marks > 80)
                Console.WriteLine(lines[i]);
        }
    }
}
