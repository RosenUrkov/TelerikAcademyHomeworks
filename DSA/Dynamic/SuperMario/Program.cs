using System;
using System.Linq;

namespace SuperMario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var keyNumbers = Console.ReadLine().Split(' ');

            int n = int.Parse(keyNumbers[0]);
            int k = int.Parse(keyNumbers[1]);

            var costGenerators = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var dynamicArr = new long[k];
            dynamicArr[0] = costGenerators[0];

            var isFirst = true;
            for (int j = 0; j < n / k; j++)
            {
                for (int i = 0; i < dynamicArr.Length; i++)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        continue;
                    }

                    var min = dynamicArr.Min();

                    if (i == 0)
                    {
                        dynamicArr[i] = ((dynamicArr[k - 1] * costGenerators[1] + costGenerators[2]) % costGenerators[3]) + min;
                    }
                    else
                    {
                        dynamicArr[i] = (((dynamicArr[i - 1] - min) * costGenerators[1] + costGenerators[2]) % costGenerators[3]) + min;
                    }
                }
            }

            Console.WriteLine(dynamicArr[0]);
        }
    }
}
