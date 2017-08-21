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

    class Node : IComparable<Node>
    {
        public Node(int vertex, int distance)
        {
            Vertex = vertex;
            Distance = distance;
        }

        public int Vertex { get; set; }

        public int Distance { get; set; }

        public int CompareTo(Node other)
        {
            return this.Distance.CompareTo(other.Distance);
        }
    }

    public class Program
    {
        static LinkedList<int>[] ReadGraph()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            var vertices = new LinkedList<int>[n];

            for (var i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var x = edge[0] - 1;
                var y = edge[1] - 1;

                AddEdge(vertices, x, y);
                AddEdge(vertices, y, x);
            }

            return vertices;
        }

        private static void AddEdge(LinkedList<int>[] vertices, int from, int to)
        {
            if (vertices[from] == null)
            {
                vertices[from] = new LinkedList<int>();
            }

            vertices[from].AddLast(to);
        }

        static Dictionary<int, TopoNode> ReadDirectedGraph()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var vertices = new Dictionary<int, TopoNode>();

            for (var i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var x = edge[0];
                var y = edge[1];

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

        private static List<Node>[] ReadWeightedGraph()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var vertices = new List<Node>[n];

            for (var i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                AddWeightedEdge(vertices, edge[0] - 1, edge[1] - 1, edge[2]);
                AddWeightedEdge(vertices, edge[1] - 1, edge[0] - 1, edge[2]);
            }

            return vertices;
        }

        private static void AddWeightedEdge(List<Node>[] vertices, int from, int to, int distance)
        {
            if (vertices[from] == null)
            {
                vertices[from] = new List<Node>();
            }
            vertices[from].Add(new Node(to, distance));
        }

        static void Main()
        {
            var result = TopologicalSort();
        }

        private static List<int> TopologicalSort()
        {
            var graph = ReadDirectedGraph();
            var sources = ExtractSources(graph);

            var result = new List<int>();

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

        private static void UpdateSources(Dictionary<int, TopoNode> graph, LinkedList<int> newSources, Queue<int> sources)
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

        private static Queue<int> ExtractSources(Dictionary<int, TopoNode> graph)
        {
            var queue = new Queue<int>();
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