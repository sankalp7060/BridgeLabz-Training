using System;

class Student
{
    public static string UniversityName = "ABC University";
    private static int totalStudents = 0;

    public string Name;
    public string Grade;
    public readonly int RollNumber;

    public Student(string name, int rollNumber, string grade)
    {
        this.Name = name;
        this.RollNumber = rollNumber;
        this.Grade = grade;
        totalStudents++;
    }

    public static void DisplayTotalStudents()
    {
        Console.WriteLine("Total Students: " + totalStudents);
    }

    public void Display(object obj)
    {
        if (obj is Student)
        {
            Console.WriteLine($"{Name}, Roll No: {RollNumber}, Grade: {Grade}");
        }
    }

    static void Main()
    {
        Student s = new Student("Ravi", 21, "A");
        s.Display(s);
        DisplayTotalStudents();
    }
}
