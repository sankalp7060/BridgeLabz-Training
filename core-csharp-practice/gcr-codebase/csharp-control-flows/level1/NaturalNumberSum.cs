using System;

class NaturalNumberSum{
    public static void Main(String[] args){
        Console.WriteLine("Enter the Number:- ");
        int n = int.Parse(Console.ReadLine()); //User given number n
        if (n > 0){ 
            //Formula to get sum of n natural numbers :- n * (n + 1) / 2;
            //Sum of n natural numbers using loop
            int sum=0; //vairable to store sum
            for(int i = 1; i <= n; i++){
                sum+=i;
            }
            Console.WriteLine("The sum of " + n + " natural numbers is " + sum); 
        }
        else{
            Console.WriteLine("The number " + n + " is not a natural number");
        }
    }
}
