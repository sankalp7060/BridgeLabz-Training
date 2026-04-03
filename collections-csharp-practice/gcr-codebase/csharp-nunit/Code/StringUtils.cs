using System;

namespace Code;

public class StringUtils
{
    public string Reverse(string str)
    {
        if (str == null) return null;
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    public bool IsPalindrome(string str)
    {
        if (str == null) return false;
        str = str.ToLower();
        return str == Reverse(str).ToLower();
    }

    public string ToUpperCase(string str) => str?.ToUpper();
}
