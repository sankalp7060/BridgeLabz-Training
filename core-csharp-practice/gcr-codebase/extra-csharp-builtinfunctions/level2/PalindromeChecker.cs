using System;

class PalindromeChecker{
    static void Main(){
        string input = GetInput();

        if(IsPalindrome(input))
            Console.WriteLine("Palindrome");
        else
            Console.WriteLine("Not Palindrome");
    }

    // Takes input from user
    static string GetInput(){
        Console.WriteLine("Enter a string:- ");
        return Console.ReadLine();
    }

    // Checks palindrome condition
    static bool IsPalindrome(string s){
        int i = 0, j = s.Length - 1;
        while(i < j){
            if(s[i] != s[j]) return false;
            i++;
            j--;
        }
        return true;
    }
}
