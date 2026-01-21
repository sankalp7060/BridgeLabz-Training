using System;
using System.Collections.Generic;

public class CheckoutService : ICheckoutService
{
    private Queue<Customer> checkoutQueue = new Queue<Customer>();

    // HashMap Inventory
    private Dictionary<string, Item> inventory = new Dictionary<string, Item>();

    public CheckoutService()
    {
        // Preloaded Store Data
        inventory.Add("Milk", new Item("Milk", 50, 10));
        inventory.Add("Bread", new Item("Bread", 40, 8));
        inventory.Add("Eggs", new Item("Eggs", 6, 50));
        inventory.Add("Rice", new Item("Rice", 60, 20));
    }

    // Enqueue customer
    public void AddCustomer(Customer customer)
    {
        checkoutQueue.Enqueue(customer);
        Console.WriteLine($"Customer {customer.Name} added to queue.");
    }

    // Dequeue and bill
    public void ProcessNextCustomer()
    {
        if (checkoutQueue.Count == 0)
        {
            Console.WriteLine("No customers in queue.");
            return;
        }

        Customer current = checkoutQueue.Dequeue();

        Console.WriteLine($"\nProcessing Bill For: {current.Name}");

        decimal total = 0;

        foreach (var itemName in current.CartItems)
        {
            if (!inventory.ContainsKey(itemName))
            {
                Console.WriteLine($"{itemName} not found!");
                continue;
            }

            Item item = inventory[itemName];

            if (item.Stock <= 0)
            {
                Console.WriteLine($"{itemName} OUT OF STOCK!");
                continue;
            }

            total += item.Price;
            item.Stock--;

            Console.WriteLine($"{item.Name} - ₹{item.Price}");
        }

        Console.WriteLine($"TOTAL BILL: ₹{total}");
    }

    // Display Queue
    public void DisplayQueue()
    {
        Console.WriteLine("\nCurrent Checkout Queue:");

        foreach (var customer in checkoutQueue)
        {
            Console.WriteLine(customer.Name);
        }
    }
}
