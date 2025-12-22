using System;

class CountDigits{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the number:- ");
        int number = int.Parse(Console.ReadLine()); //User given value
        int count = 0;

        //Using while loop to count number of digits of a number
        while (number != 0){
            number = number / 10;
            count++;
        }

        Console.WriteLine(count); //Output
    }
}
