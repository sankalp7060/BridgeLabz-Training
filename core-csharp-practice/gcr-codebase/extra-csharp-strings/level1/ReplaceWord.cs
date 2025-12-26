using System;

class ReplaceWord{
    // Main method
    static void Main(){
        Console.WriteLine("Enter a sentence:- ");
        string sentence = Console.ReadLine();

        Console.WriteLine("Enter word to replace:- ");
        string oldWord = Console.ReadLine();

        Console.WriteLine("Enter new word:- ");
        string newWord = Console.ReadLine();

        string result = Replace(sentence, oldWord, newWord);

        Console.WriteLine("Modified sentence: " + result);
    }

    // Method to replace a word in a sentence
    static string Replace(string sentence, string oldWord, string newWord){
        string result = "";
        string word = "";

        for(int i=0; i<sentence.Length; i++){
            if(sentence[i] != ' '){
                word += sentence[i];
            }
            else{
                if(word == oldWord) word = newWord;
                result += word + " ";
                word = "";
            }
        }

        // Handle last word
        if(word == oldWord) word = newWord;
        result += word;

        return result;
    }
}
