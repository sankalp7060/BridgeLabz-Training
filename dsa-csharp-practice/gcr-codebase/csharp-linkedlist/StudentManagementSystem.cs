using System;

public interface IStudentList
{
    void AddStudent();
    void DeleteByRollNumber();
    void SearchByRollNumber();
    void DisplayAll();
    void UpdateGrade();
}

public class Student
{
    public int RollNumber { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Grade { get; set; }

    public Student(int rollNumber, string name, int age, string grade)
    {
        RollNumber = rollNumber;
        Name = name;
        Age = age;
        Grade = grade;
    }

    public override string ToString()
    {
        return "----------------------\n"
            + $"Roll No : {RollNumber}\n"
            + $"Name    : {Name}\n"
            + $"Age     : {Age}\n"
            + $"Grade   : {Grade}";
    }
}

public class StudentNode
{
    public Student Data;
    public StudentNode Next;

    public StudentNode(Student student)
    {
        Data = student;
        Next = null;
    }
}

public class StudentLinkedListImpl : IStudentList
{
    private StudentNode head;

    public void AddStudent()
    {
        Console.Write("Enter position: ");
        int pos = int.Parse(Console.ReadLine());

        Student student = ReadStudentDetails();
        StudentNode node = new StudentNode(student);

        if (pos <= 1 || head == null)
        {
            node.Next = head;
            head = node;
            Console.WriteLine("Student added at beginning.");
            return;
        }
        StudentNode temp = head;

        for (int i = 1; i < pos - 1 && temp != null; i++)
        {
            temp = temp.Next;
        }

        if (temp == null)
        {
            Console.WriteLine("Invalid position.");
            return;
        }

        node.Next = temp.Next;
        temp.Next = node;

        Console.WriteLine("Student added at position.");
    }

    public void DeleteByRollNumber()
    {
        Console.Write("Enter Roll Number to delete: ");
        int roll = int.Parse(Console.ReadLine());

        if (head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        if (head.Data.RollNumber == roll)
        {
            head = head.Next;
            Console.WriteLine("Student deleted.");
            return;
        }

        StudentNode temp = head;
        while (temp.Next != null && temp.Next.Data.RollNumber != roll)
        {
            temp = temp.Next;
        }

        if (temp.Next == null)
        {
            Console.WriteLine("Student not found.");
        }
        else
        {
            temp.Next = temp.Next.Next;
            Console.WriteLine("Student deleted.");
        }
    }

    public void SearchByRollNumber()
    {
        Console.Write("Enter Roll Number to search: ");
        int roll = int.Parse(Console.ReadLine());

        StudentNode temp = head;
        while (temp != null)
        {
            if (temp.Data.RollNumber == roll)
            {
                Console.WriteLine(temp.Data);
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Student not found.");
    }

    public void UpdateGrade()
    {
        Console.Write("Enter Roll Number: ");
        int roll = int.Parse(Console.ReadLine());

        StudentNode temp = head;
        while (temp != null)
        {
            if (temp.Data.RollNumber == roll)
            {
                Console.Write("Enter new Grade: ");
                temp.Data.Grade = Console.ReadLine();
                Console.WriteLine("Grade updated.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Student not found.");
    }

    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("No records found.");
            return;
        }

        StudentNode temp = head;
        while (temp != null)
        {
            Console.WriteLine(temp.Data);
            temp = temp.Next;
        }
    }

    private Student ReadStudentDetails()
    {
        Console.Write("Enter Roll Number: ");
        int roll = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter Grade: ");
        string grade = Console.ReadLine();

        return new Student(roll, name, age, grade);
    }
}

public class StudentMenu
{
    private IStudentList studentList;

    public StudentMenu(IStudentList list)
    {
        studentList = list;
    }

    public void ShowMenu()
    {
        Console.WriteLine("\n1. Add student");
        Console.WriteLine("2. Delete by Roll Number");
        Console.WriteLine("3. Search by Roll Number");
        Console.WriteLine("4. Display All");
        Console.WriteLine("5. Update Grade");
        Console.WriteLine("0. Exit");

        Console.Write("Enter choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                studentList.AddStudent();
                break;
            case 2:
                studentList.DeleteByRollNumber();
                break;
            case 3:
                studentList.SearchByRollNumber();
                break;
            case 4:
                studentList.DisplayAll();
                break;
            case 5:
                studentList.UpdateGrade();
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }

        ShowMenu();
    }
}

public class StudentMain
{
    public static void Start()
    {
        IStudentList list = new StudentLinkedListImpl();
        StudentMenu menu = new StudentMenu(list);
        menu.ShowMenu();
    }
}

class StudentManagementSystem
{
    static void Main(string[] args)
    {
        StudentMain.Start();
    }
}
