using System;

class SwapTwoNumbers{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter number1: ");
        int number1 = int.Parse(Console.ReadLine()); //User given value fo number 1
        Console.Write("Enter number2: ");
        int number2 = int.Parse(Console.ReadLine()); //User given value fo number 2
        //Swapping two numbers
        int temp = number1; 
        number1 = number2;
        number2 = temp;
        Console.WriteLine("The swapped numbers are " + number1 + " and " + number2); //Output
    }
}
