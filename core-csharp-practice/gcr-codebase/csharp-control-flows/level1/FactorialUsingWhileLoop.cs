using System;

class FactorialUsingWhileLoop{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the number:- ");
        int n = int.Parse(Console.ReadLine()); //User given value

        //Condition to check whether n is greater than zero or not beacause we can find factorial for number less than 1 or 0
        if (n > 0){
            int fact = 1;
            int i = 1;

            //Finding factorial using while loop
            while (i <= n){
                fact *= i;
                i++;
            }

            //Output
            Console.WriteLine(fact);
        }
        else{
            Console.WriteLine("Invalid input");
        }
    }
}
