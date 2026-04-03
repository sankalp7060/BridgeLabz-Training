using System;
using System.Collections.Generic;

class Valid_Parenthesis{
    // Main
    public static void Main(string[] args){
        // Input
        string pareString = Console.ReadLine(); // String which contains parenthesis to be checked
        bool ans = isValid(pareString); // variable to store the output of the isValid()
        Console.Write(ans); // Output
    }

    // function to check whether the given string is valid parenthesis or not
    public static bool isValid(string pareString){
        Stack<char> stack = new Stack<char>();
        foreach (char parenthesis in pareString.ToCharArray()){
            if (parenthesis == '(' || parenthesis == '{' || parenthesis == '['){
                stack.Push(parenthesis);
            }
            else{
                if (stack.Count > 0 && ((parenthesis == ')' && stack.Peek() == '(') ||
                                        (parenthesis == '}' && stack.Peek() == '{') ||
                                        (parenthesis == ']' && stack.Peek() == '['))){
                    stack.Pop();
                }
                else return false;
            }
        }
        return stack.Count == 0;
    }
}
