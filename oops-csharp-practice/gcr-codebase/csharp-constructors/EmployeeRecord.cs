using System;

class Employee
{
    public int employeeID;
    protected string department;
    private double salary;

    // Constructor
    public Employee(int id, string dept, double sal)
    {
        employeeID = id;
        department = dept;
        salary = sal;
    }

    public double GetSalary()
    {
        return salary;
    }
}

class Manager : Employee
{
    public Manager(int id, string dept, double sal)
        : base(id, dept, sal) { }

    public void Display()
    {
        Console.WriteLine($"ID: {employeeID}");
        Console.WriteLine($"Department: {department}");
        Console.WriteLine($"Salary: {GetSalary()}");
    }
}

class EmployeeRecord
{
    static void Main()
    {
        Manager m = new Manager(101, "IT", 60000);
        m.Display();
    }
}
