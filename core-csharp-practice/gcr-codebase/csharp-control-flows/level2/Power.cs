using System;

class Power{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the number and power:- ");
        int number = int.Parse(Console.ReadLine());
        int power = int.Parse(Console.ReadLine());

        int result = 1;

        //Calculate the power of a number using for loop
        for (int i = 1; i <= power; i++)
            result *= number;

        Console.WriteLine(result); //Output
    }
}
