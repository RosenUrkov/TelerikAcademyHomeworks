using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TRES4_Numbers
{
    class Program
    {
        static string[] numeralSystem = { "LON+", "VK-", "*ACAD", "^MIM", "ERIK|", "SEY&", "EMY>>", "/TEL", "<<DON" };

        static void Main()
        {
            string number = ConvertToNineBase(BigInteger.Parse(Console.ReadLine()));
            Console.WriteLine(number);

        }

        static string ConvertToNineBase(BigInteger number)
        {
            if (number == 0)
            {
                return numeralSystem[0];
            }

            StringBuilder result = new StringBuilder();
            while (number != 0)
            {
                result.Insert(0, numeralSystem[(int)(number % 9)]);
                number = number / 9;
            }

            return result.ToString();
        }


    }
}
