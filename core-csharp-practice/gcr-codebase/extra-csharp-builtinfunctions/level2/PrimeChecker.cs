using System;

class PrimeChecker{
    static void Main(){
        Console.WriteLine("Enter a number:- ");
        int num = int.Parse(Console.ReadLine());

        if(IsPrime(num))
            Console.WriteLine("Number is PRIME");
        else
            Console.WriteLine("Number is NOT PRIME");
    }

    // Checks if number is prime
    static bool IsPrime(int num){
        if(num <= 1) return false;

        for(int i=2; i<=num/2; i++){
            if(num % i == 0) return false;
        }
        return true;
    }
}
