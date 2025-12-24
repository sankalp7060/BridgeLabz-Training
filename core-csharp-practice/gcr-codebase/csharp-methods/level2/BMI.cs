using System;

class BMI{
    //Main()
    static void Main(){
        double[,] data = new double[10,3]; //2D array for weight, height, BMI

        for(int i = 0; i < 10; i++){
            Console.WriteLine("Enter weight (kg):- ");
            data[i,0] = double.Parse(Console.ReadLine()); //Weight

            Console.WriteLine("Enter height (cm):- ");
            data[i,1] = double.Parse(Console.ReadLine()); //Height

            data[i,2] = CalculateBMI(data[i,0], data[i,1]); //Calculate BMI
        }

        for(int i = 0; i < 10; i++){
            Console.WriteLine("BMI:- " + data[i,2] + " Status:- " + GetBMIStatus(data[i,2]));
        }
    }

    //Method to calculate BMI
    static double CalculateBMI(double weight, double heightCm){
        double heightMeter = heightCm / 100;
        return weight / (heightMeter * heightMeter);
    }

    //Method to get BMI status
    static string GetBMIStatus(double bmi){
        if(bmi < 18.5) return "Underweight";
        if(bmi < 25) return "Normal";
        if(bmi < 30) return "Overweight";
        return "Obese";
    }
}
