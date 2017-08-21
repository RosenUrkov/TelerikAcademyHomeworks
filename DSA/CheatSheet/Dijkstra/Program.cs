using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
    public class Node : IComparable
    {
        public Node(int vertex, int distance)
        {
            this.Vertex = vertex;
            this.Distance = distance;
        }

        public int Vertex { get; set; }

        public int Distance { get; set; }

        public int CompareTo(object other)
        {
            var obj = other as Node;
            return this.Distance.CompareTo(obj.Distance);
        }
    }

    public class PriorityQueue<T> where T : IComparable
    {
        private T[] heap;
        private int index;

        public PriorityQueue()
        {
            this.heap = new T[16];
            this.index = 1;
        }

        public int Count
        {
            get
            {
                return this.index - 1;
            }
        }

        public void Enqueue(T element)
        {
            if (this.index >= this.heap.Length)
            {
                this.IncreaseArray();
            }

            this.heap[this.index] = element;

            int childIndex = this.index;
            int parentIndex = childIndex / 2;
            this.index++;

            while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapValue = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[childIndex];
                this.heap[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = childIndex / 2;
            }
        }

        public T Dequeue()
        {
            T result = this.heap[1];

            this.heap[1] = this.heap[this.Count];
            this.index--;

            int rootIndex = 1;

            while (true)
            {
                int leftChildIndex = rootIndex * 2;
                int rightChildIndex = (rootIndex * 2) + 1;

                if (leftChildIndex > this.index)
                {
                    break;
                }

                int minChild;
                if (rightChildIndex > this.index)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        minChild = rightChildIndex;
                    }
                }

                if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                {
                    T swapValue = this.heap[rootIndex];
                    this.heap[rootIndex] = this.heap[minChild];
                    this.heap[minChild] = swapValue;

                    rootIndex = minChild;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void IncreaseArray()
        {
            var copiedHeap = new T[this.heap.Length * 2];

            for (int i = 0; i < this.heap.Length; i++)
            {
                copiedHeap[i] = this.heap[i];
            }

            this.heap = copiedHeap;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var graph = ReadWeightedGraph(parameters[0], parameters[1]);
        }

        private static List<Node>[] ReadWeightedGraph(int nodesCount, int edgesCount)
        {
            var vertices = new List<Node>[nodesCount + 1];

            var current = new List<int[]>();
            for (int i = 0; i < edgesCount; i++)
            {
                current.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            }

            current.ForEach(x =>
            {
                var from = x[0];
                var to = x[1];
                var distance = x[2];

                if (vertices[from] == null)
                {
                    vertices[from] = new List<Node>();
                }
                vertices[from].Add(new Node(to, distance));

                if (vertices[to] == null)
                {
                    vertices[to] = new List<Node>();
                }
                vertices[to].Add(new Node(from, distance));
            });

            return vertices;
        }

        private static int[] Dijkstra(int start, List<Node>[] vertices)
        {
            var distances = new int[vertices.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                distances[i] = int.MaxValue;
            }

            distances[start] = 0;

            var used = new bool[vertices.Length];
            var queue = new PriorityQueue<Node>();

            queue.Enqueue(new Node(start, 0));

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                if (used[node.Vertex] == true)
                {
                    continue;
                }

                used[node.Vertex] = true;

                foreach (var next in vertices[node.Vertex])
                {
                    var currentDistance = distances[next.Vertex];
                    var newDistance = distances[node.Vertex] + next.Distance;

                    if (newDistance < currentDistance)
                    {
                        distances[next.Vertex] = newDistance;
                        queue.Enqueue(new Node(next.Vertex, newDistance));
                    }
                }
            }

            return distances;
        }
    }
}