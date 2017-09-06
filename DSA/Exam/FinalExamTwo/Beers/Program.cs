using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers
{
    class Node
    {
        public Node(int x, int y, long weight)
        {
            this.X = x;
            this.Y = y;
            this.Weight = weight;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public long Weight { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var rows = input[0];
            var cols = input[1];
            var beersCount = input[2];

            var matrix = new int[rows, cols];
            var distances = new long[rows, cols];
            var used = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    distances[row, col] = int.MaxValue;
                }
            }

            for (int i = 0; i < beersCount; i++)
            {
                var beer = Console.ReadLine().Split(' ');
                matrix[int.Parse(beer[0]), int.Parse(beer[1])] -= 5;
            }

            var directionsX = new int[] { 0, 0, 1, -1 };
            var directionsY = new int[] { 1, -1, 0, 0 };

            distances[0, 0] = matrix[0, 0];
            var queue = new Queue<Node>();
            queue.Enqueue(new Node(0, 0, matrix[0, 0]));

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (used[node.X, node.Y])
                {
                    continue;
                }

                used[node.X, node.Y] = true;

                for (int i = 0; i < directionsX.Length; i++)
                {
                    if (node.X + directionsX[i] < 0 ||
                        node.X + directionsX[i] >= rows ||
                        node.Y + directionsY[i] < 0 ||
                        node.Y + directionsY[i] >= cols ||
                        used[node.X + directionsX[i], node.Y + directionsY[i]])
                    {
                        continue;
                    }

                    var currentDistance = distances[node.X + directionsX[i], node.Y + directionsY[i]];
                    var newDistance = distances[node.X, node.Y] + matrix[node.X + directionsX[i], node.Y + directionsY[i]] + 1;

                    if (newDistance < currentDistance)
                    {
                        distances[node.X + directionsX[i], node.Y + directionsY[i]] = newDistance;
                        queue.Enqueue(new Node(node.X + directionsX[i], node.Y + directionsY[i], newDistance));
                    }
                }
            }

            Console.WriteLine(distances[rows - 1, cols - 1]);
        }
    }
}
