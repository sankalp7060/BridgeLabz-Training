using System;
using System.IO;
using System.Text.RegularExpressions;

class ValidateCSV
{
    static void Main()
    {
        string file = "users.csv";

        File.WriteAllLines(
            file,
            new string[]
            {
                "Name,Email,Phone",
                "Amit,amit@gmail.com,9876543210",
                "Riya,riya@,12345",
            }
        );

        var lines = File.ReadAllLines(file);

        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        string phonePattern = @"^\d{10}$";

        for (int i = 1; i < lines.Length; i++)
        {
            var d = lines[i].Split(',');

            if (!Regex.IsMatch(d[1], emailPattern) || !Regex.IsMatch(d[2], phonePattern))
            {
                Console.WriteLine("Invalid Row: " + lines[i]);
            }
        }
    }
}
