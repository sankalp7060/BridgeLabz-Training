using System;

interface IDepartment
{
    void AssignDepartment(string department);
    string GetDepartmentDetails();
}

abstract class Employee : IDepartment
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    protected int baseSalary;
    public string Department { get; private set; }

    public Employee(int id, string name, int salary)
    {
        Id = id;
        Name = name;
        baseSalary = salary;
    }

    public abstract int CalculateSalary();

    public void Display()
    {
        Console.WriteLine($"Employee details:- {Id}, {Name}, {Department}, {CalculateSalary()}");
    }

    public void AssignDepartment(string department)
    {
        Department = department;
    }

    public string GetDepartmentDetails()
    {
        return Department;
    }
}

class FullTimeEmployee : Employee
{
    public FullTimeEmployee(int id, string name, int salary)
        : base(id, name, salary) { }

    public override int CalculateSalary()
    {
        return baseSalary;
    }
}

class PartTimeEmployee : Employee
{
    private int hourlyWorked;
    private int rate;

    public PartTimeEmployee(int id, string name, int hourlyWorked, int rate)
        : base(id, name, 0)
    {
        this.hourlyWorked = hourlyWorked;
        this.rate = rate;
    }

    public override int CalculateSalary()
    {
        return hourlyWorked * rate;
    }
}

class EmployeeManagementSystem
{
    static void Main()
    {
        Employee[] employees = new Employee[3];
        employees[0] = new FullTimeEmployee(123, "san", 100000);
        employees[1] = new FullTimeEmployee(456, "akalp", 1000000);
        employees[2] = new PartTimeEmployee(789, "Agar", 80, 500);
        employees[0].AssignDepartment("IT");
        employees[1].AssignDepartment("HR");
        employees[2].AssignDepartment("Finance");
        Console.WriteLine("Employee Details:\n");

        for (int i = 0; i < employees.Length; i++)
        {
            employees[i].Display();
        }
    }
}
