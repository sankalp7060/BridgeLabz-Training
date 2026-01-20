using System;
using System.Collections.Generic;

class PermutationOfString
{
    public List<string> FindPermutation(string s)
    {
        List<string> result = new List<string>();
        char[] chars = s.ToCharArray();
        Array.Sort(chars);
        bool[] used = new bool[chars.Length];
        Backtrack(chars, used, new System.Text.StringBuilder(), result);
        return result;
    }

    private void Backtrack(
        char[] chars,
        bool[] used,
        System.Text.StringBuilder sb,
        List<string> result
    )
    {
        if (sb.Length == chars.Length)
        {
            result.Add(sb.ToString());
            return;
        }

        for (int i = 0; i < chars.Length; i++)
        {
            if (used[i])
                continue;

            if (i > 0 && chars[i] == chars[i - 1] && !used[i - 1])
                continue;

            used[i] = true;
            sb.Append(chars[i]);
            Backtrack(chars, used, sb, result);
            sb.Length--;
            used[i] = false;
        }
    }
}
