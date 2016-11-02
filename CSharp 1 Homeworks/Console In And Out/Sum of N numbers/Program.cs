using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_of_N_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 0; i < number; i++)
            {
                sum += double.Parse(Console.ReadLine());


            }
            Console.WriteLine(sum);
        }
    }
}
