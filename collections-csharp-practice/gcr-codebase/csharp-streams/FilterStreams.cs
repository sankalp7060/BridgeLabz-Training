using System;
using System.IO;

class FilterStreams
{
    static void Main()
    {
        try
        {
            using (FileStream fsRead = new FileStream("Practice.txt", FileMode.Open))
            using (BufferedStream bsRead = new BufferedStream(fsRead))
            using (StreamReader sr = new StreamReader(bsRead))

            using (FileStream fsWrite = new FileStream("Lowercase.txt", FileMode.Create))
            using (BufferedStream bsWrite = new BufferedStream(fsWrite))
            using (StreamWriter sw = new StreamWriter(bsWrite))
            {
                string? line; // Nullable
                while ((line = sr.ReadLine()) != null)
                {
                    sw.WriteLine(line.ToLower());
                }
            }

            Console.WriteLine("Conversion complete.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
