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

    public class Program
    {
        static Dictionary<int, TopoNode> ReadDirectedGraph()
        {
            var n = int.Parse(Console.ReadLine());

            var vertices = new Dictionary<int, TopoNode>();

            for (var i = 0; i < n; i++)
            {
                var edge = Console.ReadLine().ToCharArray();

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