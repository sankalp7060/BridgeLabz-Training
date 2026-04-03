public class MaximumSubarraySum
{
    public int MaxSubArray(int[] nums)
    {
        int current = nums[0],
            max = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            current = Math.Max(nums[i], current + nums[i]);
            max = Math.Max(max, current);
        }
        return max;
    }
}
