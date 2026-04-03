using System;

class OddEvenNumber{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the number:- ");
        int n = int.Parse(Console.ReadLine());

        //Print all the odd and even number using for loop
        for (int i = 1; i <= n; i++)
        {
            if (i % 2 == 0)
                Console.WriteLine(i + " is even");
            else
                Console.WriteLine(i + " is odd");
        }
    }
}
