using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _9GagNumbers
{
    class Program
    {
        static string[] numericSystem = { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            number = Digits(number);
            Console.WriteLine(ConvertToDec(number));
        }


        static string ConvertToNine(string number)
        {
            for (int i = numericSystem.Length - 1; i >= 0; i--)
            {
                number = number.Replace(numericSystem[i], i.ToString());
            }

            return number;
        }

        static BigInteger ConvertToDec(string number)
        {
            BigInteger result = 0;
            for (int i = 0; i < number.Length; i++)
            {
                result = result * 9 + number[i] - '0';
            }

            return result;
        }

        static string Digits(string number)
        {
            var builder = new StringBuilder();
            var numberInNine = new StringBuilder();
            int digit = 0;
            for (int i = 0; i < number.Length; i++)
            {
                builder.Append(number[i]);

                if (int.TryParse(ConvertToNine(builder.ToString()), out digit))
                {
                    numberInNine.Append(digit);
                    builder.Clear();
                }
            }

            return numberInNine.ToString();
        }
    }
}
