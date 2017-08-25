using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace GraphsAlgorithms
{
    class TopoNode
    {
        public LinkedList<char> Children { get; set; }
        public int ParentsCount { get; set; }
    }

    public class Program
    {
        static Dictionary<char, TopoNode> ReadDirectedGraph()
        {
            var n = int.Parse(Console.ReadLine());

            var vertices = new Dictionary<char, TopoNode>();

            for (var i = 0; i < n; i++)
            {
                var edge = Console.ReadLine();

                for (int j = 0; j < edge.Length; j++)
                {
                    var x = edge[j];
                    if (vertices.ContainsKey(x) == false)
                    {
                        vertices[x] = new TopoNode
                        {
                            ParentsCount = 0,
                            Children = new LinkedList<char>(),
                        };
                    }

                    for (int k = j + 1; k < edge.Length; k++)
                    {
                        var y = edge[k];
                        if (vertices.ContainsKey(y) == false)
                        {
                            vertices[y] = new TopoNode
                            {
                                ParentsCount = 0,
                                Children = new LinkedList<char>(),
                            };
                        }

                        vertices[x].Children.AddLast(y);
                        vertices[y].ParentsCount++;
                    }
                }
            }

            return vertices;
        }

        static void Main()
        {
            var result = TopologicalSort();
            Console.WriteLine(string.Join("", result));
        }

        private static List<char> TopologicalSort()
        {
            var graph = ReadDirectedGraph();
            var sources = ExtractSources(graph);

            var result = new List<char>();

            while (sources.Count > 0)
            {
                var source = sources.Dequeue();
                result.Add(source);

                var newSources = graph[source].Children;
                graph.Remove(source);
                UpdateSources(graph, newSources, sources);
            }

            return result;
        }

        private static void UpdateSources(Dictionary<char, TopoNode> graph, LinkedList<char> newSources, PriorityQueue<char> sources)
        {
            foreach (var newSource in newSources)
            {
                --graph[newSource].ParentsCount;
                if (graph[newSource].ParentsCount == 0)
                {
                    sources.Enqueue(newSource);
                }
            }
        }

        private static PriorityQueue<char> ExtractSources(Dictionary<char, TopoNode> graph)
        {
            var queue = new PriorityQueue<char>();
            foreach (var vertex in graph)
            {
                if (vertex.Value != null && vertex.Value.ParentsCount == 0)
                {
                    queue.Enqueue(vertex.Key);
                }
            }

            return queue;
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

        public T Top => heap[1];
        public int Count => heap.Count - 1;
        public bool IsEmpty => Count == 0;

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
