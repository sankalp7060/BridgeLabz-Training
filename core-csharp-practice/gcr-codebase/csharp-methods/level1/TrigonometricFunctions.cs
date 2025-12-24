using System;

class TrigonometricFunctions{
    //Main()
    static void Main(){
        Console.WriteLine("Enter angle in degrees:- ");
        double angle = double.Parse(Console.ReadLine()); //User input angle
        double[] results = CalculateTrigonometricFunctions(angle); //Call method to calculate trigonometric functions
        Console.WriteLine("Sine:- " + results[0]); //Output sine
        Console.WriteLine("Cosine:- " + results[1]); //Output cosine
        Console.WriteLine("Tangent:- " + results[2]); //Output tangent
    }

    //Method to calculate trigonometric functions
    static double[] CalculateTrigonometricFunctions(double angle){
        double rad = angle * Math.PI / 180; //Convert degrees to radians
        double sin = Math.Sin(rad); //Calculate sine
        double cos = Math.Cos(rad); //Calculate cosine
        double tan = Math.Tan(rad); //Calculate tangent
        return new double[]{sin, cos, tan}; //return result
    }
}
