using System;
using System.Text;

class RemoveDuplicatesFromString
{
    static void Main()
    {
        string s = "Hello";
        string ans = RemoveDuplicates(s);
        Console.WriteLine(ans);
    }

    static string RemoveDuplicates(string s)
    {
        StringBuilder sb = new StringBuilder();
        bool[] b = new bool[256];
        foreach (char i in s)
        {
            if (!b[i])
            {
                b[i] = true;
                sb.Append(i);
            }
        }
        return sb.ToString();
    }
}
