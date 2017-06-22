using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseIntNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stack = new Stack<int>();
            var numbersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbersCount; i++)
            {
                stack.Push(int.Parse(Console.ReadLine()));
            }

            // easy way
            //stack.Reverse();

            // hard way
            var reversedStack = new Stack<int>();
            var length = stack.Count;
            for (int i = 0; i < length; i++)
            {
                var item = stack.Pop();
                reversedStack.Push(item);
            }
            
            Console.WriteLine(string.Join(", ", reversedStack));
        }
    }
}
