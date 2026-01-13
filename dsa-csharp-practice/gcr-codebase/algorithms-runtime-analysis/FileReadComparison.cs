using System;
using System.Diagnostics;
using System.IO;

class FileReadComparison
{
    static void Main()
    {
        string filePath = "largefile.txt";

        Stopwatch sw = Stopwatch.StartNew();
        using (StreamReader sr = new StreamReader(filePath))
        {
            while (sr.ReadLine() != null) { }
        }
        sw.Stop();
        Console.WriteLine($"StreamReader: {sw.ElapsedMilliseconds} ms");

        sw.Restart();
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            byte[] buffer = new byte[8192];
            while (fs.Read(buffer, 0, buffer.Length) > 0) { }
        }
        sw.Stop();
        Console.WriteLine($"FileStream: {sw.ElapsedMilliseconds} ms");
    }
}
