using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renewal
{
    public class Edge : IComparable<Edge>
    {
        public Edge(int startNode, int endNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public int StartNode { get; set; }

        public int EndNode { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            int weightCompared = this.Weight.CompareTo(other.Weight);
            if (weightCompared == 0)
            {
                return this.StartNode.CompareTo(other.StartNode);
            }

            return weightCompared;
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", this.StartNode, this.EndNode, this.Weight);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var current = Console.ReadLine();
                for (int j = 0; j < current.Length; j++)
                {
                    matrix[i, j] = current[j] - '0';
                }
            }

            var build = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var current = Console.ReadLine();
                for (int j = 0; j < current.Length; j++)
                {
                    build[i, j] = char.IsUpper(current[j]) ? current[j] - 'A' : (current[j] - 'a') + 26;
                }
            }

            var destroy = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var current = Console.ReadLine();
                for (int j = 0; j < current.Length; j++)
                {
                    destroy[i, j] = char.IsUpper(current[j]) ? current[j] - 'A' : (current[j] - 'a') + 26;
                }
            }

            long cost = 0;
            var edges = new List<Edge>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (matrix[i, j] == 1)
                    {
                        cost += destroy[i, j];
                        edges.Add(new Edge(i + 1, j + 1, -destroy[i, j]));

                        matrix[j, i] = 0;
                    }
                    else
                    {
                        edges.Add(new Edge(i + 1, j + 1, build[i, j]));
                    }
                }
            }

            edges.Sort();

            int[] tree = new int[n + 1]; //we start from 1, not from 0
            var mpd = new List<Edge>();
            int treesCount = 1;

            FindMinimumSpanningTree(edges, tree, mpd, treesCount);

            cost += mpd.Sum(x => x.Weight);
            Console.WriteLine(cost);
        }

        private static int FindMinimumSpanningTree(List<Edge> edges, int[] tree, List<Edge> mpd, int treesCount)
        {
            foreach (var edge in edges)
            {
                if (tree[edge.StartNode] == 0) // not visited
                {
                    if (tree[edge.EndNode] == 0) // both ends are not visited
                    {
                        tree[edge.StartNode] = tree[edge.EndNode] = treesCount;
                        treesCount++;
                    }
                    else
                    {
                        // attach the start node to the tree of the end node
                        tree[edge.StartNode] = tree[edge.EndNode];
                    }
                    mpd.Add(edge);
                }
                else // the start is part of a tree
                {
                    if (tree[edge.EndNode] == 0)
                    {
                        //attach the end node to the tree;
                        tree[edge.EndNode] = tree[edge.StartNode];
                        mpd.Add(edge);
                    }
                    else if (tree[edge.EndNode] != tree[edge.StartNode]) // combine the trees
                    {
                        int oldTreeNumber = tree[edge.EndNode];

                        for (int i = 0; i < tree.Length; i++)
                        {
                            if (tree[i] == oldTreeNumber)
                            {
                                tree[i] = tree[edge.StartNode];
                            }
                        }
                        mpd.Add(edge);
                    }
                }
            }
            return treesCount;
        }
    }
}