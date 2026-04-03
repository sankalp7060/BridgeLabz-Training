public class SortColors
{
    public void SortColors(int[] nums)
    {
        int l = 0,
            m = 0,
            r = nums.Length - 1;
        while (m <= r)
        {
            if (nums[m] == 0)
            {
                Swap(nums, l, m);
                l++;
                m++;
            }
            else if (nums[m] == 1)
                m++;
            else
            {
                Swap(nums, m, r);
                r--;
            }
        }
    }

    public void Swap(int[] nums, int l, int r)
    {
        int t = nums[l];
        nums[l] = nums[r];
        nums[r] = t;
    }
}
