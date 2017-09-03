using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerology
{
    class Program
    {
        static int[] result = new int[10];

        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Recursion(input);
            Console.WriteLine(string.Join(" ", result));
        }

        static void Recursion(string current)
        {
            if (current.Length == 1)
            {
                result[current[0] - '0']++;
                return;
            }

            for (int i = 1; i < current.Length; i++)
            {
                var a = current[i - 1] - '0';
                var b = current[i] - '0';

                var result = (a + b) * (a ^ b) % 10;

                if (i + 1 == current.Length)
                {
                    Recursion(current.Substring(0, i - 1) + result);
                    continue;
                }

                var newStr = current.Substring(0, i - 1) + result + current.Substring(i + 1);
                Recursion(newStr);
            }
        }
    }
}
