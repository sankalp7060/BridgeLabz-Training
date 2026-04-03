using System;

public class RodUtilityImpl : ICuttingStrategy
{
    private Rod[] rods;
    private int count;
    private int allowedWaste;

    public RodUtilityImpl(int size)
    {
        rods = new Rod[size];
        count = 0;
        allowedWaste = int.MaxValue;
    }

    public void SetWasteConstraint(int waste)
    {
        allowedWaste = waste;
    }

    public void AddRod(Rod rod)
    {
        if (count < rods.Length)
            rods[count++] = rod;
    }

    public int MaxRevenue(int rodLength, int[] prices)
    {
        int[] dp = new int[rodLength + 1];
        dp[0] = 0;

        for (int i = 1; i <= rodLength; i++)
        {
            int maxVal = 0;

            for (int j = 1; j <= i; j++)
            {
                if (j - 1 < prices.Length)
                {
                    int waste = rodLength - i;
                    if (waste <= allowedWaste)
                    {
                        maxVal = Math.Max(maxVal, prices[j - 1] + dp[i - j]);
                    }
                }
            }
            dp[i] = maxVal;
        }
        return dp[rodLength];
    }

    public void SuggestBestCut(int rodLength, int[] prices)
    {
        int bestRevenue = 0;
        int minWaste = rodLength;

        for (int i = 1; i <= rodLength; i++)
        {
            if (i - 1 < prices.Length)
            {
                int revenue = prices[i - 1];
                int waste = rodLength - i;

                if (revenue > bestRevenue || (revenue == bestRevenue && waste < minWaste))
                {
                    bestRevenue = revenue;
                    minWaste = waste;
                }
            }
        }

        Console.WriteLine("Suggested Cut Length: " + (rodLength - minWaste));
        Console.WriteLine("Revenue: " + bestRevenue);
        Console.WriteLine("Waste: " + minWaste + " ft");
    }

    public void ShowAllRevenue()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(
                "Rod Length: " + rods[i].Length + ", Revenue: " + rods[i].CalculateMaxRevenue(this)
            );
        }
    }
}
