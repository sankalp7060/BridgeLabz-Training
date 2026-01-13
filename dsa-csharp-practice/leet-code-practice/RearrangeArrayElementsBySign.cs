public class RearrangeArrayElementsBySign
{
    public int[] RearrangeArray(int[] nums)
    {
        int[] ans = new int[nums.Length];
        int neg = 1,
            pos = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                ans[pos] = nums[i];
                pos += 2;
            }
            else if (nums[i] < 0)
            {
                ans[neg] = nums[i];
                neg += 2;
            }
        }
        return ans;
    }
}
