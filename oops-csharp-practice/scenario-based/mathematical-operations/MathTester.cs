// MathTester.cs - Tests all mathematical operations
using System;

public class MathTester
{
    private MathUtility mathUtil;

    // Constructor
    public MathTester()
    {
        mathUtil = new MathUtility();
    }

    // Test factorial method
    public void TestFactorial()
    {
        Console.WriteLine("=== TESTING FACTORIAL METHOD ===");
        Console.WriteLine("=================================");

        int[] testNumbers = { -5, 0, 1, 5, 10, 15, 20 };

        for (int i = 0; i < testNumbers.Length; i = i + 1)
        {
            int num = testNumbers[i];
            long result = mathUtil.CalculateFactorial(num);

            if (num < 0)
            {
                Console.WriteLine($"Factorial of {num}: Undefined (returns {result})");
            }
            else
            {
                Console.WriteLine($"Factorial of {num}! = {result}");
            }
        }

        Console.WriteLine();
    }

    // Test prime checking method
    public void TestPrime()
    {
        Console.WriteLine("=== TESTING PRIME CHECK METHOD ===");
        Console.WriteLine("===================================");

        int[] testNumbers = { -10, 0, 1, 2, 3, 4, 17, 20, 97, 100 };

        for (int i = 0; i < testNumbers.Length; i = i + 1)
        {
            int num = testNumbers[i];
            bool isPrime = mathUtil.IsPrime(num);

            string status = isPrime ? "Prime" : "Not Prime";
            Console.WriteLine($"Number {num}: {status}");
        }

        Console.WriteLine();
    }

    // Test GCD method
    public void TestGCD()
    {
        Console.WriteLine("=== TESTING GCD METHOD ===");
        Console.WriteLine("==========================");

        // Test cases: (num1, num2, expected)
        int[][] testCases =
        {
            new int[] { 48, 18, 6 },
            new int[] { 0, 5, 5 },
            new int[] { 7, 0, 7 },
            new int[] { -48, 18, 6 },
            new int[] { 48, -18, 6 },
            new int[] { 17, 13, 1 },
            new int[] { 100, 75, 25 },
            new int[] { 0, 0, 0 },
        };

        for (int i = 0; i < testCases.Length; i = i + 1)
        {
            int num1 = testCases[i][0];
            int num2 = testCases[i][1];
            int expected = testCases[i][2];
            int result = mathUtil.FindGCD(num1, num2);

            Console.WriteLine($"GCD({num1}, {num2}) = {result} (Expected: {expected})");
        }

        Console.WriteLine();
    }

    // Test Fibonacci method
    public void TestFibonacci()
    {
        Console.WriteLine("=== TESTING FIBONACCI METHOD ===");
        Console.WriteLine("================================");

        int[] testPositions = { -5, 0, 1, 2, 5, 10, 20, 30, 40 };

        for (int i = 0; i < testPositions.Length; i = i + 1)
        {
            int position = testPositions[i];
            long result = mathUtil.FindFibonacci(position);

            if (position < 0)
            {
                Console.WriteLine($"Fibonacci F({position}): Undefined (returns {result})");
            }
            else
            {
                Console.WriteLine($"Fibonacci F({position}) = {result}");
            }
        }

        Console.WriteLine();
    }

    // Test LCM method (bonus)
    public void TestLCM()
    {
        Console.WriteLine("=== TESTING LCM METHOD (BONUS) ===");
        Console.WriteLine("==================================");

        int[][] testCases =
        {
            new int[] { 12, 18, 36 },
            new int[] { 4, 6, 12 },
            new int[] { 0, 5, 0 },
            new int[] { 5, 0, 0 },
            new int[] { -12, 18, 36 },
            new int[] { 7, 13, 91 },
        };

        for (int i = 0; i < testCases.Length; i = i + 1)
        {
            int num1 = testCases[i][0];
            int num2 = testCases[i][1];
            int expected = testCases[i][2];
            int result = mathUtil.FindLCM(num1, num2);

            Console.WriteLine($"LCM({num1}, {num2}) = {result} (Expected: {expected})");
        }

        Console.WriteLine();
    }

    // Run all tests
    public void RunAllTests()
    {
        TestFactorial();
        TestPrime();
        TestGCD();
        TestFibonacci();
        TestLCM();
    }

    // Interactive test menu
    public void InteractiveTest()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("=== MATHEMATICAL UTILITY TESTER ===");
            Console.WriteLine("1. Test Factorial");
            Console.WriteLine("2. Test Prime Check");
            Console.WriteLine("3. Test GCD");
            Console.WriteLine("4. Test Fibonacci");
            Console.WriteLine("5. Test LCM (Bonus)");
            Console.WriteLine("6. Run All Tests");
            Console.WriteLine("7. Custom Calculations");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option (1-8): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TestFactorial();
                    break;

                case "2":
                    TestPrime();
                    break;

                case "3":
                    TestGCD();
                    break;

                case "4":
                    TestFibonacci();
                    break;

                case "5":
                    TestLCM();
                    break;

                case "6":
                    RunAllTests();
                    break;

                case "7":
                    RunCustomCalculations();
                    break;

                case "8":
                    running = false;
                    Console.WriteLine("Thank you for testing!");
                    break;

                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }

            if (running && choice != "8")
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }

    // Run custom calculations
    public void RunCustomCalculations()
    {
        Console.WriteLine("\n=== CUSTOM CALCULATIONS ===");
        Console.WriteLine("1. Calculate Factorial");
        Console.WriteLine("2. Check Prime");
        Console.WriteLine("3. Calculate GCD");
        Console.WriteLine("4. Calculate Fibonacci");
        Console.WriteLine("5. Calculate LCM");
        Console.Write("Choose operation (1-5): ");

        string opChoice = Console.ReadLine();

        switch (opChoice)
        {
            case "1": // Factorial
                Console.Write("Enter a number: ");
                if (int.TryParse(Console.ReadLine(), out int factNum))
                {
                    long result = mathUtil.CalculateFactorial(factNum);
                    if (factNum < 0)
                    {
                        Console.WriteLine($"Factorial of {factNum} is undefined.");
                    }
                    else
                    {
                        Console.WriteLine($"{factNum}! = {result}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
                break;

            case "2": // Prime check
                Console.Write("Enter a number: ");
                if (int.TryParse(Console.ReadLine(), out int primeNum))
                {
                    bool isPrime = mathUtil.IsPrime(primeNum);
                    Console.WriteLine($"Number {primeNum} is {(isPrime ? "Prime" : "Not Prime")}");
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
                break;

            case "3": // GCD
                Console.Write("Enter first number: ");
                if (int.TryParse(Console.ReadLine(), out int gcdNum1))
                {
                    Console.Write("Enter second number: ");
                    if (int.TryParse(Console.ReadLine(), out int gcdNum2))
                    {
                        int result = mathUtil.FindGCD(gcdNum1, gcdNum2);
                        Console.WriteLine($"GCD({gcdNum1}, {gcdNum2}) = {result}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid second number!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid first number!");
                }
                break;

            case "4": // Fibonacci
                Console.Write("Enter position (n): ");
                if (int.TryParse(Console.ReadLine(), out int fibPos))
                {
                    long result = mathUtil.FindFibonacci(fibPos);
                    if (fibPos < 0)
                    {
                        Console.WriteLine($"Fibonacci F({fibPos}) is undefined.");
                    }
                    else
                    {
                        Console.WriteLine($"Fibonacci F({fibPos}) = {result}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid position!");
                }
                break;

            case "5": // LCM
                Console.Write("Enter first number: ");
                if (int.TryParse(Console.ReadLine(), out int lcmNum1))
                {
                    Console.Write("Enter second number: ");
                    if (int.TryParse(Console.ReadLine(), out int lcmNum2))
                    {
                        int result = mathUtil.FindLCM(lcmNum1, lcmNum2);
                        Console.WriteLine($"LCM({lcmNum1}, {lcmNum2}) = {result}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid second number!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid first number!");
                }
                break;

            default:
                Console.WriteLine("Invalid operation choice!");
                break;
        }
    }
}
