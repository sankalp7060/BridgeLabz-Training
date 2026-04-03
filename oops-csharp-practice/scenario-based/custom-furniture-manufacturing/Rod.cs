public abstract class Rod
{
    public int Length { get; set; }
    public int[] Prices { get; set; }

    protected Rod(int length, int[] prices)
    {
        Length = length;
        Prices = prices;
    }

    public abstract int CalculateMaxRevenue(ICuttingStrategy strategy);
}
