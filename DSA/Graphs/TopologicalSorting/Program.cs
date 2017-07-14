using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TopologicalSorting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = @"7
8
2 6 4
1 4 5
1 7 6
2 7 7
3 7 1
3 6 8
3 5 9
5 6 10";

            Console.SetIn(new StringReader(input));

            int nodesCount = int.Parse(Console.ReadLine());
            var graph = ReadGraph();

            var list = TopologicalSorting(graph);
            Console.WriteLine(string.Join(", ", list));
        }

        private static List<Edge> ReadGraph()
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
                    //var distance = x[2];

                    edges.Add(new Edge(from, to));
                });

            return edges;
        }

        private static List<int> TopologicalSorting(List<Edge> graph)
        {
            var startVertices = new HashSet<int>();
            var endVertices = new HashSet<int>();

            graph.ForEach(x =>
            {
                startVertices.Add(x.From);
                endVertices.Add(x.To);
            });

            var noIncomingEdges = new Queue<int>();
            startVertices
                .Where(x => !endVertices.Contains(x))
                .ToList()
                .ForEach(x => noIncomingEdges.Enqueue(x));

            var resultVertices = new List<int>();
            while (noIncomingEdges.Count > 0)
            {
                var vertex = noIncomingEdges.Dequeue();
                resultVertices.Add(vertex);

                var newGraph = graph.Where(x => x.From != vertex);

                graph
                    .Where(x => x.From == vertex)
                    .Select(x => x.To)
                    .Where(x => newGraph.All(y => y.To != x))
                    .ToList()
                    .ForEach(x => noIncomingEdges.Enqueue(x));

                graph = newGraph.ToList();
            }

            return resultVertices;
        }
    }
}
