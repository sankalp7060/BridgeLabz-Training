using System;

class SmallestAndLargest{
    //Main()
    static void Main(){
        Console.WriteLine("Enter first number:- ");
        int num1 = int.Parse(Console.ReadLine()); //User input number1
        Console.WriteLine("Enter second number:- ");
        int num2 = int.Parse(Console.ReadLine()); //User input number2
        Console.WriteLine("Enter third number:- ");
        int num3 = int.Parse(Console.ReadLine()); //User input number3
        int[] result = FindSmallestAndLargest(num1, num2, num3); //Call method to find smallest and largest
        Console.WriteLine("Smallest number:- " + result[0]); //Output smallest
        Console.WriteLine("Largest number:- " + result[1]); //Output largest
    }

    //Method to find smallest and largest
    static int[] FindSmallestAndLargest(int number1, int number2, int number3){
        int smallest = Math.Min(number1, Math.Min(number2, number3)); //Find smallest
        int largest = Math.Max(number1, Math.Max(number2, number3)); //Find largest
        return new int[]{smallest, largest}; //return array containing smallest and largest
    }
}
