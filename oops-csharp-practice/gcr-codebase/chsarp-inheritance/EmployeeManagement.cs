using System;

class Employee
{
    public string Name { get; set; }
    public int Id { get; set; }
    public double Salary { get; set; }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}, Id: {Id}, Salary: {Salary}");
    }
}

class Manager : Employee
{
    public int TeamSize { get; set; }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Team Size: {TeamSize}");
    }
}

class Developer : Employee
{
    public string ProgrammingLanguage { get; set; }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Language: {ProgrammingLanguage}");
    }
}

class Intern : Employee
{
    public string InternshipDuration { get; set; }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Duration: {InternshipDuration}");
    }
}

class EmployeeManagement
{
    static void Main()
    {
        Employee e1 = new Manager
        {
            Name = "Amit",
            Id = 1,
            Salary = 90000,
            TeamSize = 10,
        };

        Employee e2 = new Developer
        {
            Name = "Rahul",
            Id = 2,
            Salary = 70000,
            ProgrammingLanguage = "C#",
        };

        Employee e3 = new Intern
        {
            Name = "Neha",
            Id = 3,
            Salary = 15000,
            InternshipDuration = "6 Months",
        };

        e1.DisplayDetails();
        e2.DisplayDetails();
        e3.DisplayDetails();
    }
}
