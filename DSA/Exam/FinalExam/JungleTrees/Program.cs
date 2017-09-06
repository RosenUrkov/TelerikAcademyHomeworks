using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JungleTrees
{
    class Pair : IComparable<Pair>
    {
        public Pair(int x, int h)
        {
            this.X = x;
            this.H = h;
        }

        public int X { get; set; }

        public int H { get; set; }

        public int CompareTo(Pair other)
        {
            return this.X.CompareTo(other.X);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var nodesCount = input[0];
            var maxX = input[1];
            var maxH = input[2];

            var pairs = new List<Pair>();
            for (int i = 0; i < nodesCount; i++)
            {
                var x = Console.ReadLine().Split(' ');
                pairs.Add(new Pair(int.Parse(x[0]), int.Parse(x[1])));
            }

            pairs = pairs.OrderBy(x => x.X).ThenBy(x => x.H).ToList();

            var result = 0;
            var current = pairs[0];

            for (int i = 1; i < pairs.Count; i++)
            {
                if (Math.Abs(current.X - pairs[i].X) <= maxX &&
                    Math.Abs(current.H - pairs[i].H) <= maxH)
                {
                    if (i < pairs.Count - 1 &&
                         Math.Abs(current.X - pairs[i + 1].X) <= maxX &&
                         Math.Abs(current.H - pairs[i + 1].H) <= maxH)
                    {
                        continue;
                    }
                    else
                    {
                        result++;
                        current = pairs[i];
                    }
                }
            }

            if (result == 0)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(result);
            }
        }
    }
}
