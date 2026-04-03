using System;

class BMIUsingMultiDimensionalArray{
    //Main()
    static void Main(){
        Console.Write("Enter number of persons: ");
        int n = int.Parse(Console.ReadLine()); //Use given number of person

        double[][] personData = new double[n][]; //2D Double array to store all persons data(weight, Height)
        string[] weightStatus = new string[n]; //String array to store fitness status of all the persons

        // User given weight and height of the person
        for (int i = 0; i < n; i++){
            personData[i] = new double[3];
            Console.WriteLine($"Person {i + 1}:");

            do{
                Console.Write("Weight (kg): ");
                personData[i][0] = double.Parse(Console.ReadLine());
            } while (personData[i][0] <= 0);

            do{
                Console.Write("Height (m): ");
                personData[i][1] = double.Parse(Console.ReadLine());
            } while (personData[i][1] <= 0);

            // Calculate BMI of a person
            personData[i][2] = personData[i][0] / (personData[i][1] * personData[i][1]);

            // Determine weight status  of a person
            double bmi = personData[i][2];
            if (bmi < 18.5) weightStatus[i] = "Underweight";
            else if (bmi < 25) weightStatus[i] = "Normal";
            else if (bmi < 30) weightStatus[i] = "Overweight";
            else weightStatus[i] = "Obese";
        }

        // Display results
        Console.WriteLine("\nWeight(kg)  Height(m)  BMI  Status");
        for (int i = 0; i < n; i++){
            Console.WriteLine($"{personData[i][0]}  {personData[i][1]}  {personData[i][2]:F2}  {weightStatus[i]}");
        }
    }
}
