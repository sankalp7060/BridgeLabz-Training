using System;

class BMI{
    static void Main(){
        Console.WriteLine("Enter weight, height of user:- ");
        double weight = double.Parse(Console.ReadLine()); //User's weight
        double heightCm = double.Parse(Console.ReadLine()); //User's height

        double heightM = heightCm / 100; //Calculate height in meter
        double bmi = weight / (heightM * heightM); //Calculating BMI

        Console.WriteLine("BMI is " + bmi); //Output

        //Conditions to check whether a person is fit or not
        if (bmi < 18.5)
            Console.WriteLine("Underweight");
        else if (bmi < 25)
            Console.WriteLine("Normal");
        else if (bmi < 30)
            Console.WriteLine("Overweight");
        else
            Console.WriteLine("Obese");
    }
}
