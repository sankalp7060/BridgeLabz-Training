using System;
using System.Text;

class StringReverse
{
    static void Main()
    {
        string s = "Hello";
        string reverseString = Reverse(s);
        Console.WriteLine(reverseString);
    }

    static string Reverse(string s)
    {
        StringBuilder sb = new StringBuilder(s);
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            char t = sb[i];
            sb[i] = sb[j];
            sb[j] = t;
            i++;
            j--;
        }
        return sb.ToString();
    }
}
