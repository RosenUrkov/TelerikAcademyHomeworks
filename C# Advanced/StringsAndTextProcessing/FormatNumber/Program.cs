using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            char[] formats = { 'D', 'X', 'P', 'E', 'C' };

            Console.WriteLine("{0:D}", number);
            Console.WriteLine("{0:X}", number);
            Console.WriteLine("{0:P}", number);
            Console.WriteLine("{0:E}", number);
            Console.WriteLine("{0:C}", number);

        }
    }
}
