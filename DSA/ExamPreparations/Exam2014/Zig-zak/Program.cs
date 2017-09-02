using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zig_zak
{
    public class Program
    {
        static int result = 0;
        static bool[] used;

        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');

            var n = int.Parse(input[0]);
            var k = int.Parse(input[1]);

            used = new bool[n];

            Recurison(n, k, 0, true, -1, 0, n);
            Console.WriteLine(result);
        }

        public static void Recurison(int n, int k, int currentCombinationLength, bool isEvenPosition, int perv, int startIndex, int endIndex)
        {
            if (currentCombinationLength == k)
            {
                result++;
                return;
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                if (used[i] ||
                    ((isEvenPosition && perv > i) ||
                    (!isEvenPosition && perv < i)))
                {
                    continue;
                }

                int newStartIndex = 0;
                int newEndIndex = 0;
                
                if (isEvenPosition)
                {
                    newStartIndex = 0;
                    newEndIndex = i;
                }
                else
                {
                    newStartIndex = i + 1;
                    newEndIndex = n;
                }

                used[i] = true;
                Recurison(n, k, currentCombinationLength + 1, !isEvenPosition, i, newStartIndex, newEndIndex);
                used[i] = false;
            }
        }
    }
}
