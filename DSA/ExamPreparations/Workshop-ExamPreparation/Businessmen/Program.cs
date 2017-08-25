using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Businessmen
{
    public class Pair
    {
        public Pair(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Pair;
            return (this.X == other.X || this.Y == other.Y) ||
                (this.X == other.Y || this.Y == other.X);
        }

        public override int GetHashCode()
        {
            return (this.X ^ this.Y).GetHashCode();
        }
    }

    public class Program
    {
        static int result = 0;
        public static HashSet<int> used = new HashSet<int>();

        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var factorials = new BigInteger[n + 1];
            factorials[0] = 1;

            for (int i = 1; i <= n; i++)
            {
                factorials[i] = i * factorials[i - 1];
            }

            Console.WriteLine(factorials[n] / (factorials[n / 2] * factorials[n / 2 + 1]));
        }
    }
}
