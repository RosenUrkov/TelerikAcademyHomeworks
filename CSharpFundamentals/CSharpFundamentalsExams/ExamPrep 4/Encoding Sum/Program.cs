using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoding_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            double result = 0;

            for (int i = 0;; i++)
            {
                if (text[i] == '@')
                {
                    break;
                }
                else if (text[i] >= 'a' && text[i] <= 'z')
                {
                    result += text[i] - 'a';
                }
                else if (text[i] >= 'A' && text[i] <= 'Z')
                {
                    result += text[i] - 'A';
                }
                else if (text[i] >= '0' && text[i] <= '9')
                {
                    result *= text[i]-'0';
                }
                else
                {
                    result %= number;
                }


            }
            Console.WriteLine(result);

        }
    }
}
