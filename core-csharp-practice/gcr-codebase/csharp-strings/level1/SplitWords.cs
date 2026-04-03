using System;
using System.Collections.Generic;

class SplitWordsDisplayLength{
    static void Main(){
        Console.WriteLine("Enter a sentence:- ");
        string text = Console.ReadLine(); //User input

        var result = SplitWords(text);

        Console.WriteLine("Word and its length:");
        foreach(var item in result){
            Console.WriteLine(item[0] + " -> " + item[1]);
        }
    }

    //Method to split words without string.Split()
    static List<string[]> SplitWords(string text){
        List<string[]> wordsList = new List<string[]>();
        string word = "";
        for(int i=0; i<text.Length; i++){
            if(text[i] != ' '){
                word += text[i];
            }
            else if(word != ""){
                wordsList.Add(new string[]{ word, GetLength(word).ToString() });
                word = "";
            }
        }
        if(word != ""){
            wordsList.Add(new string[]{ word, GetLength(word).ToString() });
        }
        return wordsList;
    }

    //Method to get length of string without using string.Length
    static int GetLength(string s){
        int count = 0;
        foreach(var c in s){
            count++;
        }
        return count;
    }
}
