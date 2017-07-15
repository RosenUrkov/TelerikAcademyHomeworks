using System;

namespace PriorityQueue
{
    public static class HeapSorter
    {
        public static void HeapSort<T>(this T[] array)
            where T : IComparable<T>
        {
            array.HeapSort((x, y) => x.CompareTo(y) > 0);
        }

        public static void HeapSort<T>(this T[] array, Func<T, T, bool> compare)
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                array.HeapifyDown(compare, i, array[i], array.Length);
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                var value = array[i];
                array[i] = array[0];
                array.HeapifyDown(compare, 0, value, i);
            }
        }
        private static void HeapifyDown<T>(this T[] heap, Func<T, T, bool> compare, int index, T value, int length)
        {
            while (index * 2 + 2 < length)
            {
                int childIndex = compare(heap[index * 2 + 1], heap[index * 2 + 2])
                    ? index * 2 + 1
                    : index * 2 + 2;

                if (compare(value, heap[childIndex]))
                {
                    break;
                }

                heap[index] = heap[childIndex];
                index = childIndex;
            }

            if (index * 2 + 1 < length)
            {
                int childIndex = index * 2 + 1;
                if (compare(heap[childIndex], value))
                {
                    heap[index] = heap[childIndex];
                    index = childIndex;
                }
            }

            heap[index] = value;
        }
    }
}