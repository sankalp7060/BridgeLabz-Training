using System;

class Factors{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the number:- ");
        int number = int.Parse(Console.ReadLine()); //User given number

        //Finding factors of a number using for loop
        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
                Console.WriteLine(i); //Output
        }
    }
}
