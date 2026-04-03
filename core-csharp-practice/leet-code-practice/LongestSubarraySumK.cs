using System;

class LongestSubarraySumK
{
    static void Main()
    {
        int[] arr = { 1, 2, 3, 1, 1, 1, 1 };
        int k = 3;
        Console.WriteLine(LongestSubarray(arr, k));
    }

    static int LongestSubarray(int[] arr, int k)
    {
        int left = 0,
            sum = 0,
            maxLen = 0;

        for (int right = 0; right < arr.Length; right++)
        {
            sum += arr[right];

            while (sum > k)
            {
                sum -= arr[left];
                left++;
            }

            if (sum == k)
            {
                maxLen = Math.Max(maxLen, right - left + 1);
            }
        }
        return maxLen;
    }
}
