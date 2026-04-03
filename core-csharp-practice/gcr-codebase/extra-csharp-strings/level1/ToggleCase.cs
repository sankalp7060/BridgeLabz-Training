using System;

class ToggleCase{
    // Main method
    static void Main(){
        // User input
        Console.WriteLine("Enter a string:- ");
        string s = Console.ReadLine();

        // Toggle case
        string toggled = Toggle(s);

        // Display result
        Console.WriteLine("Toggled string: " + toggled);
    }

    // Method to toggle case using ASCII values
    static string Toggle(string s){
        string result = "";

        for(int i=0; i<s.Length; i++){
            char c = s[i];

            if(c >= 'a' && c <= 'z'){
                result += (char)(c - 32); // Convert to uppercase
            }
            else if(c >= 'A' && c <= 'Z'){
                result += (char)(c + 32); // Convert to lowercase
            }
            else{
                result += c; // Keep other characters unchanged
            }
        }
        return result;
    }
}
