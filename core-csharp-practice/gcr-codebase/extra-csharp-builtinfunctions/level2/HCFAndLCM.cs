using System;

class HCFAndLCm{
    static void Main(){
        Console.WriteLine("Enter first number:- ");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter second number:- ");
        int b = int.Parse(Console.ReadLine());

        int gcd = FindGCD(a, b);
        int lcm = FindLCM(a, b);

        Console.WriteLine("GCD: " + gcd);
        Console.WriteLine("LCM: " + lcm);
    }

    // Calculates GCD using Euclidean algorithm
    static int FindGCD(int a, int b){
        while(b != 0){
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Calculates LCM using GCD
    static int FindLCM(int a, int b){
        return (a * b) / FindGCD(a, b);
    }
}
