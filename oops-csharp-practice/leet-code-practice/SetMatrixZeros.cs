public class SetMatrixZeros
{
    public void SetZeroes(int[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        bool firstRowHasZero = false;
        bool firstColHasZero = false;

        // Check if first row has zero
        for (int j = 0; j < cols; j++)
        {
            if (matrix[0][j] == 0)
            {
                firstRowHasZero = true;
                break;
            }
        }

        // Check if first column has zero
        for (int i = 0; i < rows; i++)
        {
            if (matrix[i][0] == 0)
            {
                firstColHasZero = true;
                break;
            }
        }

        // Use first row and column as markers
        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }

        // Set zeroes based on markers
        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols; j++)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                {
                    matrix[i][j] = 0;
                }
            }
        }

        // Zero out first row if needed
        if (firstRowHasZero)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[0][j] = 0;
            }
        }

        // Zero out first column if needed
        if (firstColHasZero)
        {
            for (int i = 0; i < rows; i++)
            {
                matrix[i][0] = 0;
            }
        }
    }
}
