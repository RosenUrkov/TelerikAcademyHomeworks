using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapping
{
    class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }

        public Node Prev { get; set; }

        public Node Next { get; set; }

        public int Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var swappers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var numbers = new Node[n + 1];
            for (int i = 1; i <= n; i++)
            {
                var node = new Node(i);
                if (i == 1)
                {
                    numbers[i] = node;
                    continue;
                }

                node.Prev = numbers[i - 1];
                node.Prev.Next = node;
                numbers[i] = node;
            }

            var first = numbers[1];
            var last = numbers[n];

            for (int i = 0; i < swappers.Length; i++)
            {
                var swapper = numbers[swappers[i]];

                if (swapper.Value == first.Value)
                {
                    var next = first.Next;
                    var prevLast = last;

                    last = first;
                    last.Next = null;
                    last.Prev = prevLast;
                    prevLast.Next = last;

                    first = next;
                    next.Prev = null;
                }
                else if (swapper.Value == last.Value)
                {
                    var prev = last.Prev;
                    var prevFirst = first;

                    first = last;
                    first.Prev = null;
                    first.Next = prevFirst;
                    prevFirst.Prev = first;

                    last = prev;
                    prev.Next = null;
                }
                else
                {
                    var next = swapper.Next;
                    swapper.Next = first;
                    first.Prev = swapper;
                    first = next;
                    first.Prev = null;

                    var prev = swapper.Prev;
                    swapper.Prev = last;
                    last.Next = swapper;
                    last = prev;
                    last.Next = null;
                }
            }

            var curr = first;
            var builder = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                builder.Append(curr.Value + " ");
                curr = curr.Next;
            }

            Console.WriteLine(builder.ToString().TrimEnd());
        }
    }
}