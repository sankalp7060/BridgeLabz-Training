using System;

class Fibonacci{
    static void Main(){
        Console.WriteLine("Enter number of terms:- ");
        int n = int.Parse(Console.ReadLine());

        PrintFibonacci(n);
    }

    // Prints Fibonacci sequence
    static void PrintFibonacci(int n){
        int a = 0, b = 1;

        Console.Write(a + " " + b + " ");

        for(int i=3; i<=n; i++){
            int c = a + b;
            Console.Write(c + " ");
            a = b;
            b = c;
        }
    }
}
