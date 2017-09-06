using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CokiSkoki
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var result = new int[n];

            var max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                var current = numbers[i];
                for (int j = i + 1; j < n; j++)
                {
                    if(numbers[j] > current)
                    {
                        current = numbers[j];
                        result[i]++;
                    }
                }

                if (result[i] > max)
                {
                    max = result[i];
                }
            }

            Console.WriteLine(max);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
