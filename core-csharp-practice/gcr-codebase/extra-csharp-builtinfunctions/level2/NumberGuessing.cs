using System;

class NumberGuessing{
    static void Main(){
        int low = 1, high = 100;
        string feedback = "";

        Console.WriteLine("Think of a number between 1 and 100");

        while(feedback != "correct"){
            int guess = GenerateGuess(low, high);
            Console.WriteLine("Computer guesses: " + guess);

            feedback = GetFeedback();

            // Adjust range based on feedback
            if(feedback == "low") low = guess + 1;
            else if(feedback == "high") high = guess - 1;
        }

        Console.WriteLine("Computer guessed correctly!");
    }

    // Generates random guess within range
    static int GenerateGuess(int low, int high){
        Random rand = new Random();
        return rand.Next(low, high + 1);
    }

    // Gets feedback from user
    static string GetFeedback(){
        Console.WriteLine("Enter feedback (low/high/correct):- ");
        return Console.ReadLine().ToLower();
    }
}
