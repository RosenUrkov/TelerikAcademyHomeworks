using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Messages
{
    class Program
    {
        static string[] numeralSystem = { "cad", "xoz", "nop", "cyk", "min", "mar", "kon", "iva", "ogi", "yan" };

        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            string operatorOnSystem = Console.ReadLine();
            string secondNumber = Console.ReadLine();
            firstNumber = Replace(firstNumber);
            secondNumber = Replace(secondNumber);
            BigInteger result = Operation(Decode(firstNumber), Decode(secondNumber), operatorOnSystem);
            Console.WriteLine(Encode(result));
        }

        static BigInteger Decode(string number)
        {
            BigInteger result = 0;
            for (int i = 0; i < number.Length; i++)
            {
                result = result * 10 + number[i] - '0';
            }
            return result;
        }

        static string Replace(string number)
        {
            for (int i = 0; i < numeralSystem.Length; i++)
            {
                number = number.Replace(numeralSystem[i], i.ToString());
            }

            return number;
        }

        static BigInteger Operation(BigInteger firstNumber, BigInteger secondNumber, string operation)
        {
            if (operation == "+")
            {
                return firstNumber + secondNumber;
            }
            else
            {
                return firstNumber - secondNumber;
            }
        }

        static string Encode(BigInteger number)
        {
            string result = number.ToString();
            for (int i = 0; i < numeralSystem.Length; i++)
            {
                result = result.Replace(i.ToString(), numeralSystem[i]);
            }
            return result;
        }
    }
}
