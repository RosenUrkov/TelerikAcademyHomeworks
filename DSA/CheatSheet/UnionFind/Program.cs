using System;
using System.Linq;

namespace UnionFindStructure
{
    public class UnionFind
    {
        static int[] array;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            array = Enumerable.Repeat(-1, n).ToArray();
        }             

        static bool Union(int x, int y)
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

        static int Find(int x)
        {
            if (array[x] < 0)
            {
                return x;
            }

            array[x] = Find(array[x]);
            return array[x];
        }
    }
}