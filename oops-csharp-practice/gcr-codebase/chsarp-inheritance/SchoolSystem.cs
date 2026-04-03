using System;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Teacher : Person
{
    public string Subject { get; set; }

    public void DisplayRole()
    {
        Console.WriteLine($"Teacher: {Name}, Subject: {Subject}");
    }
}

class Student : Person
{
    public int Grade { get; set; }

    public void DisplayRole()
    {
        Console.WriteLine($"Student: {Name}, Grade: {Grade}");
    }
}

class Staff : Person
{
    public string Department { get; set; }

    public void DisplayRole()
    {
        Console.WriteLine($"Staff: {Name}, Department: {Department}");
    }
}

class SchoolSystem
{
    static void Main()
    {
        Teacher t = new Teacher
        {
            Name = "Mr. Sharma",
            Age = 40,
            Subject = "Math",
        };
        Student s = new Student
        {
            Name = "Aman",
            Age = 15,
            Grade = 10,
        };
        Staff st = new Staff
        {
            Name = "Sonia",
            Age = 30,
            Department = "Library",
        };

        t.DisplayRole();
        s.DisplayRole();
        st.DisplayRole();
    }
}
