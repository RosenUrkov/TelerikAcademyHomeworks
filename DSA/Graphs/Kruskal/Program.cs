using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;

namespace Kruskal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = @"5
8
2 5 15
3 5 6
4 5 3
1 3 3
1 2 2
1 4 11
2 3 3
3 4 2";

            Console.SetIn(new StringReader(input));

            var nodesCount = int.Parse(Console.ReadLine());
            var graph = ReadGraphEdges();

            var forest = Kruskal(nodesCount, graph);
            forest.ForEach(x => Console.WriteLine(string.Join(", ", x)));
        }

        private static OrderedBag<Edge> ReadGraphEdges()
        {
            var edges = new OrderedBag<Edge>();

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

        private static List<Edge> Kruskal(int nodesCount, OrderedBag<Edge> queue)
        {
            var forest = Enumerable.Repeat(-1, nodesCount + 1).ToArray();
            var result = new List<Edge>();

            while (queue.Count > 0)
            {
                var edge = queue.RemoveFirst();

                /* linear HQC slow style */
                //var oldRoot = forest[edge.To] == -1 ? edge.To : forest[edge.To];
                //var newRoot = forest[edge.From] == -1 ? edge.From : forest[edge.From];

                //if (oldRoot == newRoot)
                //{
                //    continue;
                //}

                //LinearUnion(oldRoot, newRoot, forest);
                //result.Add(edge);

                /* non HQC fast style */
                if (UnionFind(edge.From, forest) == UnionFind(edge.To, forest))
                {
                    continue;
                }

                forest[edge.To] = edge.From;
                result.Add(edge);
            }

            return result;
        }

        private static void LinearUnion(int oldRoot, int newRoot, int[] forest)
        {           
            forest[oldRoot] = newRoot;
            for (int i = 0; i < forest.Length; i++)
            {
                if(forest[i] == oldRoot)
                {
                    forest[i] = newRoot;
                }
            }           
        }

        private static int UnionFind(int vertex, int[] forest)
        {
            if (forest[vertex] == -1)
            {
                return vertex;
            }

            forest[vertex] = UnionFind(forest[vertex], forest);
            return forest[vertex];
        }
    }
}
