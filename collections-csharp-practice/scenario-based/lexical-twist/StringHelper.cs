using System;
using System.Text;

public class StringHelper
{
    public static bool IsValidWord(string word)
    {
        return !word.Contains(" ");
    }

    public static bool IsReverse(string word1, string word2)
    {
        char[] arr = word1.ToLower().ToCharArray();
        Array.Reverse(arr);
        return new string(arr) == word2.ToLower();
    }

    public static string ReverseAndReplaceVowels(string word)
    {
        char[] arr = word.ToLower().ToCharArray();
        Array.Reverse(arr);

        for (int i = 0; i < arr.Length; i++)
        {
            if ("aeiou".IndexOf(arr[i]) != -1)
            {
                arr[i] = '@';
            }
        }

        return new string(arr);
    }

    public static void CountVowelsConsonants(string word, out int vowels, out int consonants)
    {
        vowels = consonants = 0;

        foreach (char c in word)
        {
            if ("AEIOU".IndexOf(c) != -1)
                vowels++;
            else if (char.IsLetter(c))
                consonants++;
        }
    }

    public static string GetFirstTwoUniqueChars(string word, bool vowelsRequired)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in word)
        {
            if (result.Length == 2)
                break;

            bool isVowel = "AEIOU".IndexOf(c) != -1;

            if (vowelsRequired && isVowel && result.ToString().IndexOf(c) == -1)
            {
                result.Append(c);
            }
            else if (
                !vowelsRequired
                && !isVowel
                && char.IsLetter(c)
                && result.ToString().IndexOf(c) == -1
            )
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }
}
