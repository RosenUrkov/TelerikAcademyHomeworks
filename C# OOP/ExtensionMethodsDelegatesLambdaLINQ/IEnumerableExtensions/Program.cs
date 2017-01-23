namespace IEnumerableExtensions
{
    using System.Collections.Generic;
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(-4);

            var result = list.Sum<int>();
            var result2 = list.Product<long>();
            Console.WriteLine(list.Min<int>());
            Console.WriteLine(list.Max<int>());
            Console.WriteLine(Math.Round(list.Average<int>(),2));
        }
    }
}
