using System;

class RotateArrayAtLeft
{
    static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
        int k = 3;
        RotateArray(arr, k);
        Console.WriteLine($"Array after rotation:- {string.Join(", ", arr)}");
    }

    static void RotateArray(int[] nums, int k)
    {
        int n = nums.Length;
        k = k % n;
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, n - 1);
        Reverse(nums, 0, n - 1);
    }

    static void Reverse(int[] nums, int start, int end)
    {
        while (start < end)
        {
            int temp = nums[start];
            nums[start] = nums[end];
            nums[end] = temp;
            start++;
            end--;
        }
    }
}
