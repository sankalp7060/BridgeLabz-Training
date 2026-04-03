// InvoiceTester.cs - Tests invoice parsing and generation
using System;
public class InvoiceTester
{
    private InvoiceParser parser;
    private InvoiceGenerator generator;

    // Constructor
    public InvoiceTester()
    {
        parser = new InvoiceParser();
        generator = new InvoiceGenerator();
    }

    // Test basic parsing
    public void TestBasicParsing()
    {
        Console.WriteLine("=== TESTING BASIC PARSING ===\n");

        string testInput1 = "Logo Design - 3000 INR, Web Page - 4500 INR";
        string testInput2 = "Consultation - 1500, Development - 8000, Testing - 2000";
        string testInput3 = "Single Task - 5000";
        string testInput4 = "";
        string testInput5 = "Design-$300, Coding-4000 INR, Testing - 2500 Rupees";

        string[][] testCases =
        {
            new string[] { testInput1, "Standard format" },
            new string[] { testInput2, "Without currency" },
            new string[] { testInput3, "Single task" },
            new string[] { testInput4, "Empty input" },
            new string[] { testInput5, "Mixed currencies" },
        };

        for (int i = 0; i < testCases.Length; i = i + 1)
        {
            Console.WriteLine($"Test Case {i + 1}: {testCases[i][1]}");
            Console.WriteLine($"Input: \"{testCases[i][0]}\"");

            string[] tasks = parser.ParseInvoice(testCases[i][0]);
            Console.WriteLine($"Parsed {tasks.Length} tasks:");

            for (int j = 0; j < tasks.Length; j = j + 1)
            {
                string taskName = parser.ExtractTaskName(tasks[j]);
                double amount = parser.ExtractAmount(tasks[j]);
                Console.WriteLine($"  Task {j + 1}: {taskName} = {parser.FormatCurrency(amount)}");
            }

            double total = parser.GetTotalAmount(tasks);
            Console.WriteLine($"Total: {parser.FormatCurrency(total)}\n");
        }
    }

    // Test edge cases
    public void TestEdgeCases()
    {
        Console.WriteLine("=== TESTING EDGE CASES ===\n");

        string[] edgeCases =
        {
            "Logo Design - 3000 INR, Web Page - 4500 INR, SEO - 2000", // Multiple items
            "Only Task Name", // No amount
            "-5000", // No task name
            "Task1 - ABC, Task2 - XYZ", // Non-numeric amounts
            "Task - 1000.50, Task2 - 2000.75", // Decimal amounts
            "Task - ₹2500, Task2 - $100, Task3 - 3000 INR", // Different currency symbols
        };

        for (int i = 0; i < edgeCases.Length; i = i + 1)
        {
            Console.WriteLine($"Edge Case {i + 1}:");
            Console.WriteLine($"Input: \"{edgeCases[i]}\"");

            string[] tasks = parser.ParseInvoice(edgeCases[i]);
            double total = parser.GetTotalAmount(tasks);

            Console.WriteLine(
                $"Parsed {tasks.Length} tasks, Total: {parser.FormatCurrency(total)}"
            );

            for (int j = 0; j < tasks.Length; j = j + 1)
            {
                string taskName = parser.ExtractTaskName(tasks[j]);
                double amount = parser.ExtractAmount(tasks[j]);
                Console.WriteLine($"  {taskName}: {parser.FormatCurrency(amount)}");
            }
            Console.WriteLine();
        }
    }

    // Test tax calculations
    public void TestTaxCalculations()
    {
        Console.WriteLine("=== TESTING TAX CALCULATIONS ===\n");

        string testInput = "Design - 5000, Development - 10000, Testing - 3000";
        string[] tasks = parser.ParseInvoice(testInput);
        double subtotal = parser.GetTotalAmount(tasks);

        Console.WriteLine($"Subtotal: {parser.FormatCurrency(subtotal)}\n");

        double[] taxRates = { 0, 5, 12.5, 18, 28 };

        for (int i = 0; i < taxRates.Length; i = i + 1)
        {
            double tax = parser.CalculateTax(subtotal, taxRates[i]);
            double total = parser.CalculateFinalTotal(subtotal, taxRates[i]);

            Console.WriteLine($"Tax Rate: {taxRates[i]}%");
            Console.WriteLine($"Tax Amount: {parser.FormatCurrency(tax)}");
            Console.WriteLine($"Total with Tax: {parser.FormatCurrency(total)}\n");
        }
    }

    // Run all tests
    public void RunAllTests()
    {
        TestBasicParsing();
        TestEdgeCases();
        TestTaxCalculations();
    }

    // Interactive invoice creation
    public void InteractiveInvoiceCreation()
    {
        Console.WriteLine("=== INTERACTIVE INVOICE CREATION ===\n");

        Console.WriteLine(
            "Enter tasks in the format: 'Task Name - Amount, Task Name - Amount, ...'"
        );
        Console.WriteLine("Example: Logo Design - 3000 INR, Web Development - 8000 INR");
        Console.WriteLine("\nEnter your invoice items:");

        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("No input provided!");
            return;
        }

        Console.Write("\nEnter client name (optional): ");
        string clientName = Console.ReadLine();

        Console.Write("Enter tax rate (default 18%): ");
        string taxRateInput = Console.ReadLine();

        double taxRate = 18.0;
        if (!string.IsNullOrEmpty(taxRateInput) && double.TryParse(taxRateInput, out double rate))
        {
            taxRate = rate;
        }

        Console.WriteLine("\n" + "=".PadRight(60, '='));
        Console.WriteLine("Generating Invoice...");
        Console.WriteLine("=".PadRight(60, '=') + "\n");

        // Generate invoice
        generator.GenerateInvoice(input, clientName, taxRate);

        // Ask for detailed report
        Console.Write("\nShow detailed breakdown? (Y/N): ");
        string showDetails = Console.ReadLine().ToUpper();

        if (showDetails == "Y" || showDetails == "YES")
        {
            generator.GenerateDetailedReport(input);
        }

        // Ask to save to file
        Console.Write("\nSave invoice to file? (Y/N): ");
        string saveToFile = Console.ReadLine().ToUpper();

        if (saveToFile == "Y" || saveToFile == "YES")
        {
            Console.Write("Enter filename (default: invoice.txt): ");
            string filename = Console.ReadLine();

            if (string.IsNullOrEmpty(filename))
            {
                filename = "invoice.txt";
            }

            generator.SaveInvoiceToFile(input, clientName, filename);
        }
    }
}
