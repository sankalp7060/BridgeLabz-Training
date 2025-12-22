using System;

class SumUntilZero{
    //Main()
    static void Main(){
        double total = 0.0;
        double value = double.Parse(Console.ReadLine()); //User given input

        //Sum all the values until zero
        while (value != 0){
            total += value;
            value = double.Parse(Console.ReadLine()); //Taking user input until zero
        }

        Console.WriteLine(total); //Output
    }
}
