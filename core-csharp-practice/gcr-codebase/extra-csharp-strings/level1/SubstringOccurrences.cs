using System;

class SubstringOccurrences{
    // Main method
    static void Main(){
        // Input main string
        Console.WriteLine("Enter a string:- ");
        string text = Console.ReadLine();

        // Input substring
        Console.WriteLine("Enter substring to search:- ");
        string sub = Console.ReadLine();

        // Call method to count occurrences
        int count = CountOccurrences(text, sub);

        // Display result
        Console.WriteLine("Substring occurs " + count + " times");
    }

    // Method to count how many times substring occurs
    static int CountOccurrences(string text, string sub){
        int count = 0;

        // Loop through text
        for(int i=0; i <= text.Length - sub.Length; i++){
            bool match = true;

            // Check substring match
            for(int j=0; j<sub.Length; j++){
                if(text[i + j] != sub[j]){
                    match = false;
                    break;
                }
            }

            if(match) count++; // Increase count if matched
        }

        return count;
    }
}
