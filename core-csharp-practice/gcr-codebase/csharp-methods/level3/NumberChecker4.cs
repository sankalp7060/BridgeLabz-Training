using System; //Using System namespace

class NumberChecker4{
    //Main() 
    static void Main(){
        Console.WriteLine("Enter a number:- "); //Taking input
        int number = int.Parse(Console.ReadLine()); //Reading number

        Console.WriteLine("Is Prime Number : " + IsPrime(number)); //Prime check
        Console.WriteLine("Is Neon Number : " + IsNeon(number)); //Neon check
        Console.WriteLine("Is Spy Number : " + IsSpy(number)); //Spy check
        Console.WriteLine("Is Automorphic Number : " + IsAutomorphic(number)); //Automorphic check
        Console.WriteLine("Is Buzz Number : " + IsBuzz(number)); //Buzz check
    }

    //Method to check Prime Number
    static bool IsPrime(int number){
        if(number <= 1) return false; //Prime condition

        for(int divisor = 2; divisor <= number / 2; divisor++) //Loop for factors
        {
            if(number % divisor == 0) //Checking divisibility
            {
                return false; //Not prime
            }
        }

        return true; //Prime number
    }

    //Method to check Neon Number
    static bool IsNeon(int number){
        int square = number * number; //Calculating square
        int sum = 0; //Variable to store sum

        while(square != 0) //Loop through digits
        {
            sum = sum + square % 10; //Adding digit
            square = square / 10; //Removing digit
        }

        return sum == number; //Checking neon condition
    }

    //Method to check Spy Number
    static bool IsSpy(int number){
        int sum = 0; //Variable for sum
        int product = 1; //Variable for product

        while(number != 0) //Loop through digits
        {
            int digit = number % 10; //Extracting digit
            sum = sum + digit; //Adding digit
            product = product * digit; //Multiplying digit
            number = number / 10; //Removing digit
        }

        return sum == product; //Checking spy condition
    }

    //Method to check Automorphic Number
    static bool IsAutomorphic(int number){
        int square = number * number; //Calculating square

        return square.ToString().EndsWith(number.ToString()); //Checking automorphic
    }

    //Method to check Buzz Number
    static bool IsBuzz(int number){
        return number % 7 == 0 || number % 10 == 7; //Buzz condition
    }
}
