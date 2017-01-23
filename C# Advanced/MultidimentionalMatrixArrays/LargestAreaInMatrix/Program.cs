using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestAreaInMatrix
{

    class Program
    {
        static int sequenceCount = 1;
        static int largestSequence = 0;
        static bool[,] marked;
        static int[,] matrix;
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            matrix = new int[rows, cols];
            marked = new bool[rows, cols];
            FillTheMatrix(matrix);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    sequenceCount = 1;
                    int currentSequence = DepthfirstSearch(matrix[row, col], row, col);

                    if (currentSequence > largestSequence)
                    {
                        largestSequence = currentSequence;
                    }
                }

            }
            Console.WriteLine(largestSequence);
        }

        static void FillTheMatrix(int[,] table)
        {
            for (int row = 0; row < table.GetLength(0); row++)
            {
                int[] numbersInRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    table[row, col] = numbersInRow[col];
                }
            }
        }

        static int DepthfirstSearch(int cellElement, int currRow, int currCol)
        {
            if (marked[currRow, currCol])
            {
                return 0;
            }

            marked[currRow, currCol] = true;

            if (currRow != 0 && matrix[currRow - 1, currCol] == cellElement && (!marked[currRow - 1, currCol]))
            {
                sequenceCount++;
                DepthfirstSearch(matrix[currRow - 1, currCol], currRow - 1, currCol);
            }
            if (currRow + 1 != matrix.GetLength(0) && matrix[currRow + 1, currCol] == cellElement && (!marked[currRow + 1, currCol]))
            {
                sequenceCount++;
                DepthfirstSearch(matrix[currRow + 1, currCol], currRow + 1, currCol);
            }
            if (currCol != 0 && matrix[currRow, currCol - 1] == cellElement && (!marked[currRow, currCol - 1]))
            {
                sequenceCount++;
                DepthfirstSearch(matrix[currRow, currCol - 1], currRow, currCol - 1);
            }
            if (currCol + 1 != matrix.GetLength(1) && matrix[currRow, currCol + 1] == cellElement && (!marked[currRow, currCol + 1]))
            {
                sequenceCount++;
                DepthfirstSearch(matrix[currRow, currCol + 1], currRow, currCol + 1);
            }
            return sequenceCount;

        }
    }
}
