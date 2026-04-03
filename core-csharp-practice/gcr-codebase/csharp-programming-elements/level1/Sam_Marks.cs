using System;

class Sam_Marks{
    //Main()
    static void Main(String[] args){
        int maths_marks = 94; //Sam's mathematics marks out of 100
        int physics_marks = 95; //Sam's physics marks out of 100
        int chemistry_marks = 96; //Sam's chemistry marks of 100
        int average_marks = (maths_marks + physics_marks + chemistry_marks) / 3; //Average marks of Sam
        Console.WriteLine("Sma's Average marks in three subjects:- "+average_marks); //Output
    }
}