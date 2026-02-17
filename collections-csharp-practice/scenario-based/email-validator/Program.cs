using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var fileHandler = new RegistrationFileHandler("registrations.txt");

        // Sample list of students for concurrent registration
        var students = new List<Student>
        {
            new Student { FullName = "John Doe", Email = "john.doe@gmail.com" },
            new Student { FullName = "Megha R", Email = "megha_r92@outlook.in" },
            new Student { FullName = "Admin", Email = "admin@blitz.edu" },
            new Student { FullName = "Raju", Email = "raju#123@inbox.com" }, // Invalid
            new Student { FullName = "Alice", Email = "@gmail.com" }, // Invalid
        };

        var tasks = new List<Task>();

        foreach (var student in students)
        {
            // Simulate concurrent processing using Task
            tasks.Add(
                Task.Run(() =>
                {
                    if (EmailValidatorService.ValidateEmail(student, out string error))
                    {
                        fileHandler.SaveStudent(student);
                        Console.WriteLine($"Registered: {student.FullName} ({student.Email})");
                    }
                    else
                    {
                        Console.WriteLine($"Failed: {error}");
                    }
                })
            );
        }

        await Task.WhenAll(tasks);

        fileHandler.DisplayAllRegistrations();
    }
}
