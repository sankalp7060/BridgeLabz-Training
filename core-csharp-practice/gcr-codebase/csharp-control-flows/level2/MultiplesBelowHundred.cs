using System;

class MultiplesBelowHundred{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the number");
        int number = int.Parse(Console.ReadLine());

        //Displaying the multiples of a number using the for loop
        for (int i = 100; i >= 1; i--)
        {
            if (i % number == 0)
                Console.WriteLine(i); //Output
        }
    }
}
