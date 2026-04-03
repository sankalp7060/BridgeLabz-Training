using System;

// Program.cs - Main application to run mathematical utility
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("======================================");
        Console.WriteLine("   MATHEMATICAL UTILITY APPLICATION");
        Console.WriteLine("======================================");

        MathTester tester = new MathTester();

        // Check if user wants to run predefined tests or interactive mode
        Console.WriteLine("\nChoose testing mode:");
        Console.WriteLine("1. Run Predefined Tests (All edge cases)");
        Console.WriteLine("2. Interactive Testing Mode");
        Console.WriteLine("3. Quick Demo (All tests once)");
        Console.Write("Enter choice (1-3): ");

        string modeChoice = Console.ReadLine();

        switch (modeChoice)
        {
            case "1":
                RunPredefinedTests(tester);
                break;

            case "2":
                tester.InteractiveTest();
                break;

            case "3":
                tester.RunAllTests();
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
                break;

            default:
                Console.WriteLine("Invalid choice! Running predefined tests.");
                RunPredefinedTests(tester);
                break;
        }
    }

    // Run predefined comprehensive tests
    static void RunPredefinedTests(MathTester tester)
    {
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("COMPREHENSIVE MATHEMATICAL TESTS WITH EDGE CASES");
        Console.WriteLine(new string('=', 50) + "\n");

        // Run all individual tests with detailed output
        tester.TestFactorial();
        tester.TestPrime();
        tester.TestGCD();
        tester.TestFibonacci();
        tester.TestLCM();

        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("ALL TESTS COMPLETED SUCCESSFULLY!");
        Console.WriteLine(new string('=', 50));

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
