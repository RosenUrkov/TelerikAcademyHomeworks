using System;

namespace SearchingAlgorithms
{
    public class BinarySearcher<T>
        where T : IComparable
    {
        public static int SearchIndex(T value, T[] collection)
        {
            int startIndex = 0;
            int endIndex = collection.Length;

            return BinarySearch(startIndex, endIndex, value, collection);
        }

        private static int BinarySearch(int startIndex, int endIndex, T value, T[] collection)
        {
            if (startIndex > endIndex)
            {
                return -1;
            }

            int middleIndex = (startIndex + endIndex) / 2;

            if (collection[middleIndex].CompareTo(value) == 0)
            {
                return middleIndex;
            }
            else if (collection[middleIndex].CompareTo(value) > 0)
            {
                return BinarySearch(startIndex, middleIndex, value, collection);
            }
            else
            {
                return BinarySearch(middleIndex + 1, endIndex, value, collection);
            }
        }
    }
}
