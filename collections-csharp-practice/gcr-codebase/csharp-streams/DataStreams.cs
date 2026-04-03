using System;
using System.IO;

class DataStreams
{
    static void Main()
    {
        string file = "student.dat";

        try
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(file, FileMode.Create)))
            {
                bw.Write(101);
                bw.Write("Rahul");
                bw.Write(8.5);
            }

            using (BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                int roll = br.ReadInt32();
                string name = br.ReadString();
                double gpa = br.ReadDouble();

                Console.WriteLine($"{roll} {name} {gpa}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
