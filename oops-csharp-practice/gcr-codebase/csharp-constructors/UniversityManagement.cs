using System;

class Student
{
    public int rollNumber;
    protected string name;
    private double CGPA;

    // Constructor to initialize rollNumber and name
    public Student(int rollNumber, string name, double CGPA)
    {
        this.rollNumber = rollNumber;
        this.name = name;
        this.CGPA = CGPA;
    }

    public void SetCGPA(double cgpa)
    {
        CGPA = cgpa;
    }

    public double GetCGPA()
    {
        return CGPA;
    }
}

class PostgraduateStudent : Student
{
    public PostgraduateStudent(int rollNumber, string name, double CGPA)
        : base(rollNumber, name, CGPA) { }

    public void Display()
    {
        Console.WriteLine($"Name: {name}");
    }
}

class UniversityManagement
{
    static void Main()
    {
        PostgraduateStudent s = new PostgraduateStudent(1, "Sankalp", 8.5);
        s.Display();
        Console.WriteLine("CGPA: " + s.GetCGPA());
    }
}
