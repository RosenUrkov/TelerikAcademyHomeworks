using System;

namespace UnionFindStructure
{
    public class UnionFind
    {
        private int[] array;

        public UnionFind(int n)
        {
            array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = -1;
            }
        }

        public int FindIterative(int x)
        {
            while (array[x] >= 0)
            {
                x = array[x];
            }
            return x;
        }

        public int Find(int x)
        {
            //return array[x] < 0 ? x : array[x] = Find(array[x]);
            if (array[x] < 0)
            {
                return x;
            }
            array[x] = Find(array[x]);
            return array[x];
        }

        public bool InTheSameSet(int x, int y)
        {
            return Find(x) == Find(y);
        }

        public bool Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y)
            {
                return false;
            }
            array[x] = y;
            return true;
        }

        public void Print()
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}