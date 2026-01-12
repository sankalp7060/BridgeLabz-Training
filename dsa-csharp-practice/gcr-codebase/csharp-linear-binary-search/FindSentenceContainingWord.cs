using System;

class FindSentenceContainingWord
{
    static void Main()
    {
        string[] sentences = { "Hello world", "C# is powerful", "Learning search algorithms" };

        string word = "search";

        foreach (string s in sentences)
        {
            if (s.ToLower().Contains(word.ToLower()))
            {
                Console.WriteLine(s);
                return;
            }
        }
        Console.WriteLine("Not found");
    }
}
