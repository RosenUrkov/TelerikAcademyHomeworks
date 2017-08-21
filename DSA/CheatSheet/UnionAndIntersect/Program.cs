namespace UnionAndIntersection
{
    using System;
    using System.Collections.Generic;

    public static class UnionIntersect
    {    
        private static List<int> Union(int[] firstArray, int[] secondArray)
        {
            List<int> union = new List<int>();

            union.AddRange(firstArray);

            foreach (int item in secondArray)
            {
                if (!union.Contains(item))
                {
                    union.Add(item);
                }
            }

            return union;
        }

        private static List<int> Intersect(int[] firstArray, int[] secondArray)
        {
            List<int> intersect = new List<int>();

            foreach (int item in firstArray)
            {
                if (Array.IndexOf(secondArray, item) != -1)
                {
                    intersect.Add(item);
                }
            }

            return intersect;
        }       
    }
}