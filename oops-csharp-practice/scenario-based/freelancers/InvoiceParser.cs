// InvoiceParser.cs - Parses invoice strings and calculates totals
using System;
public class InvoiceParser
{
    // Parse the invoice string into tasks and amounts
    public string[] ParseInvoice(string invoiceInput)
    {
        // Check for empty or null input
        if (string.IsNullOrEmpty(invoiceInput))
        {
            return new string[0];
        }

        // Split by comma to get individual tasks
        string[] tasks = invoiceInput.Split(',');

        // Trim whitespace from each task
        for (int i = 0; i < tasks.Length; i = i + 1)
        {
            tasks[i] = tasks[i].Trim();
        }

        return tasks;
    }

    // Extract task name from a task string
    public string ExtractTaskName(string taskDescription)
    {
        if (string.IsNullOrEmpty(taskDescription))
        {
            return "";
        }

        // Find the dash separator
        int dashIndex = taskDescription.IndexOf('-');

        if (dashIndex == -1)
        {
            // No dash found, return the whole string as task name
            return taskDescription.Trim();
        }

        // Extract task name (everything before dash)
        string taskName = taskDescription.Substring(0, dashIndex).Trim();
        return taskName;
    }

    // Extract amount from a task string
    public double ExtractAmount(string taskDescription)
    {
        if (string.IsNullOrEmpty(taskDescription))
        {
            return 0;
        }

        // Find the dash separator
        int dashIndex = taskDescription.IndexOf('-');

        if (dashIndex == -1)
        {
            // No dash found, try to parse the whole string as amount
            return TryParseAmount(taskDescription);
        }

        // Extract amount part (everything after dash)
        string amountPart = taskDescription.Substring(dashIndex + 1).Trim();

        return TryParseAmount(amountPart);
    }

    // Helper method to parse amount from string
    private double TryParseAmount(string amountString)
    {
        // Remove currency symbols and words
        amountString = amountString.ToUpper();
        amountString = amountString.Replace("INR", "");
        amountString = amountString.Replace("₹", "");
        amountString = amountString.Replace("$", "");
        amountString = amountString.Replace("USD", "");
        amountString = amountString.Replace("RS", "");
        amountString = amountString.Replace("RUPEES", "");
        amountString = amountString.Trim();

        // Try to parse the number
        if (double.TryParse(amountString, out double amount))
        {
            return amount;
        }

        return 0; // Return 0 if parsing fails
    }

    // Calculate total amount from array of tasks
    public double GetTotalAmount(string[] tasks)
    {
        double total = 0;

        for (int i = 0; i < tasks.Length; i = i + 1)
        {
            double amount = ExtractAmount(tasks[i]);
            total = total + amount;
        }

        return total;
    }

    // Calculate subtotal (without tax)
    public double CalculateSubtotal(string[] tasks)
    {
        return GetTotalAmount(tasks);
    }

    // Calculate tax amount
    public double CalculateTax(double subtotal, double taxRate = 18.0)
    {
        return subtotal * taxRate / 100.0;
    }

    // Calculate final total with tax
    public double CalculateFinalTotal(double subtotal, double taxRate = 18.0)
    {
        double tax = CalculateTax(subtotal, taxRate);
        return subtotal + tax;
    }

    // Format currency with proper symbols
    public string FormatCurrency(double amount, string currency = "INR")
    {
        if (currency == "INR")
        {
            return "₹" + amount.ToString("F2");
        }
        else if (currency == "USD")
        {
            return "$" + amount.ToString("F2");
        }
        else
        {
            return amount.ToString("F2") + " " + currency;
        }
    }

    // Generate a unique invoice number
    public string GenerateInvoiceNumber()
    {
        DateTime now = DateTime.Now;
        return "INV-" + now.ToString("yyyyMMdd") + "-" + now.ToString("HHmmss");
    }
}
