using System;
using System.IO;

class WriteEmployeeCSV
{
    static void Main()
    {
        string file = "employees.csv";

        string[] data =
        {
            "ID,Name,Department,Salary",
            "1,Amit,IT,50000",
            "2,Riya,HR,45000",
            "3,Rahul,Finance,60000",
            "4,Pooja,IT,55000",
            "5,Karan,Sales,48000",
        };

        File.WriteAllLines(file, data);

        Console.WriteLine("Employee CSV Created Successfully");
    }
}
