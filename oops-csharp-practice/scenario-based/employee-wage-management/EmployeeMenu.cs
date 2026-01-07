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
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n====== Employee Wage System Menu ======");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Check Employee Attendance");
            Console.WriteLine("3. Calculate Daily Employee Wage");
            Console.WriteLine("4. Add Part-Time Employee");
            Console.WriteLine("5. Calculate Monthly Employee Wage");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            bool isValid = int.TryParse(Console.ReadLine(), out choice);

            if (!isValid)
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

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
                case 5:
                    employeeUtility.CalculateMonthlyWage();
                    break;

                case 6:
                    Console.WriteLine("Exiting Employee Wage System...");
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice! Please select a valid option.");
                    break;
            }
        }
    }
}
