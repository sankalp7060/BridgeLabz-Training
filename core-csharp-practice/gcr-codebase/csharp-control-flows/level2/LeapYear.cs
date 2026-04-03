using System;

class LeapYear{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the year:- ");
        int year = int.Parse(Console.ReadLine()); //user given year

        //Conditions to check whether the guven year is leap year or not
        if (year >= 1582)
        {
            if (year % 400 == 0)
                Console.WriteLine("Year is a Leap Year");
            else if (year % 100 == 0)
                Console.WriteLine("Year is not a Leap Year");
            else if (year % 4 == 0)
                Console.WriteLine("Year is a Leap Year");
            else
                Console.WriteLine("Year is not a Leap Year");
        }
        else
        {
            Console.WriteLine("Year is not valid");
        }
    }
}
