using System;

class Course
{
    string courseName;
    int duration;
    double fee;
    static string instituteName = "BridgeLabz";

    public Course(string name, int duration, double fee)
    {
        courseName = name;
        this.duration = duration;
        this.fee = fee;
    }

    public void DisplayCourseDetails()
    {
        Console.WriteLine($"{courseName} | {duration} months | ₹{fee} | {instituteName}");
    }

    public static void UpdateInstituteName(string name)
    {
        instituteName = name;
    }

    static void Main()
    {
        Course.UpdateInstituteName("Tech Institute");
        Course c = new Course("C#", 3, 15000);
        c.DisplayCourseDetails();
    }
}
