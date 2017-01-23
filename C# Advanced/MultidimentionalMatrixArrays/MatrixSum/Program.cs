using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] rowInMatrix = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(rowInMatrix[j]);
                }
            }

            long maxSum = long.MinValue;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    long currentSum = 0;
                    for (int rowCounter = 0; rowCounter < 3; rowCounter++)
                    {
                        for (int colCounter = 0; colCounter < 3; colCounter++)
                        {
                            currentSum += matrix[row + rowCounter, col + colCounter];
                        }

                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }
            Console.WriteLine(maxSum);

        }
    }
}
