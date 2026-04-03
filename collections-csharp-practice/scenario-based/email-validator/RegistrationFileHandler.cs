using System;
using System.IO;

public class RegistrationFileHandler
{
    private readonly string _filePath;

    public RegistrationFileHandler(string filePath)
    {
        _filePath = filePath;
        if (!File.Exists(_filePath))
            File.Create(_filePath).Close();
    }

    public void SaveStudent(Student student)
    {
        string line = $"{student.FullName},{student.Email},{student.RegistrationTime}";
        File.AppendAllLines(_filePath, new[] { line });
    }

    public void DisplayAllRegistrations()
    {
        var lines = File.ReadAllLines(_filePath);
        Console.WriteLine("\n--- All Registered Students ---");
        foreach (var line in lines)
            Console.WriteLine(line);
        Console.WriteLine("-------------------------------\n");
    }
}
