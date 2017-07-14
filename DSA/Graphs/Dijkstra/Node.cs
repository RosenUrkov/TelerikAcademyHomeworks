using System;

namespace Dijkstra
{
    public class Node : IComparable<Node>
    {
        public Node(int vertex, int distance)
        {
            this.Vertex = vertex;
            this.Distance = distance;
        }

        public int Vertex { get; set; }

        public int Distance { get; set; }

        public int CompareTo(Node other)
        {
            return this.Distance.CompareTo(other.Distance);
        }
    }
}
