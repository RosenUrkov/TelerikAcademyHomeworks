namespace MathsAndSortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class Sorter
    {
        public IList<T> SelectionSort<T>(IList<T> collection) where T : IComparable<T>
        {
            var sorted = new List<T>(collection);

            for (int i = 0; i < sorted.Count; i++)
            {
                int minElementIndex = i;
                for (int j = i; j < sorted.Count; j++)
                {
                    if (sorted[minElementIndex].CompareTo(sorted[j]) > 0)
                    {
                        minElementIndex = j;
                    }
                }

                T temp = sorted[i];
                sorted[i] = sorted[minElementIndex];
                sorted[minElementIndex] = temp;
            }

            return sorted;
        }

        public IList<T> InsertionSort<T>(IList<T> collection) where T : IComparable<T>
        {
            var sorted = new List<T>(collection);

            for (int i = 1; i < sorted.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (sorted[j].CompareTo(sorted[j - 1]) >= 0)
                    {
                        break;
                    }

                    T temp = sorted[j-1];
                    sorted[j - 1] = sorted[j];
                    sorted[j] = temp;
                }
            }

            return sorted;
        }

        public IList<T> QuickSort<T>(IList<T> collection, T start, T end) where T: IComparable<T>
        {
            if (start.CompareTo(end) >= 0)
            {
                return collection;
            }
        }
    }
}
