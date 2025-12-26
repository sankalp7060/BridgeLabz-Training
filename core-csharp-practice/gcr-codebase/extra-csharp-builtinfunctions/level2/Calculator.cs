using System;

class Calculator{
    static void Main(){
        Console.WriteLine("Enter first number:- ");
        double a = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter second number:- ");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("Choose operation (+ - * /):- ");
        char op = Console.ReadLine()[0];

        double result = Calculate(a, b, op);

        Console.WriteLine("Result: " + result);
    }

    // Performs selected operation
    static double Calculate(double a, double b, char op){
        switch(op){
            case '+': return a + b;
            case '-': return a - b;
            case '*': return a * b;
            case '/': return a / b;
            default:
                Console.WriteLine("Invalid operation");
                return 0;
        }
    }
}
