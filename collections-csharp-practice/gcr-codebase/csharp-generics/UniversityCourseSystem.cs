using System;
using System.Collections.Generic;

// Abstract base class for course types
public abstract class CourseType
{
    public string CourseName { get; set; }

    protected CourseType(string courseName)
    {
        CourseName = courseName;
    }

    public abstract void DisplayEvaluationType();
}

// Example course types
public class ExamCourse : CourseType
{
    public int ExamDurationMinutes { get; set; }

    public ExamCourse(string name, int duration)
        : base(name)
    {
        ExamDurationMinutes = duration;
    }

    public override void DisplayEvaluationType()
    {
        Console.WriteLine(
            $"Exam Course: {CourseName}, Exam Duration: {ExamDurationMinutes} minutes"
        );
    }
}

public class AssignmentCourse : CourseType
{
    public int NumberOfAssignments { get; set; }

    public AssignmentCourse(string name, int assignments)
        : base(name)
    {
        NumberOfAssignments = assignments;
    }

    public override void DisplayEvaluationType()
    {
        Console.WriteLine($"Assignment Course: {CourseName}, Assignments: {NumberOfAssignments}");
    }
}

// Generic Course class
public class Course<T>
    where T : CourseType
{
    private List<T> courses = new List<T>();

    // Add course
    public void AddCourse(T course)
    {
        courses.Add(course);
        Console.WriteLine($"{course.CourseName} added.");
    }

    // Display all courses
    public void DisplayAllCourses()
    {
        Console.WriteLine("\n--- All Courses ---");
        foreach (var course in courses)
        {
            course.DisplayEvaluationType();
        }
    }
}

// Main Program
class UniversityCourseSystem
{
    static void Main()
    {
        // Exam courses
        Course<ExamCourse> examCourses = new Course<ExamCourse>();
        examCourses.AddCourse(new ExamCourse("Mathematics", 120));
        examCourses.AddCourse(new ExamCourse("Physics", 90));
        examCourses.DisplayAllCourses();

        // Assignment courses
        Course<AssignmentCourse> assignmentCourses = new Course<AssignmentCourse>();
        assignmentCourses.AddCourse(new AssignmentCourse("Literature", 5));
        assignmentCourses.AddCourse(new AssignmentCourse("History", 3));
        assignmentCourses.DisplayAllCourses();
    }
}
