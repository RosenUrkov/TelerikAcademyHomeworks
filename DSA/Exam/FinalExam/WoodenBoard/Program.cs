using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodenBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var resultFront = 0;
            var resultBack = 0;

            var i = input.Length - 1;
            var j = 0;
            while (j != i && j < input.Length && i >= 0)
            {
                if (input[j] != input[i])
                {
                    resultFront++;
                    i--;
                }
                else
                {
                    j++;
                    i--;
                }
            }

            i = input.Length - 1;
            j = 0;
            while (j != i && j < input.Length && i >= 0)
            {
                if (input[j] != input[i])
                {
                    resultBack++;
                    j++;
                }
                else
                {
                    j++;
                    i--;
                }
            }

            Console.WriteLine(Math.Min(resultFront, resultBack));
        }
    }
}
