// InvoiceGenerator.cs - Creates formatted invoices
using System;
public class InvoiceGenerator
{
    private InvoiceParser parser;

    // Constructor
    public InvoiceGenerator()
    {
        parser = new InvoiceParser();
    }

    // Generate invoice from input string
    public void GenerateInvoice(string invoiceInput, string clientName = "", double taxRate = 18.0)
    {
        Console.Clear();
        Console.WriteLine("=".PadRight(70, '='));
        Console.WriteLine("                     INVOICE");
        Console.WriteLine("=".PadRight(70, '='));

        // Display invoice number and date
        string invoiceNumber = parser.GenerateInvoiceNumber();
        Console.WriteLine($"Invoice No: {invoiceNumber}");
        Console.WriteLine($"Date: {DateTime.Now.ToString("dd-MMM-yyyy")}");
        Console.WriteLine($"Time: {DateTime.Now.ToString("HH:mm:ss")}");

        if (!string.IsNullOrEmpty(clientName))
        {
            Console.WriteLine($"Client: {clientName}");
        }

        Console.WriteLine("-".PadRight(70, '-'));
        Console.WriteLine("Description                     Qty    Rate       Amount");
        Console.WriteLine("-".PadRight(70, '-'));

        // Parse and display items
        string[] tasks = parser.ParseInvoice(invoiceInput);
        InvoiceItem[] items = new InvoiceItem[tasks.Length];

        double subtotal = 0;

        for (int i = 0; i < tasks.Length; i = i + 1)
        {
            string taskName = parser.ExtractTaskName(tasks[i]);
            double amount = parser.ExtractAmount(tasks[i]);

            items[i] = new InvoiceItem(taskName, amount);
            items[i].DisplayItem();

            subtotal = subtotal + amount;
        }

        Console.WriteLine("-".PadRight(70, '-'));

        // Display calculations
        Console.WriteLine($"{"Subtotal:", -40} {parser.FormatCurrency(subtotal), 25}");

        double tax = parser.CalculateTax(subtotal, taxRate);
        Console.WriteLine($"{"Tax (" + taxRate + "%):", -40} {parser.FormatCurrency(tax), 25}");

        double finalTotal = parser.CalculateFinalTotal(subtotal, taxRate);
        Console.WriteLine($"{"Total Amount:", -40} {parser.FormatCurrency(finalTotal), 25}");

        Console.WriteLine("=".PadRight(70, '='));
        Console.WriteLine("Thank you for your business!");
        Console.WriteLine("=".PadRight(70, '='));
    }

    // Generate detailed breakdown
    public void GenerateDetailedReport(string invoiceInput)
    {
        Console.WriteLine("\n=== INVOICE DETAILED BREAKDOWN ===\n");

        string[] tasks = parser.ParseInvoice(invoiceInput);

        if (tasks.Length == 0)
        {
            Console.WriteLine("No tasks found in the invoice.");
            return;
        }

        Console.WriteLine("Task List:");
        Console.WriteLine("-".PadRight(40, '-'));

        for (int i = 0; i < tasks.Length; i = i + 1)
        {
            string taskName = parser.ExtractTaskName(tasks[i]);
            double amount = parser.ExtractAmount(tasks[i]);

            Console.WriteLine($"{i + 1}. {taskName}: {parser.FormatCurrency(amount)}");
        }

        Console.WriteLine("-".PadRight(40, '-'));

        double total = parser.GetTotalAmount(tasks);
        Console.WriteLine($"Total: {parser.FormatCurrency(total)}");

        // Calculate with different tax rates
        Console.WriteLine("\nTax Calculations:");
        Console.WriteLine("-".PadRight(40, '-'));

        double[] taxRates = { 5.0, 12.0, 18.0, 28.0 };

        for (int i = 0; i < taxRates.Length; i = i + 1)
        {
            double tax = parser.CalculateTax(total, taxRates[i]);
            double totalWithTax = total + tax;

            Console.WriteLine($"{taxRates[i]}% Tax: {parser.FormatCurrency(tax)}");
            Console.WriteLine(
                $"Total with {taxRates[i]}% Tax: {parser.FormatCurrency(totalWithTax)}"
            );
            Console.WriteLine();
        }
    }

    // Save invoice to text file
    public void SaveInvoiceToFile(
        string invoiceInput,
        string clientName = "",
        string filename = "invoice.txt"
    )
    {
        try
        {
            string[] tasks = parser.ParseInvoice(invoiceInput);
            double subtotal = parser.GetTotalAmount(tasks);
            double tax = parser.CalculateTax(subtotal);
            double finalTotal = parser.CalculateFinalTotal(subtotal);

            string invoiceContent = "INVOICE\n";
            invoiceContent += "=".PadRight(50, '=') + "\n";
            invoiceContent += $"Invoice No: {parser.GenerateInvoiceNumber()}\n";
            invoiceContent += $"Date: {DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")}\n";

            if (!string.IsNullOrEmpty(clientName))
            {
                invoiceContent += $"Client: {clientName}\n";
            }

            invoiceContent += "-".PadRight(50, '-') + "\n";
            invoiceContent += "Tasks:\n";

            for (int i = 0; i < tasks.Length; i = i + 1)
            {
                string taskName = parser.ExtractTaskName(tasks[i]);
                double amount = parser.ExtractAmount(tasks[i]);
                invoiceContent += $"  {i + 1}. {taskName}: {parser.FormatCurrency(amount)}\n";
            }

            invoiceContent += "-".PadRight(50, '-') + "\n";
            invoiceContent += $"Subtotal: {parser.FormatCurrency(subtotal)}\n";
            invoiceContent += $"Tax (18%): {parser.FormatCurrency(tax)}\n";
            invoiceContent += $"Total: {parser.FormatCurrency(finalTotal)}\n";
            invoiceContent += "=".PadRight(50, '=') + "\n";
            invoiceContent += "Thank you for your business!\n";

            System.IO.File.WriteAllText(filename, invoiceContent);
            Console.WriteLine($"Invoice saved to {filename}");
        }
        catch
        {
            Console.WriteLine("Error saving invoice to file.");
        }
    }
}
