using System;

class BMIUsingArray{
    //Main()
    static void Main(){
        Console.Write("Enter number of persons: ");
        int n = int.Parse(Console.ReadLine()); //User given number of user

        double[] weight = new double[n]; //Double array to store the weight of the users
        double[] height = new double[n]; //Double array to store the height of the users
        double[] bmi = new double[n]; //Double array to store the BMI of the users
        string[] status = new string[n]; //String array to store the fitness status of the user

        // User given weight and height of the person
        for (int i = 0; i < n; i++){
            Console.WriteLine($"Person {i + 1}:");

            do{
                Console.Write("Weight (kg): ");
                weight[i] = double.Parse(Console.ReadLine());
            } while (weight[i] <= 0);

            do{
                Console.Write("Height (m): ");
                height[i] = double.Parse(Console.ReadLine());
            } while (height[i] <= 0);

            // Calculate BMI of a user
            bmi[i] = weight[i] / (height[i] * height[i]);

            // Determine weight status of a user
            if (bmi[i] < 18.5) status[i] = "Underweight";
            else if (bmi[i] < 25) status[i] = "Normal";
            else if (bmi[i] < 30) status[i] = "Overweight";
            else status[i] = "Obese";
        }

        // Display BMI details of a user
        Console.WriteLine("\nHeight(m)  Weight(kg)  BMI  Status");
        for (int i = 0; i < n; i++){
            Console.WriteLine($"{height[i]}  {weight[i]}  {bmi[i]:F2}  {status[i]}");
        }
    }
}
