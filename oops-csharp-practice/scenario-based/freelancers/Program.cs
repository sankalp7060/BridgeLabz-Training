// Program.cs - Main application for Invoice Generator
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=".PadRight(60, '='));
        Console.WriteLine("     FREELANCER INVOICE GENERATOR");
        Console.WriteLine("=".PadRight(60, '='));

        InvoiceTester tester = new InvoiceTester();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== MAIN MENU ===");
            Console.WriteLine("1. Create New Invoice");
            Console.WriteLine("2. Test Invoice Parser");
            Console.WriteLine("3. Test Edge Cases");
            Console.WriteLine("4. Test Tax Calculations");
            Console.WriteLine("5. Run All Tests");
            Console.WriteLine("6. View Sample Invoices");
            Console.WriteLine("7. Exit");
            Console.Write("\nChoose an option (1-7): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    tester.InteractiveInvoiceCreation();
                    break;

                case "2":
                    Console.Clear();
                    tester.TestBasicParsing();
                    break;

                case "3":
                    Console.Clear();
                    tester.TestEdgeCases();
                    break;

                case "4":
                    Console.Clear();
                    tester.TestTaxCalculations();
                    break;

                case "5":
                    Console.Clear();
                    tester.RunAllTests();
                    break;

                case "6":
                    ShowSampleInvoices();
                    break;

                case "7":
                    running = false;
                    Console.WriteLine("\nThank you for using Invoice Generator!");
                    break;

                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }

            if (running && choice != "1")
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    // Show sample invoices
    static void ShowSampleInvoices()
    {
        Console.Clear();
        InvoiceGenerator generator = new InvoiceGenerator();

        Console.WriteLine("=== SAMPLE INVOICES ===\n");

        // Sample 1
        Console.WriteLine("Sample 1: Web Development Project");
        Console.WriteLine("-".PadRight(50, '-'));
        generator.GenerateInvoice(
            "Website Design - 15000 INR, Frontend Development - 25000 INR, "
                + "Backend Development - 35000 INR, Testing - 10000 INR",
            "ABC Corporation"
        );

        Console.WriteLine("\n" + "=".PadRight(60, '=') + "\n");

        // Sample 2
        Console.WriteLine("Sample 2: Graphic Design Project");
        Console.WriteLine("-".PadRight(50, '-'));
        generator.GenerateInvoice(
            "Logo Design - 5000 INR, Business Card - 2000 INR, "
                + "Brochure Design - 8000 INR, Social Media Posts - 4000 INR",
            "XYZ Startup",
            12.5
        );

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
