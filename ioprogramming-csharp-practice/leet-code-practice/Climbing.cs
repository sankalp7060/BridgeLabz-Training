public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n <= 2)
            return n;

        return ClimbStairs(n - 1) + ClimbStairs(n - 2);
    }
}
