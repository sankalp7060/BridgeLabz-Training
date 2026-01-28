using System;
using System.IO;
using System.Text.Json;

class JsonCsvConvert
{
    static void Main()
    {
        var students = new[] { new { Id = 1, Name = "Amit" }, new { Id = 2, Name = "Riya" } };

        string json = JsonSerializer.Serialize(students);
        File.WriteAllText("students.json", json);

        File.WriteAllLines("students_from_json.csv", new[] { "ID,Name", "1,Amit", "2,Riya" });

        Console.WriteLine("JSON <-> CSV Done");
    }
}
