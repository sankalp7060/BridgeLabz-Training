using System;

class SingleNumber
{
    static void Main()
    {
        int[] nums = { 2, 2, 1 };
        int result = Single(nums);
        Console.WriteLine(result);
    }

    static int Single(int[] nums)
    {
        int ans = 0;
        foreach (int num in nums)
        {
            ans ^= num;
        }
        return ans;
    }
}
