using System;
using System.Diagnostics;

namespace Dictionary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var watch = new Stopwatch();
            var random = new Random();

            var dictionary = new Dictionary<string, int>();

            watch.Start();
            for (int i = 0; i < 1_000_000; i++)
            {
                var rand = random.Next();
                dictionary.Add(rand.ToString(), rand);
            }
            watch.Stop();

            Console.WriteLine(dictionary.Count);
            Console.WriteLine(watch.Elapsed);
        }
    }
}
