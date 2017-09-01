using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals
{
    class Portal
    {
        public Portal(int x, int y, int value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Value { get; set; }
    }

    class Program
    {
        static int[,] matrix;
        static bool[,] visited;

        static long bigResult = int.MinValue;

        static void Main(string[] args)
        {
            var start = Console.ReadLine().Split(' ');
            var x = int.Parse(start[0]);
            var y = int.Parse(start[1]);

            var rowsCols = Console.ReadLine().Split(' ');
            var rows = int.Parse(rowsCols[0]);
            var cols = int.Parse(rowsCols[1]);

            matrix = new int[rows, cols];
            visited = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var rowVal = Console.ReadLine().Split(' ');
                for (int col = 0; col < cols; col++)
                {
                    if (rowVal[col] == "#")
                    {
                        visited[row, col] = true;
                        matrix[row, col] = int.MinValue;
                    }
                    else
                    {
                        var value = int.Parse(rowVal[col]);
                        if (row + value >= matrix.GetLength(0) &&
                            (row - value < 0 || matrix[row - value, col] == int.MinValue) &&
                            (col + value >= matrix.GetLength(1) || rowVal[col+value] == "#") &&
                            (col - value < 0 || matrix[row, col - value] == int.MinValue))
                        {
                            visited[row, col] = true;
                        }

                        matrix[row, col] = value;

                    }
                }
            }

            DFS(x, y, 0);
            Console.WriteLine(bigResult);
        }

        static void DFS(int x, int y, int result)
        {
            if (x < 0 || x >= matrix.GetLength(0) ||
                y < 0 || y >= matrix.GetLength(1) ||
                visited[x, y])
            {
                if (result > bigResult)
                {
                    bigResult = result;
                }

                return;
            }

            result += matrix[x, y];
            visited[x, y] = true;

            DFS(x - matrix[x, y], y, result);
            DFS(x, y - matrix[x, y], result);
            DFS(x + matrix[x, y], y, result);
            DFS(x, y + matrix[x, y], result);

            visited[x, y] = false;
        }
    }
}
