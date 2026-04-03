using System;

class FactorialRecursion{
    static void Main(){
        Console.WriteLine("Enter a number:- ");
        int n = int.Parse(Console.ReadLine());

        int result = Factorial(n);

        Console.WriteLine("Factorial is: " + result);
    }

    // Recursive factorial method
    static int Factorial(int n){
        if(n == 0) return 1;
        return n * Factorial(n - 1);
    }
}
