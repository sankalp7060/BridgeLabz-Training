using System;
using System.Diagnostics;
using System.IO;

class BufferStream
{
    static void Main()
    {
        string source = "Practice.txt";
        string destBuffered = "Buffered_Copy.txt";
        string destNormal = "Normal_Copy.txt";

        CopyWithNormalStream(source, destNormal);
        CopyWithBufferedStream(source, destBuffered);
    }

    static void CopyWithNormalStream(string src, string dest)
    {
        Stopwatch sw = Stopwatch.StartNew();

        using (FileStream fsRead = new FileStream(src, FileMode.Open))
        using (FileStream fsWrite = new FileStream(dest, FileMode.Create))
        {
            byte[] buffer = new byte[4096];
            int bytesRead;

            while ((bytesRead = fsRead.Read(buffer, 0, buffer.Length)) > 0)
            {
                fsWrite.Write(buffer, 0, bytesRead);
            }
        }

        sw.Stop();
        Console.WriteLine("Normal Stream Time: " + sw.ElapsedMilliseconds + " ms");
    }

    static void CopyWithBufferedStream(string src, string dest)
    {
        Stopwatch sw = Stopwatch.StartNew();

        using (FileStream fsRead = new FileStream(src, FileMode.Open))
        using (FileStream fsWrite = new FileStream(dest, FileMode.Create))
        using (BufferedStream bsRead = new BufferedStream(fsRead))
        using (BufferedStream bsWrite = new BufferedStream(fsWrite))
        {
            byte[] buffer = new byte[4096];
            int bytesRead;

            while ((bytesRead = bsRead.Read(buffer, 0, buffer.Length)) > 0)
            {
                bsWrite.Write(buffer, 0, bytesRead);
            }
        }

        sw.Stop();
        Console.WriteLine("Buffered Stream Time: " + sw.ElapsedMilliseconds + " ms");
    }
}
