using System;

class StudentGradesUsing2DArray{
    //Main()
    static void Main(){
        Console.Write("Enter number of students: ");
        int n = int.Parse(Console.ReadLine()); // User given number of student

        double[,] marks = new double[n, 3]; // 2D double array to store marks of all students in physics, chemistry, mathematics
        double[] percentage = new double[n]; // Double array to store percentage of each student
        string[] grade = new string[n]; // String array to store of all students

        // User given marks in physics, chemistry, mathematics
        for (int i = 0; i < n; i++){
            Console.WriteLine($"Student {i + 1}:");

            for (int j = 0; j < 3; j++){
                string subject = j == 0 ? "Physics" : j == 1 ? "Chemistry" : "Maths";
                double mark;
                do{
                    Console.Write($"{subject} marks: ");
                    mark = double.Parse(Console.ReadLine());
                } while (mark < 0);
                marks[i, j] = mark;
            }

            //Calculate percentage of each student and store that into the percentage array
            percentage[i] = (marks[i, 0] + marks[i, 1] + marks[i, 2]) / 3.0;

            //Calculate grade of each student and store that into the grade array
            if (percentage[i] >= 90) grade[i] = "A";
            else if (percentage[i] >= 75) grade[i] = "B";
            else if (percentage[i] >= 60) grade[i] = "C";
            else grade[i] = "D";
        }

        // Display results
        Console.WriteLine("\nPhysics  Chemistry  Maths  %  Grade");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{marks[i,0]}  {marks[i,1]}  {marks[i,2]}  {percentage[i]:F2}  {grade[i]}");
        }
    }
}
