using System;

class SimpleInterest{
    //Main()
    static void Main(){
        Console.WriteLine("Enter principal:- ");
        int principal = int.Parse(Console.ReadLine()); //User given principal value
        Console.WriteLine("Enter rate:- ");
        int rate = int.Parse(Console.ReadLine()); //User given rate value
        Console.WriteLine("Enter time:- ");
        int time = int.Parse(Console.ReadLine()); //User given time value
        double simpleInterest = SI(principal, rate, time); //Call method to get simple interest from the given data
        Console.WriteLine("Simple Interest:- "+simpleInterest); //Output
    }

    //Method to calculate SI
    static double SI(int principal, int rate, int time){
        double simpleInterest = ((principal * rate * time) / 100); //Calculate simple interest using mathematical formula
        return simpleInterest; //return the result
    }
}