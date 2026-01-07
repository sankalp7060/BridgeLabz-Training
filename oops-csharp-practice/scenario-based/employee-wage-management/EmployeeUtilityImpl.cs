using System;

public class EmployeeUtilityImpl : IEmployee
{
    private static Employee[] employees = new Employee[100];
    private static int count = 0;

    public void AddEmployee()
    {
        if (count >= employees.Length)
        {
            Console.WriteLine("Employee storage full!");
            return;
        }

        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Wage Per Hour: ");
        double wage = double.Parse(Console.ReadLine());

        employees[count] = new Employee(id, name, wage);
        count++;

        Console.WriteLine("Employee added successfully!");
    }
}
