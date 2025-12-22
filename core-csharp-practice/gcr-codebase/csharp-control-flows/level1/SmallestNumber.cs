using System;

class SmallestNumber{
    //Main()
    public static void Main(String[] args){
        Console.WriteLine("Enter the first number:- ");
        int a = int.Parse(Console.ReadLine()); //First number input
        Console.WriteLine("Enter the Second number:- ");
        int b = int.Parse(Console.ReadLine()); //Second number input
        Console.WriteLine("Enter the Third number:- ");
        int c = int.Parse(Console.ReadLine()); //Third number input
        //Check that the first number is the smallest or not
        if(a < b && a < c){ 
            Console.WriteLine("The First number is the smallest number");
        }
        else { 
            Console.WriteLine("The First number is not the smallest number");
        }
    }
}
