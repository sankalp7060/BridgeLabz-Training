using System;

class GreatestFactor{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the number:- ");
        int number = int.Parse(Console.ReadLine());
        int greatestFactor = 1; //Set greatestFactor to one because as we know every number has factor 1 minimum

        //Iterate from n-1 to 1 to get the greatest factor of user given number
        for (int i = number - 1; i >= 1; i--)
        {
            if (number % i == 0)
            {
                greatestFactor = i;
                break;
            }
        }

        Console.WriteLine(greatestFactor); //Output
    }
}
