using System;
using System.Collections.Generic;

class ShoppingCart
{
    static void Main()
    {
        Dictionary<string, double> cart = new Dictionary<string, double>();
        List<string> order = new List<string>();

        AddItem("Laptop", 50000);
        AddItem("Mouse", 800);
        AddItem("Keyboard", 1500);

        void AddItem(string name, double price)
        {
            cart[name] = price;
            order.Add(name);
        }

        Console.WriteLine("Insertion Order:");
        foreach (var p in order)
            Console.WriteLine(p + " -> " + cart[p]);

        SortedDictionary<double, string> sorted = new SortedDictionary<double, string>();

        foreach (var item in cart)
            sorted[item.Value] = item.Key;

        Console.WriteLine("\nSorted By Price:");
        foreach (var s in sorted)
            Console.WriteLine(s.Value + " -> " + s.Key);
    }
}
