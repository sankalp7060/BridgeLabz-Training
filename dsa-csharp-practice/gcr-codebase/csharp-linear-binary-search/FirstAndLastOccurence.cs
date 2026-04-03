using System;

class FirstAndLastOccurence
{
    static void Main()
    {
        int[] arr = { 1, 2, 2, 2, 3, 4, 5, 5, 6 };

        int target = 2;

        int first = FirstOccurrence(arr, target);
        int last = LastOccurrence(arr, target);

        if (first != -1 && last != -1)
        {
            Console.WriteLine($"First occurrence of {target} is at index {first}");
            Console.WriteLine($"Last occurrence of {target} is at index {last}");
        }
        else
        {
            Console.WriteLine($"Target {target} not found in the array.");
        }
    }

    static int FirstOccurrence(int[] arr, int target)
    {
        int low = 0,
            high = arr.Length - 1,
            res = -1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (arr[mid] == target)
            {
                res = mid;
                high = mid - 1;
            }
            else if (arr[mid] < target)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return res;
    }

    static int LastOccurrence(int[] arr, int target)
    {
        int low = 0,
            high = arr.Length - 1,
            res = -1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (arr[mid] == target)
            {
                res = mid;
                low = mid + 1;
            }
            else if (arr[mid] < target)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return res;
    }
}
