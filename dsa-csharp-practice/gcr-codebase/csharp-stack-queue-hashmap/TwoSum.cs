using System;
using System.Collections.Generic;

class TwoSum
{
    static int[] FindTwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int diff = target - nums[i];
            if (map.ContainsKey(diff))
                return new int[] { map[diff], i };

            map[nums[i]] = i;
        }
        return null;
    }

    static void Main()
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;

        int[] result = FindTwoSum(nums, target);
        Console.WriteLine($"{result[0]}, {result[1]}");
    }
}
