using System;
using System.Collections.Generic;
using System.IO;

class DetectDuplicates
{
    static void Main()
    {
        var lines = File.ReadAllLines("students.csv");

        HashSet<string> ids = new();
        HashSet<string> duplicates = new();

        for (int i = 1; i < lines.Length; i++)
        {
            var id = lines[i].Split(',')[0];

            if (!ids.Add(id))
                duplicates.Add(lines[i]);
        }

        foreach (var d in duplicates)
            Console.WriteLine(d);
    }
}
