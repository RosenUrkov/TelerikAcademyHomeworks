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
        public LinkedList<int> Children { get; set; }
        public int ParentsCount { get; set; }
    }

    public class PriorityQueue<T> where T : IComparable<T>
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

    public class Program
    {
        static Dictionary<int, TopoNode> ReadDirectedGraph()
        {
            var n = int.Parse(Console.ReadLine());
            var vertices = new Dictionary<int, TopoNode>();

            for (var i = 0; i < n; i++)
            {
                var edge = Console.ReadLine();

                var x = 0;
                var y = 0;
                var splitted = new string[2];

                if (edge.IndexOf('a') > -1)
                {
                    splitted = edge.Split(new[] { " is after " }, StringSplitOptions.RemoveEmptyEntries);
                    y = int.Parse(splitted[0]);
                    x = int.Parse(splitted[1]);
                }
                else
                {
                    splitted = edge.Split(new[] { " is before " }, StringSplitOptions.RemoveEmptyEntries);
                    x = int.Parse(splitted[0]);
                    y = int.Parse(splitted[1]);
                }

                if (vertices.ContainsKey(x) == false)
                {
                    vertices[x] = new TopoNode
                    {
                        ParentsCount = 0,
                        Children = new LinkedList<int>(),
                    };
                }

                if (vertices.ContainsKey(y) == false)
                {
                    vertices[y] = new TopoNode
                    {
                        ParentsCount = 0,
                        Children = new LinkedList<int>(),
                    };
                }
                vertices[x].Children.AddLast(y);
                vertices[y].ParentsCount++;
            }

            return vertices;
        }

        static void Main()
        {
            var result = TopologicalSort();
            Console.WriteLine(string.Join("", result));
        }

        private static List<int> TopologicalSort()
        {
            var graph = ReadDirectedGraph();
            var sources = ExtractSources(graph);

            var result = new List<int>();

            while (sources.Count > 0)
            {
                var source = sources.Dequeue();
                if(source == 0 && result.Count == 0)
                {
                    source = sources.Dequeue();
                    sources.Enqueue(0);
                }

                result.Add(source);

                var newSources = graph[source].Children;
                graph.Remove(source);
                UpdateSources(graph, newSources, sources);
            }

            return result;
        }

        private static void UpdateSources(Dictionary<int, TopoNode> graph, LinkedList<int> newSources, PriorityQueue<int> sources)
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

        private static PriorityQueue<int> ExtractSources(Dictionary<int, TopoNode> graph)
        {
            var queue = new PriorityQueue<int>();
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
}