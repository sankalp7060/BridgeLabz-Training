using System;

class DisplayAllChar{
    //Main()
    static void Main(){
        Console.WriteLine("Enter a string:- ");
        string s = Console.ReadLine(); //User input string

        char[] chars = GetAllChars(s);
        Console.WriteLine("Characters of string:");
        foreach(char c in chars){
            Console.Write(c + " ");
        }

        //Compare with ToCharArray
        Console.WriteLine("\nUsing ToCharArray():");
        foreach(char c in s.ToCharArray()){
            Console.Write(c + " ");
        }
    }

    //Method to return characters without ToCharArray
    static char[] GetAllChars(string s){
        char[] arr = new char[s.Length];
        for(int i=0; i<s.Length; i++){
            arr[i] = s[i];
        }
        return arr;
    }
}
