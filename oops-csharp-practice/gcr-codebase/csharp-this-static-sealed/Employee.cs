using System;

class Employee
{
    public static string CompanyName = "TechCorp";
    private static int totalEmployees = 0;

    public string Name;
    public string Designation;
    public readonly int Id;

    public Employee(string name, int id, string designation)
    {
        this.Name = name;
        this.Id = id;
        this.Designation = designation;
        totalEmployees++;
    }

    public static void DisplayTotalEmployees()
    {
        Console.WriteLine("Total Employees: " + totalEmployees);
    }

    public void Display(object obj)
    {
        if (obj is Employee)
        {
            Console.WriteLine($"{Name} ({Designation}), ID: {Id}");
        }
    }

    static void Main()
    {
        Employee e = new Employee("Aman", 1, "Developer");
        e.Display(e);
        DisplayTotalEmployees();
    }
}
