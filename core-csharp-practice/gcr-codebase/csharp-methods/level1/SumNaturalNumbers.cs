using System;

class SumNaturalNumbers{
    //Main()
    static void Main(){
        Console.WriteLine("Enter n:- ");
        int n = int.Parse(Console.ReadLine()); //User input n
        int sum = CalculateSum(n); //Call method to calculate sum
        Console.WriteLine("Sum of first " + n + " natural numbers:- " + sum); //Output
    }

    //Method to calculate sum of n natural numbers
    static int CalculateSum(int n){
        int sum = 0; //Initialize sum
        for(int i = 1; i <= n; i++){
            sum += i; //Add numbers to sum
        }
        return sum; //return result
    }
}
