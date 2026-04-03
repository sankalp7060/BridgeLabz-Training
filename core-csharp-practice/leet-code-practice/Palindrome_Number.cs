using System;

class Palindrome_Number{
    // Main function to take inputs or to display output
    public static void Main(string[] args){
        int num = int.Parse(Console.ReadLine()); // Number to be checked for palindrome
        bool ans = isPalindrome(num); // variable to store output of isPalindrome function
        Console.Write(ans); // Output
    }

    // isPalindrome function to check number if palindrome or not
    public static bool isPalindrome(int x){
        if (x <= 9 && x >= 0) return true;
        if (x <= -1) return false;
        int revNum = 0, tempNum = x;
        while (x > 0)
        {
            revNum = (revNum * 10) + (x % 10);
            x /= 10;
        }
        if (revNum == tempNum) return true;
        return false;
    }
}
