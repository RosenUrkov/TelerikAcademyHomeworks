using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeCoin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var rowsAndCols = Console.ReadLine().Split(' ');

            var rows = int.Parse(rowsAndCols[0]);
            var cols = int.Parse(rowsAndCols[1]);

            var matrix = new int[rows + 1, cols + 1];

            var coinsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < coinsCount; i++)
            {
                var coords = Console.ReadLine().Split(' ');
                matrix[int.Parse(coords[0]) + 1, int.Parse(coords[1]) + 1]++;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] += Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                }
            }

            Console.WriteLine(matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1]);
        }
    }
}
