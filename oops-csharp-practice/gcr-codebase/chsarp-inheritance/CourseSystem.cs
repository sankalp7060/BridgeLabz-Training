using System;

class Course
{
    public string CourseName { get; set; }
    public int Duration { get; set; }
}

class OnlineCourse : Course
{
    public string Platform { get; set; }
    public bool IsRecorded { get; set; }
}

class PaidOnlineCourse : OnlineCourse
{
    public double Fee { get; set; }
    public double Discount { get; set; }
}

class CourseSystem
{
    static void Main()
    {
        PaidOnlineCourse c = new PaidOnlineCourse
        {
            CourseName = "C# Mastery",
            Duration = 30,
            Platform = "Udemy",
            IsRecorded = true,
            Fee = 4999,
            Discount = 20,
        };

        Console.WriteLine(
            $"Course: {c.CourseName}, Duration: {c.Duration} days, Platform: {c.Platform}, Fee: {c.Fee}, Discount: {c.Discount}%"
        );
    }
}
