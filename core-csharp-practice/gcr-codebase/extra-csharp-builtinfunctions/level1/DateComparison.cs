using System;

class DateComparison{
    static void Main(){
        // Take first date input
        Console.WriteLine("Enter first date (yyyy-MM-dd):- ");
        DateTime d1 = DateTime.Parse(Console.ReadLine());

        // Take second date input
        Console.WriteLine("Enter second date (yyyy-MM-dd):- ");
        DateTime d2 = DateTime.Parse(Console.ReadLine());

        // Compare dates
        if(d1 < d2)
            Console.WriteLine("First date is BEFORE second date");
        else if(d1 > d2)
            Console.WriteLine("First date is AFTER second date");
        else
            Console.WriteLine("Both dates are SAME");
    }
}
