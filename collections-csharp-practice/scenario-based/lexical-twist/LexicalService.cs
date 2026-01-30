using System;

public class LexicalService : ILexicalService
{
    public void ProcessWords(string word1, string word2)
    {
        if (!StringHelper.IsValidWord(word1))
        {
            Console.WriteLine(word1 + " is an invalid word");
            return;
        }

        if (!StringHelper.IsValidWord(word2))
        {
            Console.WriteLine(word2 + " is an invalid word");
            return;
        }

        if (StringHelper.IsReverse(word1, word2))
        {
            string output = StringHelper.ReverseAndReplaceVowels(word1);
            Console.WriteLine(output);
        }
        else
        {
            string combined = (word1 + word2).ToUpper();

            int vowelCount,
                consonantCount;
            StringHelper.CountVowelsConsonants(combined, out vowelCount, out consonantCount);

            if (vowelCount > consonantCount)
            {
                Console.WriteLine(StringHelper.GetFirstTwoUniqueChars(combined, true));
            }
            else if (consonantCount > vowelCount)
            {
                Console.WriteLine(StringHelper.GetFirstTwoUniqueChars(combined, false));
            }
            else
            {
                Console.WriteLine("Vowels and consonants are equal");
            }
        }
    }
}
