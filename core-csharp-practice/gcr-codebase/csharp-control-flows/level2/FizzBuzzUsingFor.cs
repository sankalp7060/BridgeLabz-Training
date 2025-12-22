using System;

class FizzBuzzUsingFor{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the number:- ");
        int number = int.Parse(Console.ReadLine()); //User given number

        //Conditions to check whether the number is fizzbuzz or not
        if (number > 0)
        {
            for (int i = 1; i <= number; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (i % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(i);
            }
        }
    }
}
