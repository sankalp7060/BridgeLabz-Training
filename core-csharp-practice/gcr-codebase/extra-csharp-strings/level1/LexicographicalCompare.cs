using System;

class LexicographicalCompare{
    // Main method
    static void Main(){
        Console.WriteLine("Enter first string:- ");
        string s1 = Console.ReadLine();

        Console.WriteLine("Enter second string:- ");
        string s2 = Console.ReadLine();

        int result = CompareStrings(s1, s2);

        // Display comparison result
        if(result < 0)
            Console.WriteLine($"\"{s1}\" comes before \"{s2}\"");
        else if(result > 0)
            Console.WriteLine($"\"{s2}\" comes before \"{s1}\"");
        else
            Console.WriteLine("Both strings are equal");
    }

    // Method to compare strings lexicographically
    static int CompareStrings(string s1, string s2){
        int minLength = s1.Length < s2.Length ? s1.Length : s2.Length;

        for(int i=0; i<minLength; i++){
            if(s1[i] != s2[i]){
                return s1[i] - s2[i]; // Compare ASCII values
            }
        }
        return s1.Length - s2.Length;
    }
}
