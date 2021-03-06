﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SecretNumeralSystem
{
    class Program
    {
        static string[] numeralSystem = { "hristo", "tosho", "pesho", "hristofor", "vlad", "haralampi", "zoro", "vladimir" };
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(new char[] { ' ', ',' },StringSplitOptions.RemoveEmptyEntries).ToArray();
            BigInteger result = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                result *= Decoder(numbers[i]);
            }

            Console.WriteLine(result);
        }

        static BigInteger Decoder(string number)
        {
            for (int i = numeralSystem.Length-1; i >=0; i--)
            {
                number = number.Replace(numeralSystem[i], i.ToString());
            }

            BigInteger result = ConvertToDec(number);
            return result;

        }

        static BigInteger ConvertToDec(string number)
        {
            BigInteger result = 0;
            for (int i = 0; i < number.Length; i++)
            {
                result = result * 8 + number[i] - '0';
            }
            return result;
        }

    }
}
