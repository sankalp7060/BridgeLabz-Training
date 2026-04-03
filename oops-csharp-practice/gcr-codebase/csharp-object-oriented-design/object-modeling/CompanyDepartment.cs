using System;

class Employee
{
    public string Name;
    public string Position;

    public Employee(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public void Display()
    {
        Console.WriteLine($"Employee: {Name}, Position: {Position}");
    }
}

class Department
{
    public string DeptName;
    public Employee[] Employees;
    private int count = 0;

    public Department(string deptName, int empCapacity)
    {
        DeptName = deptName;
        Employees = new Employee[empCapacity];
    }

    public void AddEmployee(string name, string position)
    {
        if (count < Employees.Length)
        {
            Employees[count++] = new Employee(name, position);
        }
    }

    public void ShowEmployees()
    {
        Console.WriteLine($"Department: {DeptName}");
        for (int i = 0; i < count; i++)
        {
            Employees[i].Display();
        }
    }
}

class Company
{
    public string Name;
    public Department[] Departments;
    private int count = 0;

    public Company(string name, int deptCapacity)
    {
        Name = name;
        Departments = new Department[deptCapacity];
    }

    public void AddDepartment(string deptName, int empCapacity)
    {
        if (count < Departments.Length)
        {
            Departments[count++] = new Department(deptName, empCapacity);
        }
    }

    public void ShowCompany()
    {
        Console.WriteLine($"Company: {Name}");
        for (int i = 0; i < count; i++)
        {
            Departments[i].ShowEmployees();
        }
    }
}

// Demo
class CompanyDepartment
{
    static void Main()
    {
        Company company = new Company("TechCorp", 2);

        company.AddDepartment("Development", 3);
        company.AddDepartment("HR", 2);

        company.Departments[0].AddEmployee("Alice", "Developer");
        company.Departments[0].AddEmployee("Bob", "Developer");
        company.Departments[1].AddEmployee("Charlie", "HR Manager");

        company.ShowCompany();
    }
}
