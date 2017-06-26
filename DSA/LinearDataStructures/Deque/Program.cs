using System;

namespace Deque
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var deque = new Deque<int>();

            deque.PushBack(1);
            deque.PushFront(0);
            deque.PushBack(2);
            deque.PushFront(-1);

            foreach (var item in deque)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            Console.WriteLine(deque.Size);
            Console.WriteLine(deque.Capacity);

            deque.PushFront(-2);
            deque.PushFront(-3);

            foreach (var item in deque)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            Console.WriteLine(deque.Size);
            Console.WriteLine(deque.Capacity);

            deque.PushBack(3);
            deque.PushBack(4);
            deque.PushBack(5);

            foreach (var item in deque)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            Console.WriteLine(deque.Size);
            Console.WriteLine(deque.Capacity);

            var pf = deque.PeekFront();
            Console.WriteLine(pf);
            var df = deque.PopFront();
            Console.WriteLine(df);

            Console.WriteLine(deque.Size);
            Console.WriteLine(deque.Capacity);

            var pb = deque.PeekBack();
            Console.WriteLine(pb);
            var db = deque.PopBack();
            Console.WriteLine(db);

            Console.WriteLine(deque.Size);
            Console.WriteLine(deque.Capacity);

            foreach (var item in deque)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
    }
}
