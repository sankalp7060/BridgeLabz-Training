using System;

class PalindromeCheck{
    // Main method: Entry point of the program
    static void Main(){
        // Prompt user to enter a string
        Console.WriteLine("Enter a string:- ");
        string s = Console.ReadLine(); // User input

        // Call method to check if the string is palindrome
        if(IsPalindrome(s)){
            Console.WriteLine("The string is a palindrome"); // If palindrome
        }
        else{
            Console.WriteLine("The string is not a palindrome"); // If not palindrome
        }
    }

    // Method to check if a string reads the same forwards and backwards
    static bool IsPalindrome(string s){
        int start = 0; // Start index
        int end = s.Length-1; // End index

        // Loop from start to end
        while(start < end){
            if(s[start] != s[end]) return false; // If mismatch, not palindrome
            start++; // Move forward
            end--;   // Move backward
        }
        return true; // If all characters match, it is palindrome
    }
}
