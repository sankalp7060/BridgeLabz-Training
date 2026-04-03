using System;
using System.Collections.Generic;

class PowerSet
{
    public List<string> AllPossibleStrings(String s)
    {
        List<string> a = new List<string>();
        Generate(s, 0, "", a);
        a.Sort();
        return a;
    }

    public void Generate(string s, int i, string current, List<string> a)
    {
        if (i == s.Length)
        {
            if (current.Length > 0)
            {
                a.Add(current);
            }
            return;
        }
        Generate(s, i + 1, current + s[i], a);
        Generate(s, i + 1, current, a);
    }
}
