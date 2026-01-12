using System;
using System.Diagnostics;
using System.Text;

class ComparePerformance
{
    static void Main()
    {
        int n = 100000;

        Stopwatch sw = Stopwatch.StartNew();
        string s = "";
        for (int i = 0; i < n; i++)
            s += i;
        sw.Stop();
        Console.WriteLine("String time: " + sw.ElapsedMilliseconds);

        sw.Restart();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
            sb.Append(i);
        sw.Stop();
        Console.WriteLine("StringBuilder time: " + sw.ElapsedMilliseconds);
    }
}
