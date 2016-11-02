using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            string fourDigit = Console.ReadLine();
            int one = fourDigit[0] - '0';
            int two = fourDigit[1] - '0';
            int three = fourDigit[2] - '0';
            int four = fourDigit[3] - '0';
            int sum = one + two + three + four;
            Console.WriteLine("{0}",sum);
            Console.WriteLine("{0}{1}{2}{3}",four, three, two, one);
            Console.WriteLine("{0}{1}{2}{3}",four, one, two, three);
            Console.WriteLine("{0}{1}{2}{3}",one, three, two, four);

        }
    }
}
