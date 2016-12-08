using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BitShiftMatrix
{

    class Program
    {
        static BigInteger[,] matrix;
        static bool[,] visited;
        static int coeff;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            coeff = Math.Max(rows, cols);

            visited = new bool[rows, cols];
            matrix = new BigInteger[rows, cols];
            FillUpMatrix(matrix);

            int numberOfMoves = int.Parse(Console.ReadLine());
            int[] moves = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            BigInteger sum = SumOfMoves(moves);

            Console.WriteLine(sum);


        }

        private static BigInteger SumOfMoves(int[] moves)
        {
            BigInteger result = 0;
            int row = matrix.GetLength(0) - 1;
            int col = 0;
            for (int i = 0; i < moves.Length; i++)
            {
                int rows = moves[i] / coeff;
                int cols = moves[i] % coeff;

                while (col != cols)
                {
                    if (visited[row, col] != true)
                    {
                        visited[row, col] = true;
                        result += matrix[row, col];
                    }
                    col += Math.Sign(cols - col);
                }

                while (row != rows)
                {
                    if (visited[row, col] != true)
                    {
                        visited[row, col] = true;
                        result += matrix[row, col];
                    }
                    row += Math.Sign(rows - row);
                }
                if (visited[row, col] != true)
                {
                    visited[row, col] = true;
                    result += matrix[row, col];
                }

            }

            return result;
        }


        static void FillUpMatrix(BigInteger[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                BigInteger number = 1 * (BigInteger)Math.Pow(2, i);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[matrix.GetLength(0) - 1 - i, j] = number;
                    number *= 2;
                }

            }
        }

        static void PrintMatrix(BigInteger[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,5}", matrix[i, j]);
                }
                Console.WriteLine();

            }
        }
    }
}
