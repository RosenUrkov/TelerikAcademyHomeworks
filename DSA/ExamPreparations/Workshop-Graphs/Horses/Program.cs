using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horses
{
    public class Program
    {
        //public static int optimalResult = int.MaxValue;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new string[n, n];
            var visited = new bool[n, n];

            Position startCoords = null;
            Position endCoords = null;

            for (int row = 0; row < n; row++)
            {
                var rowValues = Console.ReadLine().Split(' ');
                for (int col = 0; col < n; col++)
                {
                    if (rowValues[col] == "x")
                    {
                        visited[row, col] = true;
                    }
                    if (rowValues[col] == "s")
                    {
                        startCoords = new Position(row, col, 0);
                    }
                    if (rowValues[col] == "e")
                    {
                        endCoords = new Position(row, col, 0);
                    }

                    matrix[row, col] = rowValues[col];
                }
            }

            var possibleRows = new int[] { 2, 2, -2, -2, 1, 1, -1, -1 };
            var possibleCols = new int[] { 1, -1, 1, -1, 2, -2, 2, -2 };

            var queue = new Queue<Position>();
            queue.Enqueue(startCoords);
            visited[startCoords.Item1, startCoords.Item2] = true;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                for (int i = 0; i < possibleCols.Length; i++)
                {
                    if (current.Item1 + possibleRows[i] < 0 ||
                        current.Item1 + possibleRows[i] >= matrix.GetLength(0) ||
                        current.Item2 + possibleCols[i] < 0 ||
                        current.Item2 + possibleCols[i] >= matrix.GetLength(1) ||
                        visited[current.Item1 + possibleRows[i], current.Item2 + possibleCols[i]])
                    {
                        continue;
                    }

                    if (current.Item1 + possibleRows[i] == endCoords.Item1 &&
                        current.Item2 + possibleCols[i] == endCoords.Item2)
                    {
                        Console.WriteLine(current.Item3 + 1);
                        return;
                    }

                    visited[current.Item1 + possibleRows[i], current.Item2 + possibleCols[i]] = true;
                    queue.Enqueue(new Position(current.Item1 + possibleRows[i], current.Item2 + possibleCols[i], current.Item3 + 1));
                }
            }

            Console.WriteLine("No");
        }
    }

    class Position
    {
        public Position(int Item1, int Item2, int Item3)
        {
            this.Item1 = Item1;
            this.Item2 = Item2;
            this.Item3 = Item3;
        }

        public int Item1 { get; set; }

        public int Item2 { get; set; }

        public int Item3 { get; set; }
    }
}
