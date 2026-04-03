using System;

class Add_Two_Numbers{
    // Main
    public static void Main(string[] args){
        // In C#, we use Console.ReadLine() instead of Scanner
        Console.WriteLine("Enter first number:- ");
        int num1 = int.Parse(Console.ReadLine()); // take first number input
        Console.WriteLine("Enter Second number:- ");
        int num2 = int.Parse(Console.ReadLine()); // take second number input
        int sum = num1 + num2; // variable which stores the result of addition of two numbers
        Console.WriteLine("The sum of " + num1 + " and " + num2 + " is:- " + sum);
    }
}
