using System;

class EmployeeBonus{
    //Main()
    static void Main(){
        int numEmployees = 10; //Number of employees i.e. 10

        // Double type arrays to store salaries and years of service
        double[] salary = new double[numEmployees];
        double[] yearsOfService = new double[numEmployees];

        // Double type arrays to store bonus and new salary
        double[] bonus = new double[numEmployees];
        double[] newSalary = new double[numEmployees];

        // Variables to calculate totals of bonus, old salary, new salary
        double totalBonus = 0, totalOldSalary = 0, totalNewSalary = 0;

        // User given salary ans year of service
        for (int i = 0; i < numEmployees; i++){
            Console.WriteLine($"Employee {i + 1}:");

            // User given salary 
            Console.Write("Enter salary: ");
            salary[i] = double.Parse(Console.ReadLine());

            //Salary Validation
            if (salary[i] <= 0){
                Console.WriteLine("Invalid salary, please enter again.");
                i--;
                continue;
            }

            // User given years of service
            Console.Write("Enter years of service: ");
            yearsOfService[i] = double.Parse(Console.ReadLine());

            //Year validation
            if (yearsOfService[i] < 0){
                Console.WriteLine("Invalid years of service, please enter again.");
                i--;
                continue;
            }
        }

        // Calculate bonus, new salary and totals
        for (int i = 0; i < numEmployees; i++){
            // Determine bonus percentage
            if (yearsOfService[i] > 5)
                bonus[i] = salary[i] * 0.05; // 5% of the salary is stored as bonus if year of service is greater than 5 
            else
                bonus[i] = salary[i] * 0.02; // 2% of the salary is stored as bonus if year of service is less than 5 

            newSalary[i] = salary[i] + bonus[i];

            // Update the total value of bonus, old salary and new salary
            totalBonus += bonus[i];
            totalOldSalary += salary[i];
            totalNewSalary += newSalary[i];

            Console.WriteLine($"Employee {i + 1} -> Old Salary: {salary[i]}, Bonus: {bonus[i]}, New Salary: {newSalary[i]}");
        }

        // Display result
        Console.WriteLine($"\nTotal Bonus Payout = {totalBonus}");
        Console.WriteLine($"Total Old Salary = {totalOldSalary}");
        Console.WriteLine($"Total New Salary = {totalNewSalary}");
    }
}
