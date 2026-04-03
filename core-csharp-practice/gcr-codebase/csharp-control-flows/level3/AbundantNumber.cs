using System;

/* An abundant number is a positive integer where the sum of its proper 
   divisors (factors excluding the number itself) is greater than the number
*/

class AbundantNumber{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the number:- ");
        int number = int.Parse(Console.ReadLine()); //User given value
        int sum = 0;

        //Calculate the sum of factors of a number
        for (int i = 1; i < number; i++){
            if (number % i == 0)
                sum += i;
        }

        //If sum is greater than the number itself then it is a Abundant Number otherwise not
        if (sum > number)
            Console.WriteLine("Abundant Number");
        else
            Console.WriteLine("Not an Abundant Number");
    }
}
