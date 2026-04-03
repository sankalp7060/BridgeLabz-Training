using System;

class MostFrequentChar{
    // Main method
    static void Main(){
        Console.WriteLine("Enter a string:- ");
        string s = Console.ReadLine();

        char result = FindMostFrequentChar(s);

        Console.WriteLine("Most Frequent Character: '" + result + "'");
    }

    // Method to find most frequent character
    static char FindMostFrequentChar(string s){
        int[] freq = new int[256]; // ASCII frequency array

        // Count frequency
        for(int i=0; i<s.Length; i++){
            freq[s[i]]++;
        }

        int max = 0;
        char result = s[0];

        // Find max frequency
        for(int i=0; i<256; i++){
            if(freq[i] > max){
                max = freq[i];
                result = (char)i;
            }
        }
        return result;
    }
}
