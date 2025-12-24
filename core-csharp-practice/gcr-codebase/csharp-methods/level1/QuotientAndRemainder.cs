using System;

class QuotientAndRemainder{
    //Main()
    static void Main(){
        Console.WriteLine("Enter dividend:- ");
        int number = int.Parse(Console.ReadLine()); //User input number
        Console.WriteLine("Enter divisor:- ");
        int divisor = int.Parse(Console.ReadLine()); //User input divisor
        int[] result = FindRemainderAndQuotient(number, divisor); //Call method to find remainder and quotient
        Console.WriteLine("Quotient:- " + result[0]); //Output quotient
        Console.WriteLine("Remainder:- " + result[1]); //Output remainder
    }

    //Method to find remainder and quotient
    static int[] FindRemainderAndQuotient(int number, int divisor){
        int quotient = number / divisor; //Calculate quotient
        int remainder = number % divisor; //Calculate remainder
        return new int[]{quotient, remainder}; //return result
    }
}
