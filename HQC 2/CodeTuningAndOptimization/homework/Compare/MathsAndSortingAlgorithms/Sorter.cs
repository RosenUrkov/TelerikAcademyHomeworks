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

                    T temp = sorted[j - 1];
                    sorted[j - 1] = sorted[j];
                    sorted[j] = temp;
                }
            }

            return sorted;
        }

        public void QuickSort<T>(IList<T> collection, int startIndex, int endIndex) where T : IComparable<T>
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            T pivot = collection[endIndex];
            int currentIndex = startIndex - 1;
            
            // iterate over the collection and if the current element
            // is smaller than the pivot place it in the left side of
            // the array, so the bigger elements are on the right side
            T temp;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    currentIndex++;

                    temp = collection[currentIndex];
                    collection[currentIndex] = collection[i];
                    collection[i] = temp;
                }
            }

            // final swap to ensure that the pivot is placed in the
            // middle between smaller and bigger than hem elements
            temp = collection[currentIndex + 1];
            collection[currentIndex + 1] = collection[endIndex];
            collection[endIndex] = temp;
            
            QuickSort(collection, startIndex, currentIndex);
            QuickSort(collection, currentIndex + 2, endIndex);
        }
    }
}
