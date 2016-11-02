using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int decider = 0;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if(number%i==0)
                {
                    decider = 1;
                    break;

                }

            }
            if((decider == 1)||(number<2))
            {
                Console.WriteLine("false");
            }
            else
            {
                Console.WriteLine("true");
            }
        }
    }
}
