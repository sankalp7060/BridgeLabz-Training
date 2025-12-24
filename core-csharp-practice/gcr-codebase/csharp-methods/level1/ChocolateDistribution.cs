using System;

class ChocolateDistribution{
    //Main()
    static void Main(){
        Console.WriteLine("Enter number of chocolates:- ");
        int chocolates = int.Parse(Console.ReadLine()); //User input chocolates
        Console.WriteLine("Enter number of children:- ");
        int children = int.Parse(Console.ReadLine()); //User input children
        int[] result = FindRemainderAndQuotient(chocolates, children); //Call method to calculate distribution
        Console.WriteLine("Chocolates each child gets:- " + result[0]); //Output quotient
        Console.WriteLine("Remaining chocolates:- " + result[1]); //Output remainder
    }

    //Method to find chocolates per child and remaining
    static int[] FindRemainderAndQuotient(int number, int divisor){
        int quotient = number / divisor; //Chocolates per child
        int remainder = number % divisor; //Remaining chocolates
        return new int[]{quotient, remainder}; //return result
    }
}
