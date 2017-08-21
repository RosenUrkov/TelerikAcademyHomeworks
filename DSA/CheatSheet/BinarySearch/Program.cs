using System;
using System.Collections.Generic;

namespace Searching
{
    static class BinarySearch
    {
        public static int BinarySearchFindWhateverIterative<T>(this T[] array, T value)
            where T : IComparable<T>
        {
            //return array.BinarySearchFindWhatever(value, 0, array.Length);

            int left = 0;
            int right = array.Length;

            while (left < right)
            {
                int middle = (left + right) / 2;
                int cmp = array[middle].CompareTo(value);
                if (cmp < 0)
                {
                    left = middle + 1;
                }
                else if (cmp > 0)
                {
                    right = middle;
                }
                else
                {
                    return middle;
                }
            }

            return -1;
        }

        public static int LowerBound<T>(this T[] array, T value)
            where T : IComparable<T>
        {
            return array.Bound(mid => mid.CompareTo(value) < 0);
        }

        public static int UpperBound<T>(this T[] array, T value)
            where T : IComparable<T>
        {
            return array.Bound(mid => mid.CompareTo(value) <= 0);
        }

        private static int Bound<T>(this T[] array, Func<T, bool> f)
        {
            int left = 0;
            int right = array.Length;

            while (left < right)
            {
                int middle = (left + right) / 2;
                //if (array[middle].CompareTo(value) < 0)
                if (f(array[middle]))
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }

        public static int BinarySearchFindWhateverRecursive<T>(this T[] array, T value)
            where T : IComparable<T>
        {
            return array.BinarySearchFindWhateverRecursive(value, 0, array.Length);

        }

        private static int BinarySearchFindWhateverRecursive<T>(this T[] array, T value, int left, int right)
            where T : IComparable<T>
        {
            if (left >= right)
            {
                return -1;
            }

            int middle = (left + right) / 2;
            int cmp = array[middle].CompareTo(value);
            if (cmp < 0)
            {
                return array.BinarySearchFindWhateverRecursive(value, middle + 1, right);
            }
            if (cmp > 0)
            {
                return array.BinarySearchFindWhateverRecursive(value, left, middle);
            }
            return middle;
        }

        public static void BinarySearchSort<T>(this T[] array)
            where T : IComparable<T>
        {
            var sorted = new List<T>();

            foreach (var value in array)
            {
                int index = sorted.ToArray().UpperBound(value);
                sorted.Insert(index, value);
            }

            sorted.CopyTo(array);
        }
    }
}