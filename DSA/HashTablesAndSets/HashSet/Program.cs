using System;
using System.Diagnostics;

namespace HashSet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var watch = new Stopwatch();
            var random = new Random();

            var set = new HashSet<int>();

            watch.Start();
            for (int i = 0; i < 1_000_000; i++)
            {
                set.Add(random.Next());
            }
            watch.Stop();

            Console.WriteLine(set.Count);
            Console.WriteLine(watch.Elapsed);
        }
    }
}
