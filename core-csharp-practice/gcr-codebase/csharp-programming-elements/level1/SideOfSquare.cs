using System;

class SquareSide{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter perimeter: ");
        double perimeter = double.Parse(Console.ReadLine()); //User given perimeter value
        double side = perimeter / 4; //Formula to calulate side of a sqaure
        Console.WriteLine($"The length of the side is {side} whose perimeter is {perimeter}"); //Output
    }
}
