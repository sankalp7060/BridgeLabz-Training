using System;

class PositiveNegativeZero{
    //Main()
    static void Main(String[] args){
        Console.WriteLine("Enter number to check:- ");
        int number = int.Parse(Console.ReadLine()); //User given number
        //Condtions to check whether a number is positive, negative, or zero
        if (number > 0)
            Console.WriteLine("positive");
        else if (number < 0)
            Console.WriteLine("negative");
        else
            Console.WriteLine("zero");
    }
}
