using System;

namespace Stack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);                       
            stack.Push(4);

            foreach (var item in stack)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            var peek = stack.Peek();
            Console.WriteLine(peek);
            var popped = stack.Pop();
            Console.WriteLine(popped);

            foreach (var item in stack)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            Console.WriteLine(stack.Size);
            Console.WriteLine(stack.Capacity);

            stack.Push(5);
            stack.Push(6);

            foreach (var item in stack)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            Console.WriteLine(stack.Size);
            Console.WriteLine(stack.Capacity);

            stack.Shrink();
            foreach (var item in stack)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            Console.WriteLine(stack.Size);
            Console.WriteLine(stack.Capacity);
        }
    }
}
