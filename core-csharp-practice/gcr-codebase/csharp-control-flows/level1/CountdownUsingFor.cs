using System;

class CountdownUsingFor{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the counter:- ");
        int n = int.Parse(Console.ReadLine()); //Input from User

        //Counter
        for (int i = n; i >= 1; i--)
            Console.WriteLine(i);
    }
}
