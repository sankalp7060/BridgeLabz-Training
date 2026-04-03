using System;

public class RodMenu
{
    public static void ShowMenu()
    {
        Console.WriteLine("=== Custom Furniture Manufacturing ===");
        Console.WriteLine("1. Scenario A: Max revenue (12ft rod)");
        Console.WriteLine("2. Scenario B: Max revenue with waste constraint");
        Console.WriteLine("3. Scenario C: Best cut (revenue + minimal waste)");
        Console.WriteLine("4. Exit");
    }
}
