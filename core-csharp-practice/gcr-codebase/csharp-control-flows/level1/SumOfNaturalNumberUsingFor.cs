using System;

class SumOfNaturalNumberUsingFor{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the naturl number n:- ");
        int n = int.Parse(Console.ReadLine()); //User given n natural number

        //Condition to check whether n is greater than 0 or not
        if (n > 0)
        {
            int sum1 = 0;
            //Calculate sum of n natural number using for loop
            for (int i = 1; i <= n; i++)
                sum1 += i;

            int sum2 = n * (n + 1) / 2; //finding sum of n natural number using mathematical formula

            //Output
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
        }
    }
}
