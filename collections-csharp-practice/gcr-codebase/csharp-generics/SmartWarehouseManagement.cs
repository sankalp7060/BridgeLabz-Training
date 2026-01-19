using System;
using System.Collections.Generic;

// Abstract base class for all warehouse items
public abstract class WarehouseItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    protected WarehouseItem(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    public abstract void DisplayInfo();
}

// Electronics item
public class Electronics : WarehouseItem
{
    public string Brand { get; set; }

    public Electronics(string name, int quantity, string brand)
        : base(name, quantity)
    {
        Brand = brand;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Electronics: {Name}, Brand: {Brand}, Quantity: {Quantity}");
    }
}

// Groceries item
public class Groceries : WarehouseItem
{
    public DateTime ExpiryDate { get; set; }

    public Groceries(string name, int quantity, DateTime expiry)
        : base(name, quantity)
    {
        ExpiryDate = expiry;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine(
            $"Groceries: {Name}, Expiry: {ExpiryDate.ToShortDateString()}, Quantity: {Quantity}"
        );
    }
}

// Furniture item
public class Furniture : WarehouseItem
{
    public string Material { get; set; }

    public Furniture(string name, int quantity, string material)
        : base(name, quantity)
    {
        Material = material;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Furniture: {Name}, Material: {Material}, Quantity: {Quantity}");
    }
}

// Generic Storage class with constraint T : WarehouseItem
public class Storage<T>
    where T : WarehouseItem
{
    private List<T> items = new List<T>();

    // Add an item
    public void AddItem(T item)
    {
        items.Add(item);
        Console.WriteLine($"{item.Name} added to storage.");
    }

    // Display all items
    public void DisplayAllItems()
    {
        Console.WriteLine("\n--- All Items in Storage ---");
        foreach (var item in items)
        {
            item.DisplayInfo();
        }
    }
}

// Main Program
class SmartWarehouseManagement
{
    static void Main()
    {
        // Storage for electronics
        Storage<Electronics> electronicsStorage = new Storage<Electronics>();
        electronicsStorage.AddItem(new Electronics("Laptop", 10, "Dell"));
        electronicsStorage.AddItem(new Electronics("Smartphone", 25, "Samsung"));
        electronicsStorage.DisplayAllItems();

        // Storage for groceries
        Storage<Groceries> groceryStorage = new Storage<Groceries>();
        groceryStorage.AddItem(new Groceries("Milk", 50, DateTime.Now.AddDays(5)));
        groceryStorage.AddItem(new Groceries("Bread", 30, DateTime.Now.AddDays(2)));
        groceryStorage.DisplayAllItems();

        // Storage for furniture
        Storage<Furniture> furnitureStorage = new Storage<Furniture>();
        furnitureStorage.AddItem(new Furniture("Chair", 15, "Wood"));
        furnitureStorage.AddItem(new Furniture("Table", 5, "Metal"));
        furnitureStorage.DisplayAllItems();
    }
}
