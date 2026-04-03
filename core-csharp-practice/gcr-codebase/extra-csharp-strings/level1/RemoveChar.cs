using System;

class RemoveChar{
    // Main method
    static void Main(){
        Console.WriteLine("Enter a string:- ");
        string s = Console.ReadLine();

        Console.WriteLine("Enter character to remove:- ");
        char ch = Console.ReadLine()[0];

        string result = RemoveCharacter(s, ch);

        Console.WriteLine("Modified String: " + result);
    }

    // Method to remove specific character
    static string RemoveCharacter(string s, char ch){
        string result = "";

        for(int i=0; i<s.Length; i++){
            if(s[i] != ch){
                result += s[i];
            }
        }
        return result;
    }
}
