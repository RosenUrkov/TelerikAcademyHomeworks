namespace PrimAlgorithm
{
    using System;
    using System.Collections.Generic;

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

    public class Program
    {
        public static void Main()
        {
            const int numberOfNodes = 6;
            const int numberOfEdges = 5;

            var used = new bool[numberOfNodes + 1];           

            var edges = new List<Edge>();
            InitializeGraph(edges, numberOfEdges);

            var priority = new SortedSet<Edge>();
            var resultTree = new List<Edge>();

            // adding edges that connect the node 1 with all the others - 2, 3, 4
            foreach (Edge edge in edges)
            {
                if (edge.StartNode == edges[0].StartNode)
                {
                    priority.Add(edge);
                }
            }

            used[edges[0].StartNode] = true;
            FindMinimumSpanningTree(used, priority, resultTree, edges);
        }

        private static void FindMinimumSpanningTree(bool[] used, SortedSet<Edge> priority, List<Edge> mpdEdges, List<Edge> edges)
        {
            while (priority.Count > 0)
            {
                Edge edge = priority.Min;
                priority.Remove(edge);

                if (!used[edge.EndNode])
                {
                    used[edge.EndNode] = true; // we "visit" this node
                    mpdEdges.Add(edge);
                    AddEdges(edge, edges, mpdEdges, priority, used);
                }
            }
        }

        private static void AddEdges(Edge edge, List<Edge> edges, List<Edge> mpd, SortedSet<Edge> priority, bool[] used)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (!mpd.Contains(edges[i]))
                {
                    if (edge.EndNode == edges[i].StartNode && !used[edges[i].EndNode])
                    {
                        priority.Add(edges[i]);
                    }
                }
            }
        }

        private static void InitializeGraph(List<Edge> edges, int edgesCount)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                var line = Console.ReadLine().Split(' ');
                edges.Add(new Edge(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2])));
            }
        }
    }
}