using System;

class Faculty
{
    public string Name;
    public string Subject;

    public Faculty(string name, string subject)
    {
        Name = name;
        Subject = subject;
    }

    public void Display()
    {
        Console.WriteLine($"Faculty: {Name}, Subject: {Subject}");
    }
}

class Department
{
    public string DeptName;
    public Faculty[] Faculties;
    private int facultyCount = 0;

    public Department(string name, int facultyCapacity)
    {
        DeptName = name;
        Faculties = new Faculty[facultyCapacity];
    }

    public void AddFaculty(Faculty faculty)
    {
        if (facultyCount < Faculties.Length)
        {
            Faculties[facultyCount++] = faculty;
        }
    }

    public void ShowFaculties()
    {
        Console.WriteLine($"Department: {DeptName}");
        for (int i = 0; i < facultyCount; i++)
        {
            Faculties[i].Display();
        }
    }
}

class University
{
    public string Name;
    public Department[] Departments;
    private int deptCount = 0;

    public University(string name, int deptCapacity)
    {
        Name = name;
        Departments = new Department[deptCapacity]; // Composition
    }

    public void AddDepartment(string deptName, int facultyCapacity)
    {
        if (deptCount < Departments.Length)
        {
            Departments[deptCount++] = new Department(deptName, facultyCapacity);
        }
    }

    public void ShowUniversity()
    {
        Console.WriteLine($"University: {Name}");
        for (int i = 0; i < deptCount; i++)
        {
            Departments[i].ShowFaculties();
        }
    }
}

// Demo
class UniversityFacultyDeparment
{
    static void Main()
    {
        University uni = new University("Global University", 2);

        uni.AddDepartment("Computer Science", 3);
        uni.AddDepartment("Physics", 2);

        Faculty f1 = new Faculty("Dr. Smith", "AI");
        Faculty f2 = new Faculty("Dr. Johnson", "Quantum Mechanics");

        uni.Departments[0].AddFaculty(f1);
        uni.Departments[1].AddFaculty(f2);

        uni.ShowUniversity();

        Console.WriteLine("Faculty can exist independently:");
        f1.Display();
        f2.Display();
    }
}
