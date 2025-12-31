// InvoiceItem.cs - Represents a single invoice item
using System;
public class InvoiceItem
{
    public string taskName;
    public double amount;
    public int quantity;

    // Constructor
    public InvoiceItem(string name, double amt, int qty = 1)
    {
        taskName = name;
        amount = amt;
        quantity = qty;
    }

    // Calculate total for this item
    public double GetItemTotal()
    {
        return amount * quantity;
    }

    // Display item details
    public void DisplayItem()
    {
        Console.WriteLine(
            $"{taskName, -30} x{quantity, -5} {amount, 10:F2}  {GetItemTotal(), 10:F2}"
        );
    }
}
