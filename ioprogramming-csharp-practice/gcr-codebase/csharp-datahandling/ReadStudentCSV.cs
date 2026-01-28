using System;
using System.IO;

class ReadStudentCSV
{
    static void Main()
    {
        string file = "students.csv";

        // Create file first
        File.WriteAllLines(
            file,
            new string[] { "ID,Name,Age,Marks", "1,Amit,20,85", "2,Riya,19,78", "3,Rahul,21,90" }
        );

        string[] lines = File.ReadAllLines(file);

        foreach (var line in lines)
        {
            Console.WriteLine(line.Replace(",", " | "));
        }
    }
}
