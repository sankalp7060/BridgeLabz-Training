using System;
using System.Collections.Generic;
using System.IO;

class UpdateSalary
{
    static void Main()
    {
        var lines = File.ReadAllLines("employees.csv");

        List<string> updated = new List<string>();
        updated.Add(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            var d = lines[i].Split(',');

            if (d[2] == "IT")
            {
                double salary = double.Parse(d[3]);
                salary += salary * 0.10;
                d[3] = salary.ToString();
            }

            updated.Add(string.Join(",", d));
        }

        File.WriteAllLines("updated_employees.csv", updated);

        Console.WriteLine("Salary Updated");
    }
}
