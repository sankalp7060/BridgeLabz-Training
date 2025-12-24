using System; 

class MatrixOperations{
    //Main()
    static void Main(string[] args) {
        int rows = 3; // Number of rows for the matrix
        int cols = 3; // Number of columns for the matrix

        // Creating two random matrices
        int[,] matrixA = CreateRandomMatrix(rows, cols); // First matrix
        int[,] matrixB = CreateRandomMatrix(rows, cols); // Second matrix

        Console.WriteLine("Matrix A:"); // Display label
        DisplayMatrix(matrixA); // Display matrix A

        Console.WriteLine("\nMatrix B:"); // Display label
        DisplayMatrix(matrixB); // Display matrix B

        Console.WriteLine("\nAddition of A and B:"); // Label for addition
        DisplayMatrix(AddMatrices(matrixA, matrixB)); // Display addition result

        Console.WriteLine("\nSubtraction of A and B:"); // Label for subtraction
        DisplayMatrix(SubtractMatrices(matrixA, matrixB)); // Display subtraction result

        Console.WriteLine("\nMultiplication of A and B:"); // Label for multiplication
        DisplayMatrix(MultiplyMatrices(matrixA, matrixB)); // Display multiplication result

        Console.WriteLine("\nTranspose of Matrix A:"); // Label for transpose
        DisplayMatrix(TransposeMatrix(matrixA)); // Display transpose of matrix A

        Console.WriteLine("\nDeterminant of Matrix A (3x3):"); // Label for determinant
        Console.WriteLine(Determinant3x3(matrixA)); // Display determinant

        Console.WriteLine("\nInverse of Matrix A (3x3):"); // Label for inverse
        DisplayMatrix(Inverse3x3(matrixA)); // Display inverse matrix
    }

    // Method to create a random matrix
    static int[,] CreateRandomMatrix(int rows, int cols){
        Random random = new Random(); // Random object for generating values
        int[,] matrix = new int[rows, cols]; // Declare matrix

        for (int i = 0; i < rows; i++) // Loop through rows
        {
            for (int j = 0; j < cols; j++) // Loop through columns
            {
                matrix[i, j] = random.Next(1, 10); // Assign random value (1–9)
            }
        }
        return matrix; // Return generated matrix
    }

    // Method to add two matrices
    static int[,] AddMatrices(int[,] matrixA, int[,] matrixB){
        int rows = matrixA.GetLength(0); // Number of rows
        int cols = matrixA.GetLength(1); // Number of columns
        int[,] result = new int[rows, cols]; // Result matrix

        for (int i = 0; i < rows; i++) // Loop rows
        {
            for (int j = 0; j < cols; j++) // Loop columns
            {
                result[i, j] = matrixA[i, j] + matrixB[i, j]; // Add elements
            }
        }
        return result; // Return sum matrix
    }

    // Method to subtract two matrices
    static int[,] SubtractMatrices(int[,] matrixA, int[,] matrixB){
        int rows = matrixA.GetLength(0); // Number of rows
        int cols = matrixA.GetLength(1); // Number of columns
        int[,] result = new int[rows, cols]; // Result matrix

        for (int i = 0; i < rows; i++) // Loop rows
        {
            for (int j = 0; j < cols; j++) // Loop columns
            {
                result[i, j] = matrixA[i, j] - matrixB[i, j]; // Subtract elements
            }
        }
        return result; // Return difference matrix
    }

    // Method to multiply two matrices
    static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB){
        int rows = matrixA.GetLength(0); // Rows of matrix A
        int cols = matrixB.GetLength(1); // Columns of matrix B
        int common = matrixA.GetLength(1); // Common dimension
        int[,] result = new int[rows, cols]; // Result matrix

        for (int i = 0; i < rows; i++) // Loop rows
        {
            for (int j = 0; j < cols; j++) // Loop columns
            {
                for (int k = 0; k < common; k++) // Loop common dimension
                {
                    result[i, j] += matrixA[i, k] * matrixB[k, j]; // Multiply and add
                }
            }
        }
        return result; // Return multiplied matrix
    }

    // Method to find transpose of a matrix
    static int[,] TransposeMatrix(int[,] matrix){
        int rows = matrix.GetLength(0); // Original rows
        int cols = matrix.GetLength(1); // Original columns
        int[,] transpose = new int[cols, rows]; // Transposed matrix

        for (int i = 0; i < rows; i++) // Loop rows
        {
            for (int j = 0; j < cols; j++) // Loop columns
            {
                transpose[j, i] = matrix[i, j]; // Swap rows and columns
            }
        }
        return transpose; // Return transpose
    }

    // Method to find determinant of 3x3 matrix
    static int Determinant3x3(int[,] matrix){
        int determinant = 
            matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
          - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
          + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);

        return determinant; // Return determinant value
    }

    // Method to find inverse of 3x3 matrix
    static double[,] Inverse3x3(int[,] matrix){
        double determinant = Determinant3x3(matrix); // Calculate determinant
        double[,] inverse = new double[3, 3]; // Inverse matrix

        if (determinant == 0) // Check if inverse exists
        {
            Console.WriteLine("Inverse does not exist"); // Print message
            return inverse; // Return empty matrix
        }

        // Calculate adjugate matrix and divide by determinant
        inverse[0, 0] =  (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]) / determinant;
        inverse[0, 1] = -(matrix[0, 1] * matrix[2, 2] - matrix[0, 2] * matrix[2, 1]) / determinant;
        inverse[0, 2] =  (matrix[0, 1] * matrix[1, 2] - matrix[0, 2] * matrix[1, 1]) / determinant;

        inverse[1, 0] = -(matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0]) / determinant;
        inverse[1, 1] =  (matrix[0, 0] * matrix[2, 2] - matrix[0, 2] * matrix[2, 0]) / determinant;
        inverse[1, 2] = -(matrix[0, 0] * matrix[1, 2] - matrix[0, 2] * matrix[1, 0]) / determinant;

        inverse[2, 0] =  (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]) / determinant;
        inverse[2, 1] = -(matrix[0, 0] * matrix[2, 1] - matrix[0, 1] * matrix[2, 0]) / determinant;
        inverse[2, 2] =  (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) / determinant;

        return inverse; // Return inverse matrix
    }

    // Method to display a matrix
    static void DisplayMatrix(Array matrix){
        int rows = matrix.GetLength(0); // Get number of rows
        int cols = matrix.GetLength(1); // Get number of columns

        for (int i = 0; i < rows; i++) // Loop rows
        {
            for (int j = 0; j < cols; j++) // Loop columns
            {
                Console.Write(matrix.GetValue(i, j) + "\t"); // Print element
            }
            Console.WriteLine(); // Move to next line
        }
    }
}
