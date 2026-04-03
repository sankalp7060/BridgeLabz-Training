using System;

class LeapYear{
    //Main()
    static void Main(){
        Console.WriteLine("Enter year:- ");
        int year = int.Parse(Console.ReadLine()); //User input year
        bool isLeap = CheckLeapYear(year); //Check leap year

        //If isLeap is true then the year is a leap year otherwise not
        if(isLeap)
            Console.WriteLine("Year is a Leap Year");
        else
            Console.WriteLine("Year is not a Leap Year");
    }

    //Method to check leap year
    static bool CheckLeapYear(int year){
        if(year < 1582)
            return false;

        if((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            return true;

        return false;
    }
}
