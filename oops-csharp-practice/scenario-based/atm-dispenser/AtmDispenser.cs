// ATM Dispenser Logic
// Context: ATM dispenses minimum number of notes.
//  ●  Scenario A: Given ₹1, ₹2, ₹5, ₹10, ₹20, ₹50, ₹100, ₹200, ₹500 notes, find optimal
// combo for ₹880.
//  ●  Scenario B: Remove ₹500 temporarily and update strategy.
//  ● Scenario C: Display fallback combo if exact change isn’t possible.
using System;

class AtmDispenser
{
    public static void Dispense(int amount, int[] notes)
    {
        int remain = amount;
        bool dispensed = false;
        for (int i = 0; i < notes.Length; i++)
        {
            int count = remain / notes[i];
            if (count > 0)
            {
                remain -= notes[i] * count;
                dispensed = true;
                Console.WriteLine($"{notes[i]} x {count}");
            }
        }
        if (remain != 0)
        {
            Console.WriteLine("Exact amount cannot be dispensed.");
            Console.WriteLine($"Remaining amount: ₹{remain}");
            Console.WriteLine("Fallback: Please try a different amount.\n");
        }
        else if (dispensed)
        {
            Console.WriteLine("\nAmount dispensed successfully.\n");
        }
    }

    static void Main()
    {
        int[] scenarioA = { 500, 200, 100, 50, 20, 10, 5, 2, 1 };
        int[] scenarioB = { 200, 100, 50, 20, 10, 5, 2, 1 };
        int[] scenarioC = { 10, 5 };
        Console.WriteLine("\nWhen amount is 880 and all notes are available:- ");
        Dispense(880, scenarioA);
        Console.WriteLine("\nWhen amount is 880 and all notes are available(except 500):- ");
        Dispense(880, scenarioB);
        Console.WriteLine("\nDisplay fallback combo if exact change isn’t possible:- \n");
        Dispense(2, scenarioC);
    }
}
