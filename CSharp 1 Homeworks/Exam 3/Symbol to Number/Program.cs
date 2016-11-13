using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbol_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int cripter = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            double criptedChar = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '@')
                {
                    break;
                }
                else if ((text[i] >= 'a' && text[i] <= 'z') || (text[i] >= 'A' && text[i] <= 'Z'))
                {
                    criptedChar = (text[i] * cripter + 1000);

                }
                else if (text[i] >= '0' && text[i] <= '9')
                {
                    criptedChar = (text[i] + 500 + cripter);
                }
                else
                {
                    criptedChar = text[i] - cripter;
                }


                if ((i & 1) == 1)
                {
                    criptedChar *= 100;
                    Console.WriteLine(criptedChar);
                }
                else
                {
                    criptedChar /= 100;
                    Console.WriteLine("{0:f2}", criptedChar);
                }


            }

        }
    }
}
