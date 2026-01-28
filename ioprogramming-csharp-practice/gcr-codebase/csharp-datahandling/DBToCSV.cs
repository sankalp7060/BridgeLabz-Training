using System;
using System.IO;

class DBToCSV
{
    static void Main()
    {
        string[] dbData = { "1,Amit,IT,50000", "2,Riya,HR,45000" };

        File.WriteAllLines("db_export.csv", dbData);

        Console.WriteLine("DB Exported To CSV");
    }
}
