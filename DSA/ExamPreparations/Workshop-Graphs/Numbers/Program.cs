using System;
using System.Collections.Generic;

namespace Bike
{
    public class Startup
    {
        static double[,] matrix;

        public static void Main()
        {
            var line = Console.ReadLine().Split(' ');

            int rows = int.Parse(line[0]);
            int cols = int.Parse(line[1]);

            ReadMatrix(rows, cols);

            var minDamage = Dijkstra(rows, cols);
            Console.WriteLine(minDamage);
        }

        public static double Dijkstra(int rows, int cols)
        {
            var distances = new double[rows * cols + 1];
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = double.MaxValue;
            }

            distances[1] = 0;

            var used = new HashSet<int>();
            var queue = new PriorityQueue<Edge>();
            queue.Enqueue(new Edge(1, 0));

            while (!queue.IsEmpty)
            {
                var currentNode = queue.Dequeue();

                while (queue.IsEmpty == false &&
                   used.Contains(currentNode.Target))
                {
                    currentNode = queue.Dequeue();
                }

                used.Add(currentNode.Target);

                var coordinates = GetRowAndCol(currentNode.Target);
                int currentRow = coordinates.Item1;
                int currentCol = coordinates.Item2;

                // right neighbour
                if (IsInRange(currentRow, currentCol + 1))
                {
                    var nextNode = GetNodeNumber(currentRow, currentCol + 1);
                    var weight = CalculateWeight(matrix[currentRow, currentCol], matrix[currentRow, currentCol + 1]);
                    var newDistance = distances[currentNode.Target] + weight;
                    var currentDistance = distances[nextNode];

                    if (newDistance < currentDistance)
                    {
                        distances[nextNode] = newDistance;
                        queue.Enqueue(new Edge(nextNode, newDistance));
                    }
                }

                // left neighbour
                if (IsInRange(currentRow, currentCol - 1))
                {
                    var nextNode = GetNodeNumber(currentRow, currentCol - 1);
                    var weight = CalculateWeight(matrix[currentRow, currentCol], matrix[currentRow, currentCol - 1]);
                    var newDistance = distances[currentNode.Target] + weight;
                    var currentDistance = distances[nextNode];

                    if (newDistance < currentDistance)
                    {
                        distances[nextNode] = newDistance;
                        queue.Enqueue(new Edge(nextNode, newDistance));
                    }
                }

                // up neighbour
                if (IsInRange(currentRow - 1, currentCol))
                {
                    var nextNode = GetNodeNumber(currentRow - 1, currentCol);
                    var weight = CalculateWeight(matrix[currentRow, currentCol], matrix[currentRow - 1, currentCol]);
                    var newDistance = distances[currentNode.Target] + weight;
                    var currentDistance = distances[nextNode];

                    if (newDistance < currentDistance)
                    {
                        distances[nextNode] = newDistance;
                        queue.Enqueue(new Edge(nextNode, newDistance));
                    }
                }

                // down neighbour
                if (IsInRange(currentRow + 1, currentCol))
                {
                    var nextNode = GetNodeNumber(currentRow + 1, currentCol);
                    var weight = CalculateWeight(matrix[currentRow, currentCol], matrix[currentRow + 1, currentCol]);
                    var newDistance = distances[currentNode.Target] + weight;
                    var currentDistance = distances[nextNode];

                    if (newDistance < currentDistance)
                    {
                        distances[nextNode] = newDistance;
                        queue.Enqueue(new Edge(nextNode, newDistance));
                    }
                }
            }

            return distances[distances.Length - 1] + Math.Abs(matrix[0, 0]);
        }

        public static void ReadMatrix(int rows, int cols)
        {
            matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine().Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = double.Parse(line[j]);
                }
            }
        }

        public static Tuple<int, int> GetRowAndCol(int node)
        {
            var col = (node % matrix.GetLength(1)) - 1;
            if (col < 0)
            {
                col += matrix.GetLength(1);
            }

            var row = (node - col - 1) / matrix.GetLength(1);

            return new Tuple<int, int>(row, col);
        }

        public static double CalculateWeight(double first, double second)
        {
            return second;
        }

        public static int GetNodeNumber(int row, int col)
        {
            return row * matrix.GetLength(1) + col + 1;
        }

        public static bool IsInRange(int row, int col)
        {
            return row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
        }
    }

    public class Edge : IComparable<Edge>
    {
        public Edge(int target, double weight)
        {
            this.Target = target;
            this.Weight = weight;
        }

        public int Target { get; set; }

        public double Weight { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }

    public class PriorityQueue<T>
       where T : IComparable<T>
    {
        private List<T> heap;
        private Func<T, T, bool> compare;

        public PriorityQueue()
        {
            this.heap = new List<T>
            {
                default(T)
            };

            this.compare = (x, y) => x.CompareTo(y) < 0;
        }

        public T Top
        {
            get
            {
                return this.heap[1];
            }
        }
        public int Count
        {
            get
            {
                return this.heap.Count - 1;
            }
        }
        public bool IsEmpty
        {
            get
            {
                return this.Count == 0;
            }
        }

        public void Enqueue(T value)
        {
            var index = heap.Count; // index where inserted
            heap.Add(value);

            while (index > 1 && compare(value, heap[index / 2]))
            {
                heap[index] = heap[index / 2];
                index /= 2;
            }

            heap[index] = value;
        }

        public T Dequeue()
        {
            var toReturn = heap[1];
            var value = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            if (!this.IsEmpty)
            {
                this.HeapifyDown(1, value);
            }

            return toReturn;
        }

        private void HeapifyDown(int index, T value)
        {
            while (index * 2 + 1 < heap.Count)
            {
                var smallerKidIndex = compare(heap[index * 2], heap[index * 2 + 1])
                    ? index * 2
                    : index * 2 + 1;
                if (compare(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
                else
                {
                    break;
                }
            }

            if (index * 2 < heap.Count)
            {
                var smallerKidIndex = index * 2;
                if (compare(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
            }

            heap[index] = value;
        }
    }
}