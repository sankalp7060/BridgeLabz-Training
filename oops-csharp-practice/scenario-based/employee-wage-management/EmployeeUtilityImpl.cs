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

    public void CheckEmployeeAttendance()
    {
        Random random = new Random();
        int attendance = random.Next(0, 2);

        if (attendance == 1)
            Console.WriteLine("Employee is Present");
        else
            Console.WriteLine("Employee is Absent");
    }

    public void CalculateDailyWage()
    {
        int wagePerHour = 20;
        int fullDayHour = 8;

        int dailyWage = wagePerHour * fullDayHour;

        Console.WriteLine("Daily Employee Wage: " + dailyWage);
    }

    public void AddPartTimeEmployee()
    {
        if (count >= employees.Length)
        {
            Console.WriteLine("Employee storage full!");
            return;
        }

        Console.Write("Enter Part-Time Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Part-Time Employee Name: ");
        string name = Console.ReadLine();

        int partTimeHour = 8;
        int wagePerHour = 20;
        double dailyWage = partTimeHour * wagePerHour;

        employees[count] = new Employee(id, name, dailyWage);
        count++;

        Console.WriteLine("Part-Time Employee added successfully!");
        Console.WriteLine("Part-Time Daily Wage: " + dailyWage);
    }

    public void CalculateMonthlyWage()
    {
        int wagePerHour = 20;
        int fullDayHour = 8;
        int workingDays = 20;

        int dailyWage = wagePerHour * fullDayHour;
        int monthlyWage = dailyWage * workingDays;

        Console.WriteLine("Monthly Employee Wage (assuming 20 working days): " + monthlyWage);
    }

    public void CalculateWagesTillCondition()
    {
        int wagePerHour = 20;
        int fullDayHour = 8;
        int partTimeHour = 8;

        int totalHours = 0;
        int totalDays = 0;
        int maxHours = 100;
        int maxDays = 20;

        Random random = new Random();

        Console.WriteLine(
            "Calculating wages till total hours (100) or total days (20) is reached...\n"
        );

        while (totalHours < maxHours && totalDays < maxDays)
        {
            totalDays++;
            int empType = random.Next(0, 2);
            int hoursWorked = (empType == 1) ? fullDayHour : partTimeHour;

            if (totalHours + hoursWorked > maxHours)
            {
                hoursWorked = maxHours - totalHours;
            }

            totalHours += hoursWorked;
            int dailyWage = hoursWorked * wagePerHour;

            string type = (empType == 1) ? "Full-Time" : "Part-Time";
            Console.WriteLine(
                $"Day {totalDays}: {type} Hours Worked = {hoursWorked}, Daily Wage = {dailyWage}"
            );
        }

        int totalWage = totalHours * wagePerHour;
        Console.WriteLine($"\nTotal Days Worked: {totalDays}");
        Console.WriteLine($"Total Hours Worked: {totalHours}");
        Console.WriteLine($"Total Wage for the Month: {totalWage}");
    }
}
