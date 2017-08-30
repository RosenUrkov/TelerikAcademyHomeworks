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
        public int Value { get; set; }
        public LinkedList<int> Children { get; set; }
        public int ParentsCount { get; set; }
    }

    public class Program
    {
        static Dictionary<int, TopoNode> ReadDirectedGraph(int n)
        {
            var vertices = new Dictionary<int, TopoNode>();

            for (var i = 1; i <= n; i++)
            {
                var edges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (!vertices.ContainsKey(i))
                {
                    vertices[i] = new TopoNode
                    {
                        Value = i,
                        ParentsCount = 0,
                        Children = new LinkedList<int>(),
                    };
                }

                if (edges[0] == 0)
                {
                    continue;
                }

                foreach (var edge in edges)
                {
                    if (vertices.ContainsKey(edge) == false)
                    {
                        vertices[edge] = new TopoNode
                        {
                            Value = edge,
                            ParentsCount = 0,
                            Children = new LinkedList<int>(),
                        };
                    }

                    if (vertices[i].Children.Contains(edge))
                    {
                        Console.WriteLine(-1);
                        Environment.Exit(0);
                    }

                    vertices[edge].Children.AddLast(i);
                    vertices[i].ParentsCount++;
                }
            }

            return vertices;
        }

        static Dictionary<int, TopoNode> graph;

        static int[] times;
        static int[] memo;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            times = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            memo = new int[n + 1];

            graph = ReadDirectedGraph(n);
            foreach (var vertex in graph)
            {
                if (vertex.Value != null && vertex.Value.ParentsCount == 0)
                {
                    DFS(vertex.Value);
                }
            }

            var result = memo.Max();
            if (result == 0)
            {
                Console.WriteLine(-1);
                return;
            }

            Console.WriteLine(result);
        }

        static int DFS(TopoNode vertex)
        {
            if (memo[vertex.Value] != 0)
            {
                return memo[vertex.Value];
            }
            if (vertex.Children.Count == 0)
            {
                memo[vertex.Value] = times[vertex.Value - 1];
                return memo[vertex.Value];
            }

            var time = int.MinValue;
            foreach (var item in vertex.Children)
            {
                if (memo[item] == 0)
                {
                    memo[item] = DFS(graph[item]);
                }
                if (time < memo[item])
                {
                    time = memo[item];
                }
            }

            memo[vertex.Value] = time + times[vertex.Value - 1];
            return memo[vertex.Value];
        }
    }
}