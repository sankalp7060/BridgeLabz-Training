using System;

class ConvertToLowercase{
    static void Main(){
        Console.WriteLine("Enter a string:- ");
        string s = Console.ReadLine(); //User input

        string lower = ToLowercase(s);
        Console.WriteLine("Using ASCII logic: " + lower);
        Console.WriteLine("Using string.ToLower(): " + s.ToLower());
    }

    //Method to convert string to lowercase using ASCII
    static string ToLowercase(string s){
        string result = "";
        for(int i=0; i<s.Length; i++){
            char c = s[i];
            if(c >= 'A' && c <= 'Z'){
                c = (char)(c + 32);
            }
            result += c;
        }
        return result;
    }
}
