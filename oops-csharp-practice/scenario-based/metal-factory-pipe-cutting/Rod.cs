using System;

public abstract class Rod
{
    public int Length { get; set; }
    public int[] Prices { get; set; }

    public Rod(int length, int[] prices)
    {
        Length = length;
        Prices = prices;
    }

    public abstract int CalculateMaxRevenue(ICuttingStrategy strategy);

    public virtual void DisplayRevenueChart()
    {
        Console.WriteLine("Rod Length: " + Length);
        Console.Write("Price Chart: ");
        for (int i = 0; i < Prices.Length; i++)
            Console.Write(Prices[i] + " ");
        Console.WriteLine();
    }
}
