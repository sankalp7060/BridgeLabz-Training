using System;

class DayOfWeak{
    //Main()
    static void Main(string[] args){
        Console.WriteLine("Enter the month, day and year:- ");
        int month = int.Parse(Console.ReadLine());   // User's month input
        int day = int.Parse(Console.ReadLine());     // User's day input
        int year = int.Parse(Console.ReadLine());    // User's year input

        // Adjust the year if month is Jan or Feb
        int adjustedYear = year - (14 - month) / 12; 

        // Calculate leap year corrections 
        int yearCalculation = adjustedYear 
                               + adjustedYear / 4 
                               - adjustedYear / 100 
                               + adjustedYear / 400;  
        
        // Convert month to March-based index
        int adjustedMonth = month + 12 * ((14 - month) / 12) - 2;  

        // Final formula to calculate day of the week
        int dayOfWeek = (day + yearCalculation + (31 * adjustedMonth) / 12) % 7;  

        Console.WriteLine(dayOfWeek); //Output
    }
}
