using System;

class SI{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter principal: ");
        double principal = double.Parse(Console.ReadLine()); //user given principal value
        Console.Write("Enter rate of interest: ");
        double rate = double.Parse(Console.ReadLine()); //user given rate value
        Console.Write("Enter time (years): ");
        double time = double.Parse(Console.ReadLine()); //user given time value
        double simpleInterest = (principal * rate * time) / 100; //formula to calculate Simple Interest
        Console.WriteLine("The Simple Interest is " + simpleInterest + " for Principal " + principal + ", Rate of Interest " + rate + " and Time " + time); //output
    }
}
