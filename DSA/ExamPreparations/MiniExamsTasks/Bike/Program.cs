using System;
using System.Collections.Generic;
using System.Linq;

namespace Bike
{
    public class Solution
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var field = new double[rows][];
            for (var i = 0; i < rows; i++)
            {
                field[i] = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            }

            var deltaOdd = new int[2, 6]
            {
                { 1, 1, 0, 0, -1, -1},
                { 0, -1, -1, 1, 0, -1},
            };

            var deltaEven = new int[2, 6]
            {
                { 1, 1, 0, 0, -1, -1},
                { 0, 1, -1, 1, 0, 1},
            };

            var sumTo = new double[rows, cols];
            for (var i = 0; i < rows; ++i)
            {
                for (var j = 0; j < cols; ++j)
                {
                    sumTo[i, j] = double.MaxValue;
                }
            }

            sumTo[0, 0] = Math.Abs(field[0][0]);
            var used = new bool[rows, cols];

            var queue = new PriorityQueue<Vector>();
            queue.Enqueue(new Vector(0, 0, Math.Abs(field[0][0])));

            while (queue.Count > 0)
            {
                var x = queue.Dequeue();
                used[x.Row, x.Col] = true;

                var row = x.Row;
                var col = x.Col;
                var sum = sumTo[row, col];

                var currentDelta = (row & 1) == 1 ? deltaEven : deltaOdd;

                for (var i = 0; i < 6; i++)
                {
                    var newRow = row + currentDelta[0, i];
                    var newCol = col + currentDelta[1, i];

                    if (IsValid(newRow, rows, newCol, cols, used))
                    {
                        var damage = Math.Abs(field[row][col] - field[newRow][newCol]);

                        if (sum + damage < sumTo[newRow, newCol])
                        {
                            sumTo[newRow, newCol] = sum + damage;
                            queue.Enqueue(new Vector(newRow, newCol, sumTo[newRow, newCol]));
                        }
                    }
                }
            }

            var result = sumTo[rows - 1, cols - 1] + Math.Abs(field[rows - 1][cols - 1]);

            Console.WriteLine(string.Format("{0:F2}", result));
        }

        private static bool IsValid(int row, int rows, int col, int cols, bool[,] used)
        {
            return 0 <= col && col < cols && 0 <= row && row < rows && !used[row, col];
        }
    }

    public class Vector : IComparable<Vector>
    {
        public Vector(int row, int col, double number)
        {
            Row = row;
            Col = col;
            Number = number;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public double Number { get; set; }

        public int CompareTo(Vector other)
        {
            return this.Number.CompareTo(other.Number);
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
                return heap[1];
            }
        }
        public int Count
        {
            get
            {
                return heap.Count - 1;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return Count == 0;
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