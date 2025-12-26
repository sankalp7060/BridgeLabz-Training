using System;

class RemoveDuplicates{
    // Main method: Program execution starts here
    static void Main(){
        // Ask user for input string
        Console.WriteLine("Enter a string:- ");
        string s = Console.ReadLine(); // User input

        // Call method to remove duplicate characters
        string result = RemoveDuplicateChars(s);

        // Display modified string
        Console.WriteLine("Modified string: " + result);
    }

    // Method to remove duplicate characters from a string
    static string RemoveDuplicateChars(string s){
        string result = ""; // Stores unique characters

        // Loop through each character of the string
        for(int i=0; i<s.Length; i++){
            // Add character only if it is not already present
            if(!result.Contains(s[i].ToString())){
                result += s[i];
            }
        }
        return result; // Return string without duplicates
    }
}
