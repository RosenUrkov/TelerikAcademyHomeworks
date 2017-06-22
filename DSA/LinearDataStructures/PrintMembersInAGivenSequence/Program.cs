using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOccureanceCountInSequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            queue.Enqueue(number);

            var list = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                var current = queue.Dequeue();

                queue.Enqueue(current + 1);
                queue.Enqueue(2*current + 1);
                queue.Enqueue(current + 2);

                list.Add(current);
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
