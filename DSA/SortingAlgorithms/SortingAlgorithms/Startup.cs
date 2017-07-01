using System;
using System.Diagnostics;

namespace SortingAlgorithms
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var collection = new[] { 16, 1, 5, 7, 2, 5, 9, 63, 1, 2, 5, 8, 77, 15 };
            Console.WriteLine(string.Join(", ", collection));
            Console.WriteLine();

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            Console.WriteLine(SelectionSorter<int>.Sort(collection));
            stopwatch.Stop();

            Console.WriteLine(string.Join(", ", collection));
            Console.WriteLine(stopwatch.Elapsed);
            Console.WriteLine();

            stopwatch.Start();
            Console.WriteLine(QuickSorter<int>.Sort(collection));
            stopwatch.Stop();

            Console.WriteLine(string.Join(", ", collection));
            Console.WriteLine(stopwatch.Elapsed);
            Console.WriteLine();

            stopwatch.Start();
            Console.WriteLine(MergeSorter<int>.Sort(collection));
            stopwatch.Stop();

            Console.WriteLine(string.Join(", ", collection));
            Console.WriteLine(stopwatch.Elapsed);
            Console.WriteLine();

            stopwatch.Start();
            Console.WriteLine(Shuffler<int>.Shuffle(collection));
            stopwatch.Stop();

            Console.WriteLine(string.Join(", ", collection));
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
