using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;

namespace Dijkstra
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = @"6
11
1 2 2
1 3 3
1 4 11
2 3 3
2 5 15
3 4 2
3 5 6
4 5 3
1 6 100
2 6 100
5 6 1";

            Console.SetIn(new StringReader(input));

            int nodesCount = int.Parse(Console.ReadLine());
            var graph = ReadWeightedGraph(nodesCount);

            var distances = Dijkstra(1, graph);
            Console.WriteLine(string.Join(", ", distances));
        }

        private static List<Node>[] ReadWeightedGraph(int nodesCount)
        {
            var vertices = new List<Node>[nodesCount + 1];

            Enumerable.Range(0, int.Parse(Console.ReadLine()))
                .Select(x =>
                {
                    return Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToArray();

                })
                .ToList()
                .ForEach(x =>
                {
                    var from = x[0];
                    var to = x[1];
                    var distance = x[2];

                    if (vertices[from] is null)
                    {
                        vertices[from] = new List<Node>();
                    }
                    vertices[from].Add(new Node(to, distance));

                    if (vertices[to] is null)
                    {
                        vertices[to] = new List<Node>();
                    }
                    vertices[to].Add(new Node(from, distance));
                });

            return vertices;
        }

        private static int[] Dijkstra(int vertex, List<Node>[] graph)
        {
            var distances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
            distances[vertex] = 0;

            var usedVertices = new Set<int>();

            // simulated priority queue
            var queue = new OrderedBag<Node>();
            queue.Add(new Node(vertex, 0));

            // must do it node's count number of times -> one time for each node
            for (int i = 1; i < graph.Length; i++)
            {
                var node = queue.RemoveFirst();

                while (queue.Count > 0 && usedVertices.Contains(node.Vertex))
                {
                    node = queue.RemoveFirst();
                }

                usedVertices.Add(node.Vertex);

                foreach (var next in graph[node.Vertex])
                {
                    var currentDistance = distances[next.Vertex];
                    var newDistance = distances[node.Vertex] + next.Distance;

                    var distance = Math.Min(currentDistance, newDistance);
                    distances[next.Vertex] = distance;

                    queue.Add(new Node(next.Vertex, distance));
                }
            }

            return distances.Skip(1).ToArray();
        }
    }
}
