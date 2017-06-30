using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms
{
    public class QuickSorter<T>
           where T : IComparable<T>
    {
        public static string Sort(T[] collection)
        {
            var sortedCollection = new List<T>(collection);
            var result = Quicksort(sortedCollection);

            return string.Join(", ", result);
        }

        private static List<T> Quicksort(List<T> collection)
        {
            if(collection.Count <= 1)
            {
                return collection;
            }

            var pivotIndex = collection.Count / 2;

            var left = new List<T>();
            var right = new List<T>();

            for (int i = 0; i < collection.Count; i++)
            {
                if(i == pivotIndex)
                {
                    continue;
                }

                if (collection[i].CompareTo(collection[pivotIndex]) < 0)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            var result = Quicksort(left);
            result.Add(collection[pivotIndex]);
            result.AddRange(Quicksort(right));

            return result;
        }
    }
}
