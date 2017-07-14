using System;

namespace Kruskal
{
    public class Edge: IComparable<Edge>
    {
        public Edge(int from, int to, int distance)
        {
            this.From = from;
            this.To = to;
            this.Distance = distance;
        }

        public int From { get; set; }

        public int To { get; set; }

        public int Distance { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Distance.CompareTo(other.Distance);
        }

        public override string ToString()
        {
            return $"from {this.From} to {this.To} distance {this.Distance}";
        }
    }
}
