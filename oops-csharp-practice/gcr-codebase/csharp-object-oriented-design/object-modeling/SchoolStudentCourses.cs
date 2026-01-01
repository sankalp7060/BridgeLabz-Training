using System;

class Course
{
    public string CourseName;
    public Student[] Students;
    private int count = 0;

    public Course(string name, int capacity)
    {
        CourseName = name;
        Students = new Student[capacity];
    }

    public void AddStudent(Student student)
    {
        if (count < Students.Length)
        {
            Students[count++] = student;
            Console.WriteLine($"{student.Name} enrolled in {CourseName}");
        }
    }

    public void ShowStudents()
    {
        Console.WriteLine($"Students in {CourseName}:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(Students[i].Name);
        }
    }
}

class Student
{
    public string Name;
    public Course[] Courses;
    private int count = 0;

    public Student(string name, int courseCapacity)
    {
        Name = name;
        Courses = new Course[courseCapacity];
    }

    public void EnrollCourse(Course course)
    {
        if (count < Courses.Length)
        {
            Courses[count++] = course;
            course.AddStudent(this); // Association
        }
    }

    public void ShowCourses()
    {
        Console.WriteLine($"{Name} is enrolled in:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(Courses[i].CourseName);
        }
    }
}

class School
{
    public string Name;
    public Student[] Students;
    private int count = 0;

    public School(string name, int capacity)
    {
        Name = name;
        Students = new Student[capacity]; // Aggregation
    }

    public void AddStudent(Student student)
    {
        if (count < Students.Length)
        {
            Students[count++] = student;
            Console.WriteLine($"{student.Name} added to {Name}");
        }
    }
}

// Demo
class Program
{
    static void Main()
    {
        School school = new School("Sunrise School", 3);

        Student s1 = new Student("Alice", 2);
        Student s2 = new Student("Bob", 2);

        school.AddStudent(s1);
        school.AddStudent(s2);

        Course c1 = new Course("Math", 3);
        Course c2 = new Course("Science", 3);

        s1.EnrollCourse(c1);
        s1.EnrollCourse(c2);

        s2.EnrollCourse(c1);

        s1.ShowCourses();
        s2.ShowCourses();

        c1.ShowStudents();
        c2.ShowStudents();
    }
}
