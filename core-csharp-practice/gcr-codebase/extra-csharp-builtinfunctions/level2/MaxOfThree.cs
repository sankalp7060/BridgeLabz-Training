using System;

class MaxOfThree{
    static void Main(){
        // Take inputs
        int a = ReadNumber("Enter first number:- ");
        int b = ReadNumber("Enter second number:- ");
        int c = ReadNumber("Enter third number:- ");

        // Find maximum
        int max = FindMax(a, b, c);

        Console.WriteLine("Maximum number is: " + max);
    }

    // Reads integer input
    static int ReadNumber(string message){
        Console.WriteLine(message);
        return int.Parse(Console.ReadLine());
    }

    // Finds maximum of three numbers
    static int FindMax(int a, int b, int c){
        int max = a;
        if(b > max) max = b;
        if(c > max) max = c;
        return max;
    }
}
