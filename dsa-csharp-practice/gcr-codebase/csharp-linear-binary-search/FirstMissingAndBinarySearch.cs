using System;

class FirstMissingAndBinarySearch
{
    static void Main()
    {
        // Sample input array
        int[] arr = { 3, 4, -1, 1 };
        int target = 4;

        // Part 1: Find the first missing positive integer using Linear Search
        int missing = FirstMissingPositive(arr);
        Console.WriteLine($"First missing positive integer: {missing}");

        // Part 2: Find the index of target using Binary Search
        Array.Sort(arr); // Binary search requires a sorted array
        int index = BinarySearch(arr, target);
        if (index != -1)
            Console.WriteLine($"Target {target} found at index: {index}");
        else
            Console.WriteLine($"Target {target} not found in the array.");
    }

    // Linear search approach for first missing positive
    static int FirstMissingPositive(int[] nums)
    {
        int n = nums.Length;

        // Step 1: Replace negatives, zeros, and numbers > n with n+1
        for (int i = 0; i < n; i++)
        {
            if (nums[i] <= 0 || nums[i] > n)
                nums[i] = n + 1;
        }

        // Step 2: Mark numbers present by using index as hash
        for (int i = 0; i < n; i++)
        {
            int num = Math.Abs(nums[i]);
            if (num <= n)
            {
                nums[num - 1] = -Math.Abs(nums[num - 1]);
            }
        }

        // Step 3: First positive index + 1 is the missing number
        for (int i = 0; i < n; i++)
        {
            if (nums[i] > 0)
                return i + 1;
        }

        return n + 1;
    }

    // Binary search for the target index
    static int BinarySearch(int[] arr, int target)
    {
        int low = 0,
            high = arr.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (arr[mid] == target)
                return mid;
            else if (arr[mid] < target)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return -1;
    }
}
