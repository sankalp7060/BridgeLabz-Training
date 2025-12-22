using System;

class DivisibleByFive{
    //Main()
    public static void Main(String[] args){
        Console.WriteLine("Enter the number:- ");
        int num = int.Parse(Console.ReadLine()); //User given number
        //Check the number is divisible by 5 or not
        if( num % 5 == 0){
            Console.WriteLine("The given number is divisible by 5")
        }
        else{
            Console.WriteLine("The given number is not divisible by 5")
        }
    }
}
