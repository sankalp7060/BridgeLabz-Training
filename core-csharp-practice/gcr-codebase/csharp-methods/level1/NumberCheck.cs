using System;

class NumberCheck{
    //Main()
    static void Main(){
        Console.WriteLine("Enter a number:- ");
        int number = int.Parse(Console.ReadLine()); //User given number
        int result = CheckNumber(number); //Call method to check number
        if(result == 1)
            Console.WriteLine("Number is Positive");
        else if(result == -1)
            Console.WriteLine("Number is Negative");
        else
            Console.WriteLine("Number is Zero");
    }

    //Method to check number
    static int CheckNumber(int num){
        if(num > 0) return 1; //Positive number
        else if(num < 0) return -1; //Negative number
        else return 0; //Zero
    }
}
