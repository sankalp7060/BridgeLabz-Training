using System;

public class AsciiMain
{
    public static void Start()
    {
        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();

        IStringTransformer transformer = new StringTransformer();
        string result = transformer.CleanseAndInvert(input);

        if (string.IsNullOrEmpty(result))
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine("The generated key is - " + result);
        }
    }
}
