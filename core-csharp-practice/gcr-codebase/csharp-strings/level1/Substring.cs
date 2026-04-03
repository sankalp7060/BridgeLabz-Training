using System;

class SubstringUsingCharAt{
    //Main()
    static void Main(){
        Console.WriteLine("Enter a string:- ");
        string s = Console.ReadLine(); //User input string
        Console.WriteLine("Enter start index:- ");
        int start = int.Parse(Console.ReadLine()); //Start index
        Console.WriteLine("Enter end index:- ");
        int end = int.Parse(Console.ReadLine()); //End index

        string sub = CreateSubstring(s, start, end);
        Console.WriteLine("Substring using charAt: " + sub);

        //Compare with built-in Substring
        Console.WriteLine("Using string.Substring(): " + s.Substring(start, end-start));
    }

    //Method to create substring using charAt
    static string CreateSubstring(string s, int start, int end){
        string result = "";
        for(int i=start; i<end; i++){
            result += s[i];
        }
        return result;
    }
}
