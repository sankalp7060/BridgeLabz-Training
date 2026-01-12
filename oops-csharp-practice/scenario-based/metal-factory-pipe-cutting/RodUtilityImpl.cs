using System;

// RodFactory using array instead of collection
public class RodUtilityImpl : ICuttingStrategy
{
    private Rod[] rods;
    private int count;

    public RodUtilityImpl(int size)
    {
        rods = new Rod[size];
        count = 0;
    }

    public void AddRod(Rod rod)
    {
        if (count < rods.Length)
        {
            rods[count++] = rod;
        }
        else
        {
            Console.WriteLine("Factory is full. Cannot add more rods.");
        }
    }

    public int MaxRevenue(int rodLength, int[] prices)
    {
        int[] dp = new int[rodLength + 1];
        dp[0] = 0;

        for (int i = 1; i <= rodLength; i++)
        {
            int maxVal = int.MinValue;
            for (int j = 1; j <= i; j++)
            {
                if (j - 1 < prices.Length)
                    maxVal = Math.Max(maxVal, prices[j - 1] + dp[i - j]);
            }
            dp[i] = maxVal;
            Console.WriteLine(string.Join(", ", dp));
        }
        return dp[rodLength];
    }

    public void ShowAllRevenue()
    {
        for (int i = 0; i < count; i++)
        {
            int revenue = rods[i].CalculateMaxRevenue(this);
            Console.WriteLine("Rod Length: " + rods[i].Length + ", Max Revenue: " + revenue);
        }
    }
}
