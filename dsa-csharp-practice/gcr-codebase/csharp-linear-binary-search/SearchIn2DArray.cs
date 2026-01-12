using System;

class SearchIn2DArray
{
    static void Main()
    {
        int[,] matrix =
        {
            { 1, 3, 5, 7 },
            { 10, 11, 16, 20 },
            { 23, 30, 34, 50 },
        };
        int target = 16;
        bool found = SearchMatrix(matrix, target);
        if (found)
            Console.WriteLine($"Target {target} found in the matrix.");
        else
            Console.WriteLine($"Target {target} not found in the matrix.");
    }

    static bool SearchMatrix(int[,] matrix, int target)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int low = 0,
            high = rows * cols - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            int value = matrix[mid / cols, mid % cols];

            if (value == target)
                return true;
            if (value < target)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return false;
    }
}
