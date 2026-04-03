using System;
using System.IO;
using System.Text;

class EncryptCSV
{
    static string Encrypt(string text)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
    }

    static string Decrypt(string text)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(text));
    }

    static void Main()
    {
        string salary = Encrypt("50000");

        File.WriteAllText("secure.csv", salary);

        string read = File.ReadAllText("secure.csv");

        Console.WriteLine("Decrypted Salary = " + Decrypt(read));
    }
}
