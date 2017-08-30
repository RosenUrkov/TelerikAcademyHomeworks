namespace Kruskal
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split(' ');
            int nodesCount = int.Parse(line[0]);
            int edgesCount = int.Parse(line[1]);

            List<Edge> edges = new List<Edge>();
            InitializeGraph(edges, edgesCount);

            int[] tree = new int[nodesCount]; //we start from 1, not from 0
            int treesCount = 1;

            FindMinimumSpanningTree(edges, tree, treesCount);

            var result = new int[nodesCount];
            for (int i = 0; i < tree.Length; i++)
            {
                result[tree[i]]++;
            }

            long sum = 0;
            for (int i = nodesCount - 1; i > 0; i--)
            {
                sum += result[i] * (nodesCount - result[i]);
                nodesCount -= result[i];
            }

            long noFactorial = 0;
            for (int i = result[0] - 1; i > 0; i--)
            {
                noFactorial += i;
            }

            sum += noFactorial;
            Console.WriteLine(sum);
        }

        private static int FindMinimumSpanningTree(List<Edge> edges, int[] tree, int treesCount)
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
                }
                else // the start is part of a tree
                {
                    if (tree[edge.EndNode] == 0)
                    {
                        //attach the end node to the tree;
                        tree[edge.EndNode] = tree[edge.StartNode];
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
                    }
                }
            }
            return treesCount;
        }

        private static void InitializeGraph(List<Edge> edges, int edgesCount)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                var line = Console.ReadLine().Split(' ');
                edges.Add(new Edge(int.Parse(line[0]), int.Parse(line[1])));
            }
        }
    }

    public class Edge
    {
        public Edge(int startNode, int endNode)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
        }

        public int StartNode { get; set; }

        public int EndNode { get; set; }
    }
}