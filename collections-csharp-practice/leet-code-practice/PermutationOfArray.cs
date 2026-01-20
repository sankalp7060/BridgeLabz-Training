public class PermutationOfArray
{
    public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> l = new List<IList<int>>();
        Generate(l, nums, 0);
        return l;
    }

    public void Generate(IList<IList<int>> output, int[] nums, int index)
    {
        if (index == nums.Length)
        {
            output.Add(new List<int>(nums));
            return;
        }
        for (int i = index; i < nums.Length; i++)
        {
            Swap(nums, i, index);
            Generate(output, nums, index + 1);
            Swap(nums, i, index);
        }
    }

    public void Swap(int[] nums, int i, int j)
    {
        int t = nums[i];
        nums[i] = nums[j];
        nums[j] = t;
    }
}
