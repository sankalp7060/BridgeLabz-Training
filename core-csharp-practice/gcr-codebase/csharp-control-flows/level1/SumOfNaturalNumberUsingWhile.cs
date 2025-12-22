using System;

class SumOfNaturalNumberUsingWhile{
    //Main()
    static void Main(){
        Console.WriteLine("Enter natural number n:- ");
        int n = int.Parse(Console.ReadLine()); //User given n natural number
        //Check whether n is greater than 0 or not
        if (n > 0){
            int sum1 = 0;
            int i = 1;
            //Sum all natural number upto n
            while (i <= n){
                sum1 += i;
                i++;
            }

            int sum2 = n * (n + 1) / 2; //Finding sum of n natural number using mathematical forumula

            //Output
            Console.WriteLine(sum1); 
            Console.WriteLine(sum2); 
        }
    }
}
