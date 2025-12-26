using System;

class CompareTwoStrings{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the first string:- ");
        string s1 = Console.ReadLine(); //User given string one
        Console.WriteLine("Enter the second string:- ");
        string s2 = Console.ReadLine(); //User given string two
        bool isCompare = Compare(s1, s2);

        //If two strings are equal then print both strings are equal otherwise not
        if(isCompare){
            Console.WriteLine("Two strings are equal");
        }
        else{
            Console.WriteLine("Two strings are not equal");
        }
    }
    //Method to compare two strings
    static bool Compare(string s1, string s2){

        if(s1.Length != s2.Length) return false;
        
        for(int i = 0; i < s1.Length; i++){
            if(s1[i] != s2[i]) return false;
        }
        return true;
    }
}