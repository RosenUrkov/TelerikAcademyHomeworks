using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CalculationProblem
{
    class Program
    {
        static string[] numericSystem = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w" };
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ').ToArray();
            BigInteger sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += Decode(numbers[i]);             
                
            }

            string result = Encode(sum);
            Console.WriteLine("{0} = {1}", result, sum);

        }

        static BigInteger Decode(string number)
        {
            char[] charNumber = number.ToCharArray();
            BigInteger result = 0;
            for (int i = 0; i < charNumber.Length; i++)
            {
                result = result*23 + charNumber[i] - 'a';
            }
            return result;
        }

        //static string Convert(string number)
        //{
        //    BigInteger result = 0;
        //    for (int i = 0; i < number.Length; i++)
        //    {
        //        result = result * 23 + number[i] - '0';
        //    }
        //    return result.ToString();
        //}

        static string Encode(BigInteger number)
        {
            string result = string.Empty;
            string convertToDec = string.Empty;
            

            while (number > 0)
            {
                int digit = (int)(number % 23);
                string digitString = numericSystem[digit].ToString();
                result = digitString + result;
                number = number / 23;               
            }
            return result;
        }
    }
}
