using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            for (int i = 2; i < 12; i++)
            {
                if (i % 2 == 0)
                {
                    a = i;
                }
                else
                {
                    a = i*-1;
                }
                Console.WriteLine(a);

            }
        }
    }
}
