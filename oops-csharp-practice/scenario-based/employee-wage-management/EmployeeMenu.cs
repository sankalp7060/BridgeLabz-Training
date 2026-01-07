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
        Console.WriteLine("2. Check Employee Attendance");
        Console.WriteLine("3. Calculate Daily Employee Wage");
        Console.WriteLine("4. Add Part-Time Employee");
        Console.Write("Enter choice: ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                employeeUtility.AddEmployee();
                break;

            case 2:
                employeeUtility.CheckEmployeeAttendance();
                break;

            case 3:
                employeeUtility.CalculateDailyWage();
                break;

            case 4:
                employeeUtility.AddPartTimeEmployee();
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}
