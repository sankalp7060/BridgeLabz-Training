using System;

class FactorialUsingForLoop{
    //Main()
    static void Main(){
        Console.WriteLine("Enter number:- ");
        int n = int.Parse(Console.ReadLine()); //User given value

        //Condition to check whether n is greater than zero or not beacause we can find factorial for number less than 1 or 0
        if (n > 0){
            int fact = 1;

            //Finding factorial using for loop
            for (int i = 1; i <= n; i++)
                fact *= i;

            //Output
            Console.WriteLine(fact);
        }
        else{
            Console.WriteLine("Invalid input");
        }
    }
}
