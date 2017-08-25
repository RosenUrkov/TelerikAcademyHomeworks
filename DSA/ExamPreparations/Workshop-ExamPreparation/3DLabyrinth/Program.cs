using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DLabyrinth
{
    public class Point
    {
        public Point(int z, int x, int y, int result)
        {
            this.Z = z;
            this.X = x;
            this.Y = y;
            this.Result = result;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public int Result { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var start = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var levels = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var matrix = new string[levels[0], levels[1]];
            var visited = new bool[levels[0], levels[1], levels[2]];

            for (int i = 0; i < levels[0]; i++)
            {
                for (int j = 0; j < levels[1]; j++)
                {
                    matrix[i, j] = Console.ReadLine();
                }
            }

            var possibleRows = new int[] { 0, 0, 1, -1, };
            var possibleCols = new int[] { 1, -1, 0, 0, };

            var startPoint = new Point(start[0], start[1], start[2], 1);

            var queue = new Queue<Point>();
            queue.Enqueue(startPoint);
            visited[startPoint.Z, startPoint.X, startPoint.Y] = true;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if ((matrix[current.Z, current.X][current.Y] == 'U' && current.Z + 1 == levels[0]) ||
                        (matrix[current.Z, current.X][current.Y] == 'D' && current.Z == 0))
                {
                    Console.WriteLine(current.Result);
                    return;
                }
                if (matrix[current.Z, current.X][current.Y] == 'U')
                {
                    if (!(visited[current.Z + 1, current.X, current.Y] ||
                   matrix[current.Z + 1, current.X][current.Y] == '#'))
                    {
                        visited[current.Z + 1, current.X, current.Y] = true;
                        queue.Enqueue(new Point(current.Z + 1, current.X, current.Y, current.Result + 1));
                        continue;
                    }
                }
                if (matrix[current.Z, current.X][current.Y] == 'D')
                {
                    if (!(visited[current.Z - 1, current.X, current.Y] ||
                   matrix[current.Z - 1, current.X][current.Y] == '#'))
                    {
                        visited[current.Z - 1, current.X, current.Y] = true;
                        queue.Enqueue(new Point(current.Z - 1, current.X, current.Y, current.Result + 1));
                        continue;
                    }
                }

                for (int i = 0; i < possibleRows.Length; i++)
                {
                    if (current.X + possibleRows[i] < 0 ||
                       current.X + possibleRows[i] >= matrix.GetLength(1) ||
                       current.Y + possibleCols[i] < 0 ||
                       current.Y + possibleCols[i] >= matrix[0, 0].Length ||
                       visited[current.Z, current.X + possibleRows[i], current.Y + possibleCols[i]] ||
                       matrix[current.Z, current.X + possibleRows[i]][current.Y + possibleCols[i]] == '#')
                    {
                        continue;
                    }

                    if ((matrix[current.Z, current.X + possibleRows[i]][current.Y + possibleCols[i]] == 'U' && current.Z + 1 == levels[0]) ||
                        (matrix[current.Z, current.X + possibleRows[i]][current.Y + possibleCols[i]] == 'D' && current.Z == 0))
                    {
                        Console.WriteLine(current.Result + 1);
                        return;
                    }

                    visited[current.Z, current.X + possibleRows[i], current.Y + possibleCols[i]] = true;
                    if (matrix[current.Z, current.X + possibleRows[i]][current.Y + possibleCols[i]] == 'U')
                    {
                        if (!(visited[current.Z + 1, current.X + possibleRows[i], current.Y + possibleCols[i]] ||
                       matrix[current.Z + 1, current.X + possibleRows[i]][current.Y + possibleCols[i]] == '#'))
                        {
                            visited[current.Z + 1, current.X + possibleRows[i], current.Y + possibleCols[i]] = true;
                            queue.Enqueue(new Point(current.Z + 1, current.X + possibleRows[i], current.Y + possibleCols[i], current.Result + 2));
                            continue;
                        }
                    }
                    if (matrix[current.Z, current.X + possibleRows[i]][current.Y + possibleCols[i]] == 'D')
                    {
                        if (!(visited[current.Z - 1, current.X + possibleRows[i], current.Y + possibleCols[i]] ||
                       matrix[current.Z - 1, current.X + possibleRows[i]][current.Y + possibleCols[i]] == '#'))
                        {
                            visited[current.Z - 1, current.X + possibleRows[i], current.Y + possibleCols[i]] = true;
                            queue.Enqueue(new Point(current.Z - 1, current.X + possibleRows[i], current.Y + possibleCols[i], current.Result + 2));
                            continue;
                        }
                    }

                    queue.Enqueue(new Point(current.Z, current.X + possibleRows[i], current.Y + possibleCols[i], current.Result + 1));
                }
            }
        }
    }
}
