using System;

class Simple_Interest{
    // Main
    public static void Main(string[] args){
        Console.WriteLine("Enter Principal:- ");
        int principal = int.Parse(Console.ReadLine()); // take principal
        Console.WriteLine("Enter Rate:- ");
        int rate = int.Parse(Console.ReadLine()); // take rate
        Console.WriteLine("Enter Time:- ");
        int time = int.Parse(Console.ReadLine()); // take time
        double SI = (principal * rate * time) / 100; // calculate simple interest
        Console.WriteLine("Simple Interest:- " + SI); // output
    }
}
