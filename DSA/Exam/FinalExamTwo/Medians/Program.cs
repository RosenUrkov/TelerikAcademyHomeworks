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
        static OrderedBag<long> numbers = new OrderedBag<long>();

        static void Main(string[] args)
        {
            var builder = new StringBuilder();
            while (true)
            {
                var command = Console.ReadLine().Split(' ');

                switch (command[0][0])
                {
                    case 'A': Add(long.Parse(command[1])); break;
                    case 'F': builder.AppendLine(Find()); break;
                    case 'E': Console.WriteLine(builder.ToString().TrimEnd()); return;
                }
            }
        }

        static void Add(long number)
        {
            numbers.Add(number);
        }

        static string Find()
        {
            if (numbers.Count % 2 == 1)
            {
                return numbers[numbers.Count / 2].ToString();
            }

            return ((numbers[numbers.Count / 2 - 1] + numbers[numbers.Count / 2]) / (double)2).ToString();
        }
    }
}
