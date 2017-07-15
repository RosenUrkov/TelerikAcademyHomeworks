using System;

namespace PriorityQueue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var queue = new PriorityQueue<int>((x, y) => x < y);

            for (int i = 10; i > 0; i--)
            {
                queue.Enqueue(i);
            }

            Console.WriteLine(string.Join(", ", queue));

            Console.WriteLine();
            Console.WriteLine(queue.Peek);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine();

            Console.WriteLine(string.Join(", ", queue));
            Console.WriteLine();

            var random = new Random();

            var array = new int[100];
            for (int i = 0; i < 100; i++)
            {
                array[i] = random.Next(0, 100);
            }

            array.HeapSort();
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
