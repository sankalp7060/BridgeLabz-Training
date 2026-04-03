using System; 

class NumberChecker5{
    //Main() method
    static void Main(){
        Console.WriteLine("Enter a number:- "); //Taking input
        int number = int.Parse(Console.ReadLine()); //Reading number

        int[] factors = FindFactors(number); //Finding factors

        Console.WriteLine("Is Perfect Number : " + IsPerfect(number, factors)); //Perfect check
        Console.WriteLine("Is Abundant Number : " + IsAbundant(number, factors)); //Abundant check
        Console.WriteLine("Is Deficient Number : " + IsDeficient(number, factors)); //Deficient check
        Console.WriteLine("Is Strong Number : " + IsStrong(number)); //Strong check
    }

    //Method to find factors
    static int[] FindFactors(int number)
    {
        int count = 0; //Variable to count factors

        for(int i = 1; i <= number; i++) //Loop for counting
        {
            if(number % i == 0) count++; //Counting factors
        }

        int[] factors = new int[count]; //Creating array
        int index = 0; //Index variable

        for(int i = 1; i <= number; i++) //Loop to store factors
        {
            if(number % i == 0) //Checking factor
            {
                factors[index] = i; //Storing factor
                index++; //Incrementing index
            }
        }

        return factors; //Returning factors array
    }

    //Method to check Perfect Number
    static bool IsPerfect(int number, int[] factors)
    {
        int sum = 0; //Variable for sum

        for(int i = 0; i < factors.Length - 1; i++) //Ignoring number itself
        {
            sum = sum + factors[i]; //Adding factor
        }

        return sum == number; //Perfect condition
    }

    //Method to check Abundant Number
    static bool IsAbundant(int number, int[] factors)
    {
        int sum = 0; //Variable for sum

        for(int i = 0; i < factors.Length - 1; i++) //Ignoring number itself
        {
            sum = sum + factors[i]; //Adding factor
        }

        return sum > number; //Abundant condition
    }

    //Method to check Deficient Number
    static bool IsDeficient(int number, int[] factors)
    {
        int sum = 0; //Variable for sum

        for(int i = 0; i < factors.Length - 1; i++) //Ignoring number itself
        {
            sum = sum + factors[i]; //Adding factor
        }

        return sum < number; //Deficient condition
    }

    //Method to check Strong Number
    static bool IsStrong(int number)
    {
        int original = number; //Storing original number
        int sum = 0; //Variable for sum

        while(number != 0) //Loop through digits
        {
            int digit = number % 10; //Extracting digit
            sum = sum + Factorial(digit); //Adding factorial
            number = number / 10; //Removing digit
        }

        return sum == original; //Strong condition
    }

    //Method to find factorial
    static int Factorial(int number)
    {
        int fact = 1; //Variable for factorial

        for(int i = 1; i <= number; i++) //Loop for factorial
        {
            fact = fact * i; //Multiplying
        }

        return fact; //Returning factorial
    }
}
