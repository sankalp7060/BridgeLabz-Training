using System;

class DateArithmetic{
    static void Main(){
        // Ask user for date input
        Console.WriteLine("Enter a date (yyyy-MM-dd):- ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        // Add 7 days, 1 month and 2 years
        DateTime result = date.AddDays(7)
                              .AddMonths(1)
                              .AddYears(2);

        // Subtract 3 weeks (21 days)
        result = result.AddDays(-21);

        // Display final result
        Console.WriteLine("Final Date: " + result.ToShortDateString());
    }
}
