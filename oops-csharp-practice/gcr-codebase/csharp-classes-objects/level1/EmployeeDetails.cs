using System;

class Employee
{
    // Attributes
    public string Name;
    public int Id;
    public double Salary;

    // Method to display employee details
    public void DisplayDetails()
    {
        Console.WriteLine("Employee Details:");
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("ID: " + Id);
        Console.WriteLine("Salary: $" + Salary);
    }
}

class EmployeeDetails
{
    static void Main()
    {
        // Creating an Employee object
        Employee emp = new Employee();
        
        // Input employee details
        Console.Write("Enter Name: ");
        emp.Name = Console.ReadLine();

        Console.Write("Enter ID: ");
        emp.Id = int.Parse(Console.ReadLine());

        Console.Write("Enter Salary: ");
        emp.Salary = double.Parse(Console.ReadLine());

        // Display details
        emp.DisplayDetails();
    }
}
