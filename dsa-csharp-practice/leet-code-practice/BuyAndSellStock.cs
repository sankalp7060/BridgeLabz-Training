public class BuyAndSellStock
{
    public int MaxProfit(int[] prices)
    {
        int buy = int.MaxValue,
            s = 0;
        foreach (int i in prices)
        {
            buy = Math.Min(buy, i);
            s = Math.Max(s, i - buy);
        }
        return s;
    }
}
