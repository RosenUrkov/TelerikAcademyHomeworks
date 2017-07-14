using System;

namespace Prim
{
    public class Node : IComparable<Node>
    {
        public Node(int prev, int vertex, int distance)
        {
            this.Previous = prev;
            this.Vertex = vertex;
            this.Distance = distance;
        }

        public int Previous { get; set; }

        public int Vertex { get; set; }

        public int Distance { get; set; }

        public int CompareTo(Node other)
        {
            return this.Distance.CompareTo(other.Distance);
        }

        public override string ToString()
        {
            return $"From {this.Previous} to {this.Vertex} distance: {this.Distance}";
        }
    }
}
