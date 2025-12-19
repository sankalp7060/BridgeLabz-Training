using System;

class Calculator{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter number1: ");
        double num1 = double.Parse(Console.ReadLine()); //User given value of number 1
        Console.Write("Enter number2: ");
        double num2 = double.Parse(Console.ReadLine()); //User given value for number 2
        double addition  =  num1 + num2; //Sum of two number num1 and num2 
        double subtraction= num1 - num2; //Difference of num1 and num2
        double multiplication = num1 * num2; //Multiplication of num1 and num2
        double division = num1 / num2; //Division of num1 and num2
        Console.WriteLine($"The addition, subtraction, multiplication and division value of 2 numbers {num1} and {num2} is " +
                          $"{addition}, {subtraction}, {multiplication}, {division}"); //Output
    }
}
