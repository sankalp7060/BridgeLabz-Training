using System;

class MultiplicationTable{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the number:- ");
        int number = int.Parse(Console.ReadLine()); //User given number

        //Display the table using for loop
        for (int i = 6; i <= 9; i++)
            Console.WriteLine(number + " * " + i + " = " + (number * i));
    }
}
