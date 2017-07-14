using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GraphsTraversal
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

            var verticesList = AdjacencyList(nodesCount);
            PrintAdjacencyList(verticesList);

            var matrix = NeighborhoodMatrix(nodesCount);
            PrintNeighborhoodMatrix(matrix);

            var edgesList = EdgesList(nodesCount);
            PrintEdgesList(edgesList);
        }

        private static LinkedList<(int vertex, int weight)>[] AdjacencyList(int nodesCount)
        {
            var vertices = new LinkedList<(int vertex, int weight)>[nodesCount + 1];

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

                    if (vertices[from] is null)
                    {
                        vertices[from] = new LinkedList<(int vertex, int weight)>();
                    }
                    vertices[from].AddLast((to, weight));

                    if (vertices[to] is null)
                    {
                        vertices[to] = new LinkedList<(int vertex, int weight)>();
                    }
                    vertices[to].AddLast((from, weight));
                });

            return vertices;
        }

        private static int?[,] NeighborhoodMatrix(int nodesCount)
        {
            var matrix = new int?[nodesCount + 1, nodesCount + 1];

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

                    matrix[from, to] = weight;
                    matrix[to, from] = weight;
                });

            return matrix;
        }

        private static List<(int from, int to, int weight)> EdgesList(int nodesCount)
        {
            var edges = new List<(int from, int to, int weight)>();

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
                    edges.Add((x[0], x[1], x[2]));
                    edges.Add((x[1], x[0], x[2]));
                });

            return edges;
        }

        private static void PrintNeighborhoodMatrix(int?[,] matrix)
        {
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    Console.Write((matrix[row, col]?.ToString() ?? "-") + " ");
                }

                Console.WriteLine();
            }
        }

        private static void PrintEdgesList(List<(int from, int to, int weight)> edges)
        {
            foreach (var item in edges)
            {
                Console.WriteLine(item);
            }
        }

        private static void PrintAdjacencyList(LinkedList<(int vertex, int weight)>[] vertices)
        {
            var visited = new bool[vertices.Length];

            PrintAdjacencyListDFS(1, visited, vertices);

            Console.WriteLine();

            PrintAdjacencyListBFS(vertices);
        }

        private static void PrintAdjacencyListDFS(int current, bool[] visited, LinkedList<(int vertex, int weight)>[] vertices)
        {
            if (visited[current])
            {
                return;
            }

            visited[current] = true;

            foreach (var item in vertices[current])
            {
                Console.WriteLine($"vertex: {current} adjacent vertex {item.vertex} with weight {item.weight}");
                PrintAdjacencyListDFS(item.vertex, visited, vertices);
            }
        }

        private static void PrintAdjacencyListBFS(LinkedList<(int vertex, int weight)>[] vertices)
        {
            var visited = new bool[vertices.Length];

            var queue = new Queue<(int current, LinkedList<(int vertex, int weight)> adjacent)>();

            queue.Enqueue((1, vertices[1]));
            visited[1] = true;
            
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                foreach (var item in vertex.adjacent)
                {
                    Console.WriteLine($"vertex: {vertex.current} adjacent vertex {item.vertex} with weight {item.weight}");

                    if (visited[item.vertex])
                    {
                        continue;
                    }

                    visited[item.vertex] = true;
                    queue.Enqueue((item.vertex, vertices[item.vertex]));
                }
            }
        }
    }
}
