using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public class MergeSorter<T>
         where T : IComparable<T>

    {
        public static string Sort(T[] collection)
        {
            var sortedCollection = new List<T>(collection);
            var result = Mergesort(sortedCollection);

            return string.Join(", ", result);
        }

        private static List<T> Mergesort(List<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            var left = new List<T>();
            var right = new List<T>();

            for (int i = 0; i < collection.Count; i++)
            {
                if (i < collection.Count / 2)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            left = Mergesort(left);
            right = Mergesort(right);

            return Merge(left, right);
        }

        private static List<T> Merge(List<T> left, List<T> right)
        {
            var result = new List<T>();

            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            var collection = leftIndex == left.Count ? right : left;
            var continueIndex = leftIndex == left.Count ? rightIndex : leftIndex;

            for (int i = continueIndex; i < collection.Count; i++)
            {
                result.Add(collection[i]);
            }

            return result;
        }
    }
}
