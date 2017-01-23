using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if((number&1)==1)
            {
                Console.WriteLine("odd {0}",number);
            }
            else
            {
                Console.WriteLine("even {0}",number);
            }
        }
    }
}
