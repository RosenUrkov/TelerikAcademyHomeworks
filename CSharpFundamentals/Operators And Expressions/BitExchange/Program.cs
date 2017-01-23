using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14
{
    class Program
    {
        static void Main(string[] args)
        {
            uint number = uint.Parse(Console.ReadLine());
            uint closeMask = (number & (7 << 3));
            uint closeBits = closeMask >> 3;
            uint farMask = (number & (7 << 24));
            uint farBits = farMask >> 24;
            number = (number & (~closeMask));
            number = (number & (~farMask));
            number = (number | (farBits << 3));
            number = (number | (closeBits << 24));
            Console.WriteLine(number);



        }
    }
}
