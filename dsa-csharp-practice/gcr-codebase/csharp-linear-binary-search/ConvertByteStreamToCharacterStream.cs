using System;
using System.IO;

class ConvertByteStreamToCharacterStream
{
    static void Main()
    {
        using FileStream fs = new FileStream("test.txt", FileMode.Open);
        using StreamReader sr = new StreamReader(fs);
        Console.WriteLine(sr.ReadToEnd());
    }
}
