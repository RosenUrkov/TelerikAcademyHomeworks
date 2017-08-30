using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guards
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var matrix = new int[rowsAndCols[0] + 1, rowsAndCols[1] + 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, 0] = -1;
            }
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[0, i] = -1;
            }

            matrix[0, 1] = 0;

            var guards = int.Parse(Console.ReadLine());
            for (int i = 0; i < guards; i++)
            {
                var parameters = Console.ReadLine().Split(' ');

                var row = int.Parse(parameters[0]) + 1;
                var col = int.Parse(parameters[1]) + 1;

                matrix[row, col] = -1;

                var guardedRow = row;
                var guardedCol = col;
                switch (parameters[2])
                {
                    case "R": guardedCol++; break;
                    case "D": guardedRow++; break;
                    case "L": guardedCol--; break;
                    case "U": guardedRow--; break;
                }

                if (guardedRow < 0 ||
                    guardedRow >= matrix.GetLength(0) ||
                    guardedCol < 0 ||
                    guardedCol >= matrix.GetLength(1))
                {
                    continue;
                }

                matrix[guardedRow, guardedCol] = matrix[guardedRow, guardedCol] == -1 ? -1 : 2;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == -1 || (matrix[row - 1, col] == -1 && matrix[row, col - 1] == -1))
                    {
                        matrix[row, col] = -1;
                        continue;
                    }

                    if (matrix[row - 1, col] == -1)
                    {
                        matrix[row, col] += matrix[row, col - 1] + 1;
                    }
                    else if (matrix[row, col - 1] == -1)
                    {
                        matrix[row, col] += matrix[row - 1, col] + 1;
                    }
                    else
                    {
                        matrix[row, col] += Math.Min(matrix[row - 1, col], matrix[row, col - 1]) + 1;
                    }
                }
            }

            var result = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            if (result == -1)
            {
                Console.WriteLine("Meow");
            }
            else
            {
                Console.WriteLine(result);
            }
        }
    }
}
