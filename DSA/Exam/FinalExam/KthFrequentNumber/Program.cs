using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace KthFrequentNumber
{
    class Pair : IComparable<Pair>
    {
        public Pair(int n, int f)
        {
            this.Number = n;
            this.Frequency = f;
        }

        public int Number { get; set; }

        public int Frequency { get; set; }

        public int CompareTo(Pair other)
        {
            return other.Frequency.CompareTo(this.Frequency);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Pair;
            return this.Number.Equals(other.Number);
        }

        public override int GetHashCode()
        {
            return this.Number;
        }
    }

    class Program
    {
        static Dictionary<long, int> pairs = new Dictionary<long, int>();

        static void Main(string[] args)
        {
            var builder = new StringBuilder();
            while (true)
            {
                var command = Console.ReadLine().Split(' ');

                switch (command[0][0])
                {
                    case 'A': builder.AppendLine(Add(long.Parse(command[1]))); break;
                    case 'R': builder.AppendLine(Remove(long.Parse(command[1]))); break;
                    case 'G': builder.AppendLine(Get(long.Parse(command[1]))); break;
                    case 'E': Console.WriteLine(builder.ToString().TrimEnd()); return;
                }
            }
        }

        static string Add(long number)
        {
            if (!pairs.ContainsKey(number))
            {
                pairs[number] = 0;
            }

            pairs[number]++;
            return "Ok: " + number + " added";
        }

        static string Get(long number)
        {
            if (number < 1)
            {
                return "Error: " + number + " is invalid K";
            }

            var sorted = pairs.OrderBy(x => -x.Value).ThenBy(x => x.Key);

            var counter = 1;
            foreach (var item in sorted)
            {
                if (counter == number)
                {
                    return "Ok: Found " + item.Key;
                }

                counter++;
            }

            return "Error: " + number + " is invalid K";
        }

        static string Remove(long number)
        {
            if (!pairs.ContainsKey(number) || pairs[number] == 0)
            {
                return "Error: Number " + number + " not found";
            }

            pairs[number]--;
            if (pairs[number] == 0)
            {
                pairs.Remove(number);
            }

            return "Ok: Number " + number + " removed";
        }
    }
}
