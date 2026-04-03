using System;

class SpringSeasonCheck{
    //Main()
    static void Main(){
        Console.WriteLine("Enter month (1-12):- ");
        int month = int.Parse(Console.ReadLine()); //User input month
        Console.WriteLine("Enter day (1-31):- ");
        int day = int.Parse(Console.ReadLine()); //User input day
        bool isSpring = CheckSpringSeason(month, day); //Call method to check spring season

        //If isSpring is true then the season is a spring season otherwise not
        if(isSpring) 
            Console.WriteLine("Its a Spring Season");
        else
            Console.WriteLine("Not a Spring Season");
    }

    //Method to check spring season
    static bool CheckSpringSeason(int month, int day){

        //Conditions to check spring season
        if((month == 3 && day >= 20) || (month > 3 && month < 6) || (month == 6 && day <= 20))
            return true; //Spring season
        else
            return false; //Not spring season
    }
}
