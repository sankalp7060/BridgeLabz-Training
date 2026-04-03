using System;

class LongestWord{
    // Main method
    static void Main(){
        // Ask user to enter a sentence
        Console.WriteLine("Enter a sentence:- ");
        string sentence = Console.ReadLine(); // User input

        // Call method to find longest word
        string longest = FindLongestWord(sentence);

        // Display longest word
        Console.WriteLine("Longest word: " + longest);
    }

    // Method to find the longest word in a sentence
    static string FindLongestWord(string sentence){
        string word = "";     // Stores current word
        string longest = "";  // Stores longest word found

        // Traverse sentence character by character
        for(int i=0; i<sentence.Length; i++){
            if(sentence[i] != ' '){
                word += sentence[i]; // Build word
            }
            else{
                // Compare word length
                if(word.Length > longest.Length){
                    longest = word;
                }
                word = ""; // Reset for next word
            }
        }

        // Check last word
        if(word.Length > longest.Length){
            longest = word;
        }

        return longest; // Return longest word
    }
}
