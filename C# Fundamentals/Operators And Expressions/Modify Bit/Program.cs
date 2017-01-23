using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13
{
    class Program
    {
        static void Main(string[] args)
        {



            ulong number = ulong.Parse(Console.ReadLine());
            int bitPosition = int.Parse(Console.ReadLine());
            ulong bitValue = ulong.Parse(Console.ReadLine());
            ulong mask = ((ulong)1 << bitPosition);
            if (bitValue == 1)
            {
                Console.WriteLine(number | mask);
            }
            else
            {
                Console.WriteLine(number & (~(mask)));


            }

        }
    }
}
