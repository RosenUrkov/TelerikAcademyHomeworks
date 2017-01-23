using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());
            int division = N - K;
            System.Numerics.BigInteger sum1 = 1;
            System.Numerics.BigInteger sum2 = 1;
            do
            {
                sum1 *= N;
                N--;

            } while (!(N == K));
            while (division > 0)
            {
                sum2 *= division;
                division--;

            }
            Console.WriteLine(sum1 / sum2);
        }
    }
}
