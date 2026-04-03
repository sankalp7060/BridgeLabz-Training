using System;

class CountdownUsingWhile{
    //Main()
    public static void Main(){
        Console.WriteLine("Eneter the counter:- ");
        int counter = int.Parse(Console.ReadLine()); //Input from User

        //Countdown Starts
        while (counter >= 1){
            Console.WriteLine(counter);
            counter--;
        }
    }
}
