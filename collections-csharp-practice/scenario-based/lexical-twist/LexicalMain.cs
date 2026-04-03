using System;

class LexicalMain
{
    public static void Start()
    {
        ILexicalService service = new LexicalService();

        Console.WriteLine("Enter the first word");
        string firstWord = Console.ReadLine();

        Console.WriteLine("Enter the second word");
        string secondWord = Console.ReadLine();

        service.ProcessWords(firstWord, secondWord);
    }
}
