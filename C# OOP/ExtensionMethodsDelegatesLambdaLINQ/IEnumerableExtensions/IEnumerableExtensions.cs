namespace IEnumerableExtensions
{
    using System;
    using System.Collections;
    public static class IEnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable collection)
        {
            T sum = (T)Convert.ChangeType(0, typeof(T));
            foreach (var item in collection)
            {
                sum += (dynamic)Convert.ChangeType(item, typeof(T));
            }
            return sum;
        }

        public static T Product<T>(this IEnumerable collection)
        {
            T product = (T)Convert.ChangeType(1, typeof(T));
            foreach (var item in collection)
            {
                product *= (dynamic)Convert.ChangeType(item, typeof(T));
            }
            return product;
        }

        public static T Min<T>(this IEnumerable collection) where T:IComparable
        {
            bool isFirst = true;
            T minElement = (T)Convert.ChangeType(0,typeof(T));
            foreach (var item in collection)
            {
                if (isFirst)
                {
                    isFirst = false;
                    minElement = (T)Convert.ChangeType(item, typeof(T));
                }
                else
                {
                    if (minElement.CompareTo(item)>0)
                    {
                        minElement = (T)item;
                    }
                }
            }

            return minElement;
        }

        public static T Max<T>(this IEnumerable collection) where T : IComparable
        {
            bool isFirst = true;
            T maxElement = (T)Convert.ChangeType(0, typeof(T));
            foreach (var item in collection)
            {
                if (isFirst)
                {
                    isFirst = false;
                    maxElement = (T)Convert.ChangeType(item, typeof(T));
                }
                else
                {
                    if (maxElement.CompareTo(item) < 0)
                    {
                        maxElement = (T)item;
                    }
                }
            }

            return maxElement;
        }

        public static double Average<T>(this IEnumerable collection)
        {
            T result = collection.Sum<T>();
            int del = 0;
            foreach (var item in collection)
            {
                del++;
            }
            return (double)Convert.ChangeType(result,typeof(double)) / del;
        }
    }
}
