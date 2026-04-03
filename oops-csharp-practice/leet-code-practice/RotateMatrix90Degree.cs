public class RotateMatrix90Degree
{
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;
        int[][] ans = new int[n][];
        for (int i = 0; i < n; i++)
        {
            ans[i] = new int[n];
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                ans[j][n - i - 1] = matrix[i][j];
            }
        }
        for (int i = 0; i < n; i++)
        {
            matrix[i] = ans[i];
        }
    }
}
