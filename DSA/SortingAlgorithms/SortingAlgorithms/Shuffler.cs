using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public class Shuffler<T>
    {
        public static string Shuffle(T[] collection)
        {
            var shuffled = new T[collection.Length];
            collection.CopyTo(shuffled, 0);

            var random = new Random();
            for (int i = 0; i < shuffled.Length - 1; i++)
            {
                int swapIndex = random.Next(i + 1, shuffled.Length);
                var temp = shuffled[i];
                shuffled[i] = shuffled[swapIndex];
                shuffled[swapIndex] = temp;
            }

            return string.Join(", ", shuffled);
        }
    }
}
