using System;

class MatrixToSingleArray{
    //Main()
    static void Main(){
        // User given row value
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        // User given column value
        Console.Write("Enter number of columns: ");
        int columns = int.Parse(Console.ReadLine());

        // Create 2D array of rows * columns size
        int[,] matrix = new int[rows, columns];

        // Create 1D array to store all elements of 2D array
        int[] ans = new int[rows * columns];

        // Index variable for 1D array
        int index = 0;

        Console.WriteLine("Enter elements of the matrix:");

        // Nested loops to take input for 2D array
        for (int i = 0; i < rows; i++){
            for (int j = 0; j < columns; j++){
                matrix[i, j] = int.Parse(Console.ReadLine());

                // Copy element into 1D array
                ans[index] = matrix[i, j];
                index++;
            }
        }

        // Display 1D array elements
        Console.WriteLine("\nElements in 1D Array:");
        for (int i = 0; i < ans.Length; i++)
        {
            Console.Write(ans[i] + " ");
        }
    }
}
