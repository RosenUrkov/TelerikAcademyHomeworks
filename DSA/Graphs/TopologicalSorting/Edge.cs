namespace TopologicalSorting
{
    public class Edge
    {
        public Edge(int from, int to)
        {
            this.From = from;
            this.To = to;
        }

        public int From { get; set; }

        public int To { get; set; }
    }
}
