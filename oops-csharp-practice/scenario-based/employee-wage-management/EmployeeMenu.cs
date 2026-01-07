using System;

public class EmployeeMenu
{
    private IEmployee employeeUtility;

    public EmployeeMenu(IEmployee utility)
    {
        employeeUtility = utility;
    }

    public void ShowMenu()
    {
        Console.WriteLine("1. Add Employee");
        Console.Write("Enter choice: ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                employeeUtility.AddEmployee();
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}
