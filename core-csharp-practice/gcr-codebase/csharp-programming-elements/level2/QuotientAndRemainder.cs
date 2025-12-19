using System;

class QuotientAndRemainder{
    static void Main(String[] args){
        Console.Write("Enter first number: ");
        int number1 = int.Parse(Console.ReadLine()); //User given value for number 1 
        Console.Write("Enter second number: ");
        int number2 = int.Parse(Console.ReadLine()); //User given value for number 2
        int quotient = number1 / number2; //Calculate Quotient
        int remainder = number1 % number2; //Calculate Remainder
        Console.WriteLine("The Quotient is " + quotient + " and Remainder is " + remainder + " of two numbers " + number1 + " and " + number2); //Output
    }
}
