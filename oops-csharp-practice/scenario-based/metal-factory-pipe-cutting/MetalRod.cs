using System;

public class MetalRod : Rod
{
    public MetalRod(int length, int[] prices)
        : base(length, prices) { }

    public override int CalculateMaxRevenue(ICuttingStrategy strategy)
    {
        return strategy.MaxRevenue(Length, Prices);
    }

    public void DisplayRevenueChart(ICuttingStrategy strategy)
    {
        Console.WriteLine("Rod Length: " + Length);
        Console.Write("Price Chart: ");
        for (int i = 0; i < Prices.Length; i++)
            Console.Write(Prices[i] + " ");
        Console.WriteLine();

        Console.WriteLine("Optimized Revenue: " + CalculateMaxRevenue(strategy));
    }
}
