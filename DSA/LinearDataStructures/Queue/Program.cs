using System;

namespace Queue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var queue = new Queue<int>();

            Console.WriteLine(queue.Size);

            queue.Enqueue(5);
            queue.Enqueue(6);

            foreach (var item in queue)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            Console.WriteLine(queue.Size);

            var peek = queue.Peek();
            Console.WriteLine(peek);

            var dequeued = queue.Dequeue();
            Console.WriteLine(dequeued);

            Console.WriteLine(queue.Size);

            queue.Enqueue(7);
            queue.Enqueue(8);

            foreach (var item in queue)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            Console.WriteLine(queue.Size);

            queue.Clear();
            foreach (var item in queue)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            Console.WriteLine(queue.Size);
        }
    }
}
