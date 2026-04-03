using System;
using System.Collections.Generic;
using System.IO;

class Student
{
    public int Id;
    public string Name;
    public int Age;
}

class CSVToObject
{
    static void Main()
    {
        var lines = File.ReadAllLines("students.csv");

        List<Student> list = new List<Student>();

        for (int i = 1; i < lines.Length; i++)
        {
            var d = lines[i].Split(',');

            list.Add(
                new Student
                {
                    Id = int.Parse(d[0]),
                    Name = d[1],
                    Age = int.Parse(d[2]),
                }
            );
        }

        foreach (var s in list)
            Console.WriteLine($"{s.Id} {s.Name} {s.Age}");
    }
}
