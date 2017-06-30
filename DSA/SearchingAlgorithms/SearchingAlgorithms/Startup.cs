using System;

namespace SearchingAlgorithms
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var collection = new[] { 1, 2, 5, 7, 8, 21, 36, 73, 92, 134, 204, 502, 1088 };

            Console.WriteLine(LinearSearcher<int>.SearchIndex(21, collection));
            Console.WriteLine(BinarySearcher<int>.SearchIndex(21, collection));
        }
    }
}
