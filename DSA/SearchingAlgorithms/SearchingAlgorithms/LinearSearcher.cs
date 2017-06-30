using System;

namespace SearchingAlgorithms
{
    public class LinearSearcher<T>
        where T: IComparable
    {
        public static int SearchIndex(T value, T[] collection)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if(collection[i].CompareTo(value) == 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
