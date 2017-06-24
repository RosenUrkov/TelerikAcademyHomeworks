using System;

namespace LinkedList
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var list = new LinkedList<int>();

            list.Add(4);
            list.Add(5);
            Console.WriteLine($"Size: {list.Size}");

            var item = list.First.Next;
            list.InsertAfter(item, 6);
            list.InsertAfter(item.Next, 7);
            Console.WriteLine($"Size: {list.Size}");
            
            list.Add(10);
            list.Add(11);
            Console.WriteLine($"Size: {list.Size}");
            
            item = item.Next.Next.Next;
            list.InsertBefore(item, 8);
            list.InsertBefore(item, 9);
            Console.WriteLine($"Size: {list.Size}");

            list.Remove(item.Next);
            list.Remove(item);
            Console.WriteLine($"Size: {list.Size}");
            
            list.InsertBefore(list.First, 2);
            list.InsertAfter(list.First, 3);
            list.InsertBefore(list.First, 1);
            list.Add(10);
            Console.WriteLine($"Size: {list.Size}");

            var current = list.First;
            while(current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }

            list.Clear();
            Console.WriteLine($"Size: {list.Size}");

            current = list.First;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
    }
}
