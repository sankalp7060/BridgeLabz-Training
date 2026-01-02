using System;

abstract class Employee
{
    public abstract int GetSalary();

    public void Work() => Console.WriteLine("Employee working");
}

class Developer : Employee
{
    public override int GetSalary() => 50000;
}

class EmployeeDeveloper
{
    static void Main()
    {
        Employee e = new Developer();
        e.Work();
        Console.WriteLine(e.GetSalary());
    }
}
