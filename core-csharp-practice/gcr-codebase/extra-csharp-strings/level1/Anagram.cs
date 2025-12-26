using System;

class Anagram{
    // Main method
    static void Main(){
        Console.WriteLine("Enter first string:- ");
        string s1 = Console.ReadLine();

        Console.WriteLine("Enter second string:- ");
        string s2 = Console.ReadLine();

        if(AreAnagrams(s1, s2))
            Console.WriteLine("Strings are anagrams");
        else
            Console.WriteLine("Strings are not anagrams");
    }

    // Method to check if two strings are anagrams
    static bool AreAnagrams(string s1, string s2){
        if(s1.Length != s2.Length) return false;

        int[] freq = new int[256];

        for(int i=0; i<s1.Length; i++){
            freq[s1[i]]++;
            freq[s2[i]]--;
        }

        for(int i=0; i<256; i++){
            if(freq[i] != 0) return false;
        }

        return true;
    }
}
