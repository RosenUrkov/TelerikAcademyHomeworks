using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOccureanceCountInSequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var parameters = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int number = parameters[0];
            int endNumber = parameters[1];

            var queue = new Queue<int>();
            queue.Enqueue(endNumber);

            var sequence = new List<int>();
            while (true)
            {
                var current = queue.Dequeue();
                sequence.Add(current);

                if (current == number)
                {
                    break;
                }

                if (current / 2 >= number)
                {
                    if (current % 2 == 0)
                    {
                        queue.Enqueue(current / 2);
                    }
                    else
                    {
                        queue.Enqueue(current -= 1);
                    }
                }
                else if (current - 2 >= number)
                {
                    queue.Enqueue(current -= 2);
                }
                else
                {
                    queue.Enqueue(current -= 1);
                }
            }

            sequence.Reverse();
            Console.WriteLine(string.Join(" -> ", sequence));
        }
    }
}
