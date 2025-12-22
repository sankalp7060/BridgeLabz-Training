using System;

class SpringSeason{
    static void Main(String[] args){
        Console.WriteLine("Enter month and day:- ");
        int month = int.Parse(Console.ReadLine()); //Month input
        int day = int.Parse(Console.ReadLine()); //Day input

        //Condotions to check whether the season is spring season or not
        bool spring;
        if (month == 3){
            if (day >= 20)
                spring = true;
            else
                spring = false;
        }
        else if (month == 4){
            spring = true;
        }
        else if (month == 5){
            spring = true;
        }
        else if (month == 6){
            if (day <= 20)
                spring = true;
            else
                spring = false;
        }
        else{
            spring = false;
        }

        //Output
        if (spring)
            Console.WriteLine("Its a Spring Season");
        else
            Console.WriteLine("Not a Spring Season");
    }
}
