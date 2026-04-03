class LongestConsecutiveSubsequence
{
    public int LongestConsecutive(int[] arr)
    {
        Array.Sort(arr);
        int count = 1;
        int max = 1;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                continue;
            }
            else if (arr[i] - arr[i - 1] == 1)
            {
                count++;
            }
            else
            {
                count = 1;
            }
            if (count > max)
            {
                max = count;
            }
        }
        return max;
    }
}
