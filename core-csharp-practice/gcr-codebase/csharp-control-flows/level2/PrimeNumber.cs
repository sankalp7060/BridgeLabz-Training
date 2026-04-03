using System;

class PrimeNumber{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the number:- ");
        int number = int.Parse(Console.ReadLine()); //User given number
        bool isPrime = true;

        //Conditions that user input the valid number
        if (number <= 1)
            isPrime = false;

        //Check whether the number is prime or not using for loop
        for (int i = 2; i < number; i++){
            if (number % i == 0){
                isPrime = false;
                break;
            }
        }

        //Output
        if(isPrime){
            Console.WriteLine("The number is prime");
        }
        else{
            Console.WriteLine("The number is not prime");
        }
    }
}
