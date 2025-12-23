using System;

class FizzBuzzArray{
    //Main()
    static void Main(){
        // User input
        Console.Write("Enter a positive number: ");
        int n = int.Parse(Console.ReadLine());

        // Check for valid input
        if (n <= 0){
            Console.WriteLine("Invalid input. Enter a positive number.");
            return;
        }

        // String array to store FizzBuzz results
        string[] ans = new string[n + 1];

        // Loop from 1 to the given number
        for (int i = 1; i <= n; i++){
            // Check multiples of both 3 and 5
            if (i % 3 == 0 && i % 5 == 0)
                ans[i] = "FizzBuzz";
            // Check multiples of 3
            else if (i % 3 == 0)
                ans[i] = "Fizz";
            // Check multiples of 5
            else if (i % 5 == 0)
                ans[i] = "Buzz";
            // Store number as string
            else
                ans[i] = i.ToString();
        }

        // Display results
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Position {i} = {ans[i]}");
        }
    }
}
