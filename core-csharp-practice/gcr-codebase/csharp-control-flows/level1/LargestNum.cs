using System;

class LargestNum{
    //Main()
    public static void Main(String[] args){

        Console.WriteLine("Enter the first number:- ");
        int a = int.Parse(Console.ReadLine()); //First number input
        Console.WriteLine("Enter the Second number:- ");
        int b = int.Parse(Console.ReadLine()); //Second number input
        Console.WriteLine("Enter the Third number:- ");
        int c = int.Parse(Console.ReadLine()); //Third number input
        //Check for the largest number
        if(a > b && a > c){
            Console.WriteLine("The first number is the largest one");
        }
        else if(b > a && c > a){
            Console.WriteLine("The second number is the largest one");
        }
        else{
            Console.WriteLine("The third number is the largest one");
        }
    }
}
