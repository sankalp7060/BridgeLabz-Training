using System;

class SumUntilZeroOrNegative{
    //Main()
    static void Main(){
        double total = 0.0;

        //Sum all values until zero or negative came
        while (true)
        {
            double value = double.Parse(Console.ReadLine()); //taking user input until zero or negative value came
            //Condition to checkthe value whether it is zero or negative if YEs then terminate
            if (value <= 0)
                break;

            total += value;
        }

        Console.WriteLine(total); //Output
    }
}
