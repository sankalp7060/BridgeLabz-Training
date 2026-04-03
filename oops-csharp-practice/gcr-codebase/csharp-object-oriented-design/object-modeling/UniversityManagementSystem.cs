using System;

class Course
{
    public string Name;
    public Professor AssignedProfessor;
    public Student[] Students;
    private int studentCount = 0;

    public Course(string name, int capacity)
    {
        Name = name;
        Students = new Student[capacity];
    }

    public void AssignProfessor(Professor professor)
    {
        AssignedProfessor = professor;
        Console.WriteLine($"{professor.Name} assigned to teach {Name}");
    }

    public void EnrollStudent(Student student)
    {
        if (studentCount < Students.Length)
        {
            Students[studentCount++] = student;
            Console.WriteLine($"{student.Name} enrolled in {Name}");
        }
    }

    public void ShowStudents()
    {
        Console.WriteLine($"Course: {Name}, Professor: {AssignedProfessor?.Name}");
        for (int i = 0; i < studentCount; i++)
        {
            Console.WriteLine(Students[i].Name);
        }
    }
}

class Student
{
    public string Name;

    public Student(string name)
    {
        Name = name;
    }
}

class Professor
{
    public string Name;

    public Professor(string name)
    {
        Name = name;
    }
}

// Demo
class UniversityManagementSystem
{
    static void Main()
    {
        Student s1 = new Student("Alice");
        Student s2 = new Student("Bob");

        Professor p1 = new Professor("Dr. Smith");

        Course c1 = new Course("Math", 5);
        c1.AssignProfessor(p1);
        c1.EnrollStudent(s1);
        c1.EnrollStudent(s2);

        c1.ShowStudents();
    }
}
