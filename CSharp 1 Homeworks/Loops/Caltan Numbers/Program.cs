using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caltan_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            System.Numerics.BigInteger sum1 = 1;
            System.Numerics.BigInteger sum2 = 1;
            int doubledNumber = 2 * number;
            int numberPlusOne = number + 1;
            do
            {
                sum1 *= doubledNumber;
                doubledNumber--;

            } while (!(number == doubledNumber));
            while(numberPlusOne>0)
            {
                sum2 *= numberPlusOne;
                numberPlusOne--;
            }
            Console.WriteLine(sum1/sum2);
        }
    }
}
