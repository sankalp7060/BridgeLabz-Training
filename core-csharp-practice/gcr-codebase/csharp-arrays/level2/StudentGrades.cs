using System;

class StudentGrades{
    //Main()
    static void Main(){
        Console.Write("Enter number of students: ");
        int n = int.Parse(Console.ReadLine()); //User given number of students

        double[] physics = new double[n]; // Double array to store physics marks
        double[] chemistry = new double[n]; // Double array to store chemistry marks
        double[] maths = new double[n]; // Double array to store mathematics marks
        double[] percentage = new double[n]; // Double array to store percentage of all subjects
        string[] grade = new string[n]; // String array to store grade of each student

        // User given marks in all the subjects of each student
        for (int i = 0; i < n; i++){
            Console.WriteLine($"Student {i + 1}:");

            do{
                Console.Write("Physics marks: ");
                physics[i] = double.Parse(Console.ReadLine());
            } while (physics[i] < 0);

            do{
                Console.Write("Chemistry marks: ");
                chemistry[i] = double.Parse(Console.ReadLine());
            } while (chemistry[i] < 0);

            do{
                Console.Write("Maths marks: ");
                maths[i] = double.Parse(Console.ReadLine());
            } while (maths[i] < 0);

            // Calculate percentage of each student
            percentage[i] = (physics[i] + chemistry[i] + maths[i]) / 3.0;

            // Determine grade of each student
            if (percentage[i] >= 90) grade[i] = "A";
            else if (percentage[i] >= 75) grade[i] = "B";
            else if (percentage[i] >= 60) grade[i] = "C";
            else grade[i] = "D";
        }

        // Display results
        Console.WriteLine("\nPhysics  Chemistry  Maths  %  Grade");
        for (int i = 0; i < n; i++){
            Console.WriteLine($"{physics[i]}  {chemistry[i]}  {maths[i]}  {percentage[i]:F2}  {grade[i]}");
        }
    }
}
