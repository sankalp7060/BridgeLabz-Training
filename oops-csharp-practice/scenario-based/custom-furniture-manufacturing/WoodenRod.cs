using System;

public class WoodenRod : Rod
{
    public WoodenRod(int length, int[] prices)
        : base(length, prices) { }

    public override int CalculateMaxRevenue(ICuttingStrategy strategy)
    {
        return strategy.MaxRevenue(Length, Prices);
    }

    public void DisplayResult(ICuttingStrategy strategy)
    {
        Console.WriteLine("Wooden Rod Length: " + Length + " ft");
        Console.Write("Price Chart: ");
        for (int i = 0; i < Prices.Length; i++)
            Console.Write(Prices[i] + " ");
        Console.WriteLine();

        Console.WriteLine("Max Revenue: " + CalculateMaxRevenue(strategy));
    }
}
