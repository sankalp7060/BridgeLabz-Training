public class Student
{
    public string Name { get; set; }
    public int Marks { get; set; }
    public string District { get; set; }

    public Student(string name, int marks, string district)
    {
        Name = name;
        Marks = marks;
        District = district;
    }
}
