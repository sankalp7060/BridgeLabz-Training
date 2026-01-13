using System;
using System.Diagnostics;
using System.Text;

class StringConcatComparison
{
    static void Main()
    {
        int n = 100_000;

        Stopwatch sw = Stopwatch.StartNew();
        string s = "";
        for (int i = 0; i < n; i++)
            s += "a";
        sw.Stop();
        Console.WriteLine($"string: {sw.ElapsedMilliseconds} ms");

        sw.Restart();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
            sb.Append("a");
        sw.Stop();
        Console.WriteLine($"StringBuilder: {sw.ElapsedMilliseconds} ms");
    }
}
