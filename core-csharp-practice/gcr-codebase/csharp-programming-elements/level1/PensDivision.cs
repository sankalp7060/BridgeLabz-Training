using System;

class PensDivision{
    //Main()
    static void Main(String[] args){
        int total_Pens = 14; //Total pens
        int total_Students = 3; //Total students
        int pensPerStudent = total_Pens / total_Students; //Calculate pens that each student get
        int remainingPens = total_Pens % total_Students; //Calculate the remaining pens
        Console.WriteLine($"The Pen Per Student is {pensPerStudent} and the remaining pen not distributed is {remainingPens}"); //Output
    }
}
