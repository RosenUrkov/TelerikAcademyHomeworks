using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    Console.Write("{0} ",i+j);
                }
                Console.WriteLine();
            }
        }
    }
}
