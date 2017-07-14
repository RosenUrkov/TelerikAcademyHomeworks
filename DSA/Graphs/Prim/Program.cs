using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;

namespace Prim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = @"5
8
1 2 2
1 3 3
1 4 11
2 3 3
3 4 2
2 5 15
3 5 6
4 5 3";

            Console.SetIn(new StringReader(input));

            var nodesCount = int.Parse(Console.ReadLine());

            var graphEdges = ReadGraphEdges();
            var optimalTreeEdges = PrimEdges(nodesCount, graphEdges);
            Console.WriteLine(string.Join(", ", optimalTreeEdges));

            var graphNodes = ReadGraphNodes(nodesCount);
            var optimalTreeNodes = PrimNodes(1, graphNodes);
            Console.WriteLine(string.Join(", ", optimalTreeNodes));
        }

        private static List<Edge> ReadGraphEdges()
        {
            var edges = new List<Edge>();

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

                    edges.Add(new Edge(from, to, distance));
                    edges.Add(new Edge(to, from, distance));
                });

            return edges;
        }

        private static List<Node>[] ReadGraphNodes(int nodesCount)
        {
            var nodes = new List<Node>[nodesCount + 1];

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
                    var weight = x[2];

                    if (nodes[from] is null)
                    {
                        nodes[from] = new List<Node>();
                    }
                    nodes[from].Add(new Node(from, to, weight));

                    if (nodes[to] is null)
                    {
                        nodes[to] = new List<Node>();
                    }
                    nodes[to].Add(new Node(to, from, weight));
                });

            return nodes;
        }

        private static List<Edge> PrimEdges(int nodesCount, List<Edge> graph)
        {
            var startVertex = graph[0].From;

            var queue = new OrderedBag<Edge>();
            queue.AddMany(graph.Where(x => x.From == startVertex));

            var visited = new bool[nodesCount + 1];
            var resultEdges = new List<Edge>();

            while (queue.Count > 0)
            {
                var optimalEdge = queue.RemoveFirst();
                if (visited[optimalEdge.From] && visited[optimalEdge.To])
                {
                    continue;
                }

                visited[optimalEdge.From] = true;
                visited[optimalEdge.To] = true;

                resultEdges.Add(optimalEdge);
                queue.AddMany(graph.Where(x => x.From == optimalEdge.To));
            }

            return resultEdges;
        }

        private static List<Node> PrimNodes(int startNode, List<Node>[] graph)
        {
            var queue = new OrderedBag<Node>();
            queue.AddMany(graph[startNode]);

            var visited = new bool[graph.Length];
            visited[startNode] = true;

            var resultNodes = new List<Node>();
            resultNodes.Add(new Node(startNode, startNode, 0));

            while (queue.Count > 0)
            {
                var node = queue.RemoveFirst();
                if (visited[node.Vertex])
                {
                    continue;
                }

                visited[node.Vertex] = true;

                resultNodes.Add(node);
                queue.AddMany(graph[node.Vertex]);
            }

            return resultNodes;
        }
    }
}
