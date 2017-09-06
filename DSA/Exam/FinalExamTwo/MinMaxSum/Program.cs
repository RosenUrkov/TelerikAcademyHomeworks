using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxSum
{
    class Program
    {
        static int groups = 0;
        static int[] numbers;
        static int[][] current;
        static int sum = int.MaxValue;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                groups = int.Parse(Console.ReadLine().Split(' ')[1]);
                numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                current = new int[groups][];

                Recursion(0, 0);
                Console.WriteLine(sum);
            }
        }

        static void Recursion(int index, int currGroup)
        {
            current[currGroup] = new int[numbers.Length];

            if (currGroup + 1 == groups)
            {
                for (int i = index; i < numbers.Length; i++)
                {
                    current[currGroup][i] = numbers[i];
                }

                var localSum = int.MinValue;
                for (int i = 0; i < current.Length; i++)
                {
                    var currSum = current[i].Sum();
                    if(currSum > localSum)
                    {
                        localSum = currSum;
                    }
                }

                if(localSum < sum)
                {
                    sum = localSum;
                }

                return;
            }

            for (int i = index; i < numbers.Length - groups + 1; i++)
            {
                current[currGroup][i] = numbers[i];
                Recursion(i + 1, currGroup + 1);
            }
        }
    }
}
