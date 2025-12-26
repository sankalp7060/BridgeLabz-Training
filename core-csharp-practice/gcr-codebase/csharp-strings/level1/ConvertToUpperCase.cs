using System;

class ConvertToUpperCase{
    static void Main(){
        Console.WriteLine("Enter a string:- ");
        string s = Console.ReadLine(); //User input

        string upper = ToUppercase(s);
        Console.WriteLine("Using ASCII logic: " + upper);
        Console.WriteLine("Using string.ToUpper(): " + s.ToUpper());
    }

    //Method to convert string to uppercase using ASCII
    static string ToUppercase(string s){
        string result = "";
        for(int i=0; i<s.Length; i++){
            char c = s[i];
            if(c >= 'a' && c <= 'z'){
                c = (char)(c - 32);
            }
            result += c;
        }
        return result;
    }
}
