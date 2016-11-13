using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfEvenDivisors
{
    class Program
    {
        static void Main(string[] args)
        {
            int startOfLine = int.Parse(Console.ReadLine());
            int endOfLine = int.Parse(Console.ReadLine());
            ulong sum = 0;
            if (startOfLine > endOfLine)
            {
                int temp = startOfLine;
                startOfLine = endOfLine;
                endOfLine = temp;
            }
            if ((startOfLine & 1) == 1)
            {
                startOfLine++;
            }
            for (int i = startOfLine; i <= endOfLine; i+=2)
            {
                for (int j = 2; j <= i; j+=2)
                {


                    if (i % j == 0)
                    {
                        sum += (ulong)j;
                    }
                }

            }
            Console.WriteLine(sum);

        }
    }
}
