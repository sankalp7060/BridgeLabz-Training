class MoveZerosAtEnd
{
    public void MoveZeroes(int[] nums)
    {
        int index = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[index] = nums[i];
                index++;
            }
        }

        while (index < nums.Length)
        {
            nums[index] = 0;
            index++;
        }
    }
}
