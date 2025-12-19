using System;

class MaxHandshakes{
    //Main()
    static void Main(){
        Console.Write("Enter number of students: ");
        int total_students = int.Parse(Console.ReadLine()); //User given total number of students
        int handshakes = (total_students * (total_students - 1)) / 2; //Formula to calculate maximum handshakes
        Console.WriteLine($"The maximum number of handshakes is {handshakes}"); //Output
    }
}
