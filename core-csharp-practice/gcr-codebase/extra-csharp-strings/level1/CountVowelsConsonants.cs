using System;

class CountVowelsConsonants{
    // Main method: Entry point of the program
    static void Main(){
        // Prompt user to enter a string
        Console.WriteLine("Enter a string:- ");
        string s = Console.ReadLine(); // User input string

        int vowels = 0, consonants = 0; // Initialize counters

        // Call method to count vowels and consonants
        CountVowelsAndConsonants(s, ref vowels, ref consonants);

        // Display the result
        Console.WriteLine("Number of vowels: " + vowels);
        Console.WriteLine("Number of consonants: " + consonants);
    }

    // Method to count vowels and consonants in a string
    static void CountVowelsAndConsonants(string s, ref int vowels, ref int consonants){
        for(int i=0; i<s.Length; i++){
            char c = char.ToLower(s[i]); // Convert character to lowercase for easy comparison
            if(c >= 'a' && c <= 'z'){    // Check if character is an alphabet
                if(c=='a' || c=='e' || c=='i' || c=='o' || c=='u') vowels++; // Vowel check
                else consonants++; // Else it is a consonant
            }
        }
    }
}
