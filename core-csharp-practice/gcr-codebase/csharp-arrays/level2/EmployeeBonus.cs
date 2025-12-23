using System;

class EmployeeBonus
{
    static void Main()
    {
        int numEmployees = 10;

        // Arrays to store salaries and years of service
        double[] salary = new double[numEmployees];
        double[] yearsOfService = new double[numEmployees];

        // Arrays to store bonus and new salary
        double[] bonus = new double[numEmployees];
        double[] newSalary = new double[numEmployees];

        // Variables to calculate totals
        double totalBonus = 0, totalOldSalary = 0, totalNewSalary = 0;

        // Input salary and years of service
        for (int i = 0; i < numEmployees; i++)
        {
            Console.WriteLine($"Employee {i + 1}:");

            // Input salary with validation
            Console.Write("Enter salary: ");
            salary[i] = double.Parse(Console.ReadLine());
            if (salary[i] <= 0)
            {
                Console.WriteLine("Invalid salary, please enter again.");
                i--;
                continue;
            }

            // Input years of service with validation
            Console.Write("Enter years of service: ");
            yearsOfService[i] = double.Parse(Console.ReadLine());
            if (yearsOfService[i] < 0)
            {
                Console.WriteLine("Invalid years of service, please enter again.");
                i--;
                continue;
            }
        }

        // Calculate bonus, new salary and totals
        for (int i = 0; i < numEmployees; i++)
        {
            // Determine bonus percentage
            if (yearsOfService[i] > 5)
                bonus[i] = salary[i] * 0.05; // 5%
            else
                bonus[i] = salary[i] * 0.02; // 2%

            newSalary[i] = salary[i] + bonus[i];

            // Update totals
            totalBonus += bonus[i];
            totalOldSalary += salary[i];
            totalNewSalary += newSalary[i];

            Console.WriteLine($"Employee {i + 1} -> Old Salary: {salary[i]}, Bonus: {bonus[i]}, New Salary: {newSalary[i]}");
        }

        // Display total bonus and salaries
        Console.WriteLine($"\nTotal Bonus Payout = {totalBonus}");
        Console.WriteLine($"Total Old Salary = {totalOldSalary}");
        Console.WriteLine($"Total New Salary = {totalNewSalary}");
    }
}
