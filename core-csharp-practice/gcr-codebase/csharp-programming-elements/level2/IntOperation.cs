using System;

class IntOperation{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter a: ");
        int a = int.Parse(Console.ReadLine()); //User given value of a
        Console.Write("Enter b: ");
        int b = int.Parse(Console.ReadLine()); //User given value of b
        Console.Write("Enter c: ");
        int c = int.Parse(Console.ReadLine()); //User given value of c
        int firstOperation = a + b * c; //First Operation
        int secondOperation = a * b + c; //Second Operation
        int thirdOperation = c + a / b; //Third Operation
        int fourthOperation = a % b + c; //Fourth Operation
        Console.WriteLine("The results of Int Operations are " + firstOperation + ", " + secondOperation + ", " + thirdOperation + ", and " + fourthOperation);
    }
}
