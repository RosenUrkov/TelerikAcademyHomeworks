using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public class SelectionSorter<T>
            where T : IComparable<T>
    {
        public static string Sort(T[] collection)
        {
            var sortedCollection = new T[collection.Length];
            collection.CopyTo(sortedCollection, 0);

            for (int i = 0; i < sortedCollection.Length; i++)
            {
                int minElementIndex = i;
                for (int j = i; j < sortedCollection.Length; j++)
                {
                    if (sortedCollection[minElementIndex].CompareTo(sortedCollection[j]) > 0)
                    {
                        minElementIndex = j;
                    }
                }

                var temp = sortedCollection[i];
                sortedCollection[i] = sortedCollection[minElementIndex];
                sortedCollection[minElementIndex] = temp;
            }

            return string.Join(", ", sortedCollection);
        }
    }
}
