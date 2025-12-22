using System;

class EmployeeBonus{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the salary:- ");
        double salary = double.Parse(Console.ReadLine()); //Salary input
        Console.WriteLine("Enter the years:- ");
        int years = int.Parse(Console.ReadLine()); //Year input

        //Condition to check whether employee have wor over 5 years or not if true then display it's salary accordingly
        if (years > 5)
            Console.WriteLine(salary * 0.05);
        else
            Console.WriteLine(0);
    }
}
