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
        static int[] array;

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
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        cost += destroy[i, j];
                        edges.Add(new Edge(i, j, -destroy[i, j]));
                    }
                    else
                    {
                        edges.Add(new Edge(i, j, build[i, j]));
                    }
                }
            }

            edges.Sort();

            Console.WriteLine(string.Join(" ", edges));

            array = Enumerable.Repeat(-1, n).ToArray();
            foreach (var edge in edges)
            {
                if (Union(edge.StartNode, edge.EndNode))
                {
                    cost += edge.Weight;
                }
            }

            Console.WriteLine(cost);
        }

        static bool Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);

            if (x == y)
            {
                return false;
            }

            array[x] = y;
            return true;
        }

        static int Find(int x)
        {
            if (array[x] < 0)
            {
                return x;
            }

            array[x] = Find(array[x]);
            return array[x];
        }
    }
}