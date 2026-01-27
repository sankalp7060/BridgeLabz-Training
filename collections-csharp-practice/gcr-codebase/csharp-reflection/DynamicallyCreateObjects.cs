using System;

class DynamicallyCreateObjects
{
    static void Main()
    {
        Type type = typeof(Student);

        // Dynamically create instance
        object studentObj = Activator.CreateInstance(type);

        // Access property
        type.GetProperty("Name").SetValue(studentObj, "Sankalp");
        string name = (string)type.GetProperty("Name").GetValue(studentObj);

        Console.WriteLine("Student Name: " + name);
    }
}

public class Student
{
    public string Name { get; set; }
}
