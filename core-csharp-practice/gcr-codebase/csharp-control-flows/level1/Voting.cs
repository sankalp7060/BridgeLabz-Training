using System;

class Voting{
    //Main()
    public static void Main(String[] args){
        Console.WriteLine("Enter age:- ");
        int age = int.Parse(Console.ReadLine()); //User's age
        //Conditions to check whether user is eligible for voting or not
        if (age >= 18)
            Console.WriteLine("The person's age is " + age + " and can vote.");
        else
            Console.WriteLine("The person's age is " + age + " and cannot vote.");
    }
}
