using System; 

class Calendar{
    //Main() 
    static void Main(){
        Console.WriteLine("Enter Month:- "); //Taking month input
        int month = int.Parse(Console.ReadLine()); //Reading month

        Console.WriteLine("Enter Year:- "); //Taking year input
        int year = int.Parse(Console.ReadLine()); //Reading year

        DisplayCalendar(month, year); //Calling calendar display method
    }

    //Method to display calendar
    static void DisplayCalendar(int month, int year){
        string[] months = { "", "January", "February", "March", "April", "May", "June",
                            "July", "August", "September", "October", "November", "December" }; //Month names

        int[] daysInMonth = { 0,31,28,31,30,31,30,31,31,30,31,30,31 }; //Days in each month

        if(month == 2 && IsLeapYear(year)) //Checking leap year for February
        {
            daysInMonth[2] = 29; //Updating February days
        }

        int firstDay = GetFirstDay(month, year); //Finding first day of month

        Console.WriteLine("\n  " + months[month] + " " + year); //Printing month and year
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat"); //Week header

        for(int i = 0; i < firstDay; i++){ //Indentation loop
            Console.Write("    "); //Printing spaces
        }

        for(int day = 1; day <= daysInMonth[month]; day++){
            Console.Write($"{day,3} "); //Printing day
            if((day + firstDay) % 7 == 0) //Checking Saturday
            {
                Console.WriteLine(); //Moving to next line
            }
        }
    }

    //Method to check leap year
    static bool IsLeapYear(int year){
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0); //Leap year logic
    }

    //Method to get first day using Gregorian algorithm
    static int GetFirstDay(int month, int year){
        int y0 = year - (14 - month) / 12; //Calculating y0
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400; //Calculating x
        int m0 = month + 12 * ((14 - month) / 12) - 2; //Calculating m0
        int d0 = (1 + x + 31 * m0 / 12) % 7; //Calculating d0
        return d0; //Returning first day
    }
}
