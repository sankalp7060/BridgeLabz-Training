using System;

class PoundsToKg{
    //Main()
    static void Main(String[] args){
        Console.Write("Enter weight in pounds: ");
        double weightPounds = double.Parse(Console.ReadLine()); //user given wieght value in pounds
        double weightKg = weightPounds / 2.2; //Formula to convert pounds to kilograms
        Console.WriteLine("The weight of the person in pounds is " + weightPounds + " and in kg is " + weightKg); //output
    }
}
