using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryTom
{
    public class Program
    {
        public static SortedSet<string> results = new SortedSet<string>();

        public static void Main(string[] args)
        {
            var roomsCount = int.Parse(Console.ReadLine());
            var doorsCount = int.Parse(Console.ReadLine());

            if (roomsCount < 1 || doorsCount < 1)
            {
                Console.WriteLine(-1);
                return;
            }

            var graph = ReadNonWeightedGraph(roomsCount, doorsCount);
            var visited = new HashSet<int>();

            DFS(1, 1, graph, visited, "");

            if (results.Count == 0)
            {
                Console.WriteLine(-1);
                return;
            }

            Console.WriteLine(results.Count);
            foreach (var item in results)
            {
                var corrcet = item
                    .Replace("9", "ten")
                    .Replace("8", "9")
                    .Replace("7", "8")
                    .Replace("6", "7")
                    .Replace("5", "6")
                    .Replace("4", "5")
                    .Replace("3", "4")
                    .Replace("2", "3")
                    .Replace("1", "2")
                    .Replace("0", "1")
                    .Replace("ten", "10");

                Console.WriteLine(corrcet);
            }
        }

        private static List<int>[] ReadNonWeightedGraph(int nodesCount, int edgesCount)
        {
            var vertices = new List<int>[nodesCount + 1];

            var current = new List<int[]>();
            for (int i = 0; i < edgesCount; i++)
            {
                current.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            }

            current.ForEach(x =>
            {
                var from = x[0];
                var to = x[1];

                if (vertices[from] == null)
                {
                    vertices[from] = new List<int>();
                }
                vertices[from].Add(to);

                if (vertices[to] == null)
                {
                    vertices[to] = new List<int>();
                }
                vertices[to].Add(from);
            });

            return vertices;
        }

        private static void DFS(int currVertex, int startVertex, List<int>[] vertices, HashSet<int> visited, string result)
        {
            if (visited.Count == vertices.Length - 2)
            {
                if (vertices[currVertex].Contains(startVertex))
                {
                    results.Add(result + (currVertex - 1) + " " + (startVertex - 1));
                }

                return;
            }

            visited.Add(currVertex);

            vertices[currVertex].ForEach(x =>
            {
                if (!visited.Contains(x))
                {
                    DFS(x, startVertex, vertices, visited, result + (currVertex - 1) + " ");
                }
            });

            visited.Remove(currVertex);
        }
    }
}
