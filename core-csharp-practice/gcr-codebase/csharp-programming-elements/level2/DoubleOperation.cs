using System;

class DoubleOperation{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine()); //User given value of a
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine()); //User given value of b
        Console.Write("Enter c: ");
        double c = double.Parse(Console.ReadLine()); //User given value of c
        double optOne = a + b * c; //First operation
        double optTwo = a * b + c; //Second operation
        double optThree = c + a / b; //Third operation
        double optFour = a % b + c; //Four operation
        Console.WriteLine("The results of Double Operations are " + optOne + ", " + optTwo + ", " + optThree + ", and " + optFour); //Output
    }
}
