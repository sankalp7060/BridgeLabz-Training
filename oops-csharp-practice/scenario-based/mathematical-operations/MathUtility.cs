using System;

// MathUtility.cs - Contains all mathematical operations
public class MathUtility
{
    // Method to calculate factorial of a number
    public long CalculateFactorial(int number)
    {
        // Handle negative numbers
        if (number < 0)
        {
            return -1; // Factorial for negative numbers is undefined
        }

        // Handle 0! = 1
        if (number == 0)
        {
            return 1;
        }

        // Calculate factorial
        long result = 1;
        for (int i = 1; i <= number; i = i + 1)
        {
            result = result * i;
        }

        return result;
    }

    // Method to check if a number is prime
    public bool IsPrime(int number)
    {
        // Handle special cases
        if (number <= 1)
        {
            return false; // Numbers <= 1 are not prime
        }
        if (number == 2)
        {
            return true; // 2 is the only even prime
        }
        if (number % 2 == 0)
        {
            return false; // Even numbers > 2 are not prime
        }

        // Check divisibility up to square root
        for (int i = 3; i * i <= number; i = i + 2)
        {
            if (number % i == 0)
            {
                return false; // Found a divisor
            }
        }

        return true; // No divisors found
    }

    // Method to find GCD using Euclidean algorithm
    public int FindGCD(int number1, int number2)
    {
        // Handle negative numbers by taking absolute values
        int a = number1 < 0 ? -number1 : number1;
        int b = number2 < 0 ? -number2 : number2;

        // Handle zeros
        if (a == 0)
        {
            return b;
        }
        if (b == 0)
        {
            return a;
        }

        // Euclidean algorithm
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    // Method to find nth Fibonacci number
    public long FindFibonacci(int n)
    {
        // Handle negative positions
        if (n < 0)
        {
            return -1; // Fibonacci for negative positions is undefined
        }

        // Handle base cases
        if (n == 0)
        {
            return 0;
        }
        if (n == 1)
        {
            return 1;
        }

        // Calculate Fibonacci using iteration
        long a = 0; // F(0)
        long b = 1; // F(1)
        long result = 0;

        for (int i = 2; i <= n; i = i + 1)
        {
            result = a + b;
            a = b;
            b = result;
        }

        return result;
    }

    // Bonus: Method to find LCM (Least Common Multiple)
    public int FindLCM(int number1, int number2)
    {
        if (number1 == 0 || number2 == 0)
        {
            return 0; // LCM of 0 and any number is 0
        }

        int gcd = FindGCD(number1, number2);
        int product = number1 < 0 ? -number1 : number1;
        product = product * (number2 < 0 ? -number2 : number2);

        return product / gcd;
    }
}
