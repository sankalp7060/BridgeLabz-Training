using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // initialized
    public string Department { get; set; } = string.Empty; // initialized
    public double Salary { get; set; }
}

class Serialization
{
    static void Main()
    {
        string file = "employees.json";

        List<Employee> employees = new List<Employee>()
        {
            new Employee
            {
                Id = 1,
                Name = "Aman",
                Department = "IT",
                Salary = 50000,
            },
            new Employee
            {
                Id = 2,
                Name = "Riya",
                Department = "HR",
                Salary = 45000,
            },
        };

        try
        {
            // Serialize
            string json = JsonSerializer.Serialize(employees);
            File.WriteAllText(file, json);

            // Deserialize
            string readJson = File.ReadAllText(file);
            var result = JsonSerializer.Deserialize<List<Employee>>(readJson);

            Console.WriteLine("Employee List:");
            if (result != null) // null check
            {
                foreach (var e in result)
                {
                    Console.WriteLine($"{e.Id} {e.Name} {e.Department} {e.Salary}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
