using System;
using System.IO;

class ReadUserInput
{
    static void Main()
    {
        try
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            string age = Console.ReadLine();

            Console.Write("Favorite Language: ");
            string lang = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter("Practice.txt", true))
            {
                sw.WriteLine($"Name: {name}");
                sw.WriteLine($"Age: {age}");
                sw.WriteLine($"Language: {lang}");
                sw.WriteLine("------------------");
            }

            Console.WriteLine("Data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
