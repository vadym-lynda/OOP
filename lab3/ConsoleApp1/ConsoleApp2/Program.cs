using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of rows of the matrix: ");
        int rows;
        while (!int.TryParse(Console.ReadLine(), out rows) || rows <= 0)
        {
            Console.WriteLine("Please enter a valid positive integer for the number of rows!");
        }

        Console.Write("Enter the number of matrix columns: ");
        int cols;
        while (!int.TryParse(Console.ReadLine(), out cols) || cols <= 0)
        {
            Console.WriteLine("Please enter a valid positive integer for the number of columns!");
        }

        Random rnd = new Random();
        double[,] matrix = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = Math.Round(rnd.NextDouble() * (126.3 + 12.3) - 12.3, 1);
            }
        }

        Console.WriteLine("\nInitial matrix:");
        PrintMatrix(matrix);

        double[] columnSums = new double[cols];
        for (int j = 0; j < cols; j++)
        {
            for (int i = 0; i < rows; i++)
            {
                columnSums[j] += matrix[i, j];
            }
        }

        double maxColumnSum = double.MinValue;
        int maxColumnIndex = -1;
        for (int j = 0; j < cols; j++)
        {
            if (columnSums[j] > maxColumnSum)
            {
                maxColumnSum = columnSums[j];
                maxColumnIndex = j;
            }
        }

        Console.WriteLine("\nThe sums of the elements of each column:");
        for (int j = 0; j < cols; j++)
        {
            Console.WriteLine($"Column {j + 1}: {columnSums[j]}");
        }
        Console.WriteLine($"\nThe largest amount: {maxColumnSum} in the column {maxColumnIndex + 1}");

        for (int i = 0; i < rows / 2; i++)
        {
            int oppositeRow = rows - 1 - i;
            for (int j = 0; j < cols; j++)
            {
                double temp = matrix[i, j];
                matrix[i, j] = matrix[oppositeRow, j];
                matrix[oppositeRow, j] = temp;
            }
        }

        Console.WriteLine("\nThe matrix after permuting the rows:");
        PrintMatrix(matrix);
    }

    static void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],6} ");
            }
            Console.WriteLine();
        }
    }
}
