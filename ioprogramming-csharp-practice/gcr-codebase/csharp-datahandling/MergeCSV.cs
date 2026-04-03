using System;
using System.Collections.Generic;
using System.IO;

class MergeCSV
{
    static void Main()
    {
        File.WriteAllLines("students1.csv", new[] { "ID,Name,Age", "1,Amit,20" });

        File.WriteAllLines("students2.csv", new[] { "ID,Marks,Grade", "1,85,A" });

        var file1 = File.ReadAllLines("students1.csv");
        var file2 = File.ReadAllLines("students2.csv");

        Dictionary<string, string> map = new();

        for (int i = 1; i < file2.Length; i++)
        {
            var d = file2[i].Split(',');
            map[d[0]] = d[1] + "," + d[2];
        }

        List<string> result = new();
        result.Add("ID,Name,Age,Marks,Grade");

        for (int i = 1; i < file1.Length; i++)
        {
            var d = file1[i].Split(',');
            result.Add(file1[i] + "," + map[d[0]]);
        }

        File.WriteAllLines("merged.csv", result);

        Console.WriteLine("Merge Completed");
    }
}
