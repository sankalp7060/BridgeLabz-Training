using System;

class MaximumHandShake{
    //Main()
    static void Main(){
        Console.WriteLine("Enter number of students:- ");
        int numberOfStudents = int.Parse(Console.ReadLine()); //User given number of students
        int maxHandshakes = CalculateHandshakes(numberOfStudents); //Call method to calculate maximum handshakes
        Console.WriteLine("Maximum Handshakes possible:- " + maxHandshakes); //Output
    }

    //Method to calculate maximum handshakes
    static int CalculateHandshakes(int n){
        int handshakes = (n * (n - 1)) / 2; //Combination formula nC2 to calculate handshakes
        return handshakes; //return result
    }
}
