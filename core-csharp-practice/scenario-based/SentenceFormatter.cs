using System;

class SentenceFormatter
{
    private string paragraph = "";

    public static void Main()
    {
        SentenceFormatter app = new SentenceFormatter();
        app.Run();
    }

    private void Run()
    {
        // STEP 1: Force valid paragraph input
        while (true)
        {
            Console.Write("Enter your paragraph: ");
            paragraph = Console.ReadLine();
            if (paragraph == null)
                paragraph = "";

            bool onlySpaces = true;
            for (int i = 0; i < GetLength(paragraph); i++)
            {
                if (paragraph[i] != ' ')
                {
                    onlySpaces = false;
                    break;
                }
            }

            if (GetLength(paragraph) == 0 || onlySpaces)
            {
                Console.WriteLine(" Paragraph cannot be empty or only spaces.\n");
            }
            else
            {
                break;
            }
        }

        // STEP 2: MENU
        while (true)
        {
            Console.WriteLine(
                "\n=============================================================================================================="
            );
            Console.WriteLine("                                  PARAGRAPH ANALYTICS MENU");
            Console.WriteLine(
                "==============================================================================================================\n"
            );
            Console.WriteLine("                                    1. Correct Paragraph");
            Console.WriteLine("                                    2. Count Words");
            Console.WriteLine("                                    3. Find Longest Word");
            Console.WriteLine("                                    4. Replace Word");
            Console.WriteLine("                                    5. Exit\n");
            Console.Write("Select option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    paragraph = CorrectedPara(paragraph);
                    Console.WriteLine("\nCorrected Paragraph:\n" + paragraph);
                    break;

                case "2":
                    Console.WriteLine("\nWord Count: " + CountWords(paragraph));
                    break;

                case "3":
                    Console.WriteLine("\nLongest Word: " + FindLongestWord(paragraph));
                    break;

                case "4":
                    paragraph = ReplaceWordFlow(paragraph);
                    break;

                case "5":
                    Console.WriteLine("Exiting program.");
                    return;

                default:
                    Console.WriteLine(" Invalid choice. Try again.");
                    break;
            }
        }
    }

    // METHODS

    private string CorrectedPara(string para)
    {
        para = TrimSpaces(para);
        para = RemoveExtraSpaces(para);
        para = Capitalize(para);
        return para;
    }

    private string TrimSpaces(string para)
    {
        int start = 0,
            end = GetLength(para) - 1;
        while (start <= end && para[start] == ' ')
            start++;
        while (end >= start && para[end] == ' ')
            end--;

        string ans = "";
        for (int i = start; i <= end; i++)
            ans += para[i];
        return ans;
    }

    private string RemoveExtraSpaces(string para)
    {
        string ans = "";
        bool space = false;

        for (int i = 0; i < GetLength(para); i++)
        {
            if (para[i] == ' ')
            {
                if (!space)
                {
                    ans += ' ';
                    space = true;
                }
            }
            else
            {
                ans += para[i];
                space = false;
            }
        }
        return ans;
    }

    private string Capitalize(string para)
    {
        string ans = "";
        bool cap = true;

        for (int i = 0; i < GetLength(para); i++)
        {
            char ch = para[i];

            if (cap && ch >= 'a' && ch <= 'z')
            {
                ch = (char)(ch - 32);
                cap = false;
            }
            else if (cap && ch >= 'A' && ch <= 'Z')
            {
                cap = false;
            }
            else if (!cap && ch >= 'A' && ch <= 'Z')
            {
                ch = (char)(ch + 32);
            }
            ans += ch;

            if (ch == '.' || ch == '?' || ch == '!')
                cap = true;
        }
        return ans;
    }

    private int CountWords(string para)
    {
        int count = 0;
        bool inWord = false;

        for (int i = 0; i < GetLength(para); i++)
        {
            char ch = para[i];

            if ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z'))
            {
                if (!inWord)
                {
                    count++;
                    inWord = true;
                }
            }
            else
            {
                inWord = false;
            }
        }
        return count;
    }

    private string FindLongestWord(string para)
    {
        string longest = "";
        string current = "";

        for (int i = 0; i < GetLength(para); i++)
        {
            char ch = para[i];

            if ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z'))
            {
                current += ch;
            }
            else
            {
                if (GetLength(current) > GetLength(longest))
                    longest = current;
                current = "";
            }
        }

        if (GetLength(current) > GetLength(longest))
            longest = current;

        return longest;
    }

    private string ReplaceWordFlow(string paragraph)
    {
        string oldWord = "";
        string newWord = "";

        while (true)
        {
            Console.Write("Enter word to replace: ");
            oldWord = Console.ReadLine();
            if (oldWord == null)
                oldWord = "";
            if (GetLength(oldWord) == 0)
            {
                Console.WriteLine("Word cannot be empty.");
                continue;
            }

            if (WordExists(paragraph, oldWord))
                break;

            Console.WriteLine(" Word not found. Please enter the correct word.");
        }

        Console.Write("Enter new word: ");
        newWord = Console.ReadLine();
        if (newWord == null)
            newWord = "";

        paragraph = ReplaceWord(paragraph, oldWord, newWord);
        Console.WriteLine("\nUpdated Paragraph:\n" + paragraph);

        return paragraph;
    }

    private string ReplaceWord(string para, string oldWord, string newWord)
    {
        string ans = "";
        string current = "";

        for (int i = 0; i < GetLength(para); i++)
        {
            char ch = para[i];

            if ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z'))
            {
                current += ch;
            }
            else
            {
                if (MatchIgnoreCase(current, oldWord))
                    ans += newWord;
                else
                    ans += current;

                current = "";
                ans += ch;
            }
        }

        if (MatchIgnoreCase(current, oldWord))
            ans += newWord;
        else
            ans += current;

        return ans;
    }

    private bool MatchIgnoreCase(string a, string b)
    {
        if (GetLength(a) != GetLength(b))
            return false;

        for (int i = 0; i < GetLength(a); i++)
        {
            char x = a[i],
                y = b[i]; 

            if (x >= 'A' && x <= 'Z')
                x = (char)(x + 32);
            if (y >= 'A' && y <= 'Z')
                y = (char)(y + 32);

            if (x != y)
                return false;
        }
        return true;
    }

    private bool WordExists(string para, string word)
    {
        string current = "";

        for (int i = 0; i < GetLength(para); i++)
        {
            char ch = para[i];

            if ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z'))
            {
                current += ch;
            }
            else
            {
                if (MatchIgnoreCase(current, word))
                    return true;
                current = "";
            }
        }

        return MatchIgnoreCase(current, word);
    }

    private int GetLength(string s)
    {
        int length = 0;
        foreach (char i in s)
        {
            length++;
        }
        return length;
    }
}
