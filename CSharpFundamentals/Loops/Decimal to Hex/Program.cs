using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decimal_to_Hex
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            char currentHexChar;
            //bool endOfNumber = false;
            string hexadecimalFormat = string.Empty;
            while (true)
            {


                currentHexChar = (char)(number % 16);





                switch (currentHexChar)
                {

                    case (char)0: currentHexChar = '0'; break;
                    case (char)1: currentHexChar = '1'; break;
                    case (char)2: currentHexChar = '2'; break;
                    case (char)3: currentHexChar = '3'; break;
                    case (char)4: currentHexChar = '4'; break;
                    case (char)5: currentHexChar = '5'; break;
                    case (char)6: currentHexChar = '6'; break;
                    case (char)7: currentHexChar = '7'; break;
                    case (char)8: currentHexChar = '8'; break;
                    case (char)9: currentHexChar = '9'; break;
                    case (char)10: currentHexChar = 'A'; break;
                    case (char)11: currentHexChar = 'B'; break;
                    case (char)12: currentHexChar = 'C'; break;
                    case (char)13: currentHexChar = 'D'; break;
                    case (char)14: currentHexChar = 'E'; break;
                    case (char)15: currentHexChar = 'F'; break;

                }
                hexadecimalFormat = currentHexChar + hexadecimalFormat;
                if (number / 16 == 0)
                {
                    break;
                }
                number /= 16;



            }
            Console.WriteLine(hexadecimalFormat);
        }
    }
}
