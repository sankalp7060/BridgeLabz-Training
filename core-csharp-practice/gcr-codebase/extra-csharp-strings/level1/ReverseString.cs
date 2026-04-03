using System;

class ReverseString{
    // Main method: Entry point of the program
    static void Main(){
        // Prompt user to enter a string
        Console.WriteLine("Enter a string:- ");
        string s = Console.ReadLine(); // User input

        // Call method to reverse the string
        string reversed = Reverse(s);

        // Display the reversed string
        Console.WriteLine("Reversed string: " + reversed);
    }

    // Method to reverse a string manually without using built-in functions
    static string Reverse(string s){
        string result = ""; // Initialize empty string to store result
        for(int i=s.Length-1; i>=0; i--){ // Loop from last character to first
            result += s[i]; // Append each character
        }
        return result; // Return reversed string
    }
}
