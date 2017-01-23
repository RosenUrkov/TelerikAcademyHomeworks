using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string word = LastDigitAsWord(number);
            Console.WriteLine(word);
        }

        static string LastDigitAsWord(int number)
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            int digit = number % 10;
            string word = string.Empty;
            for (int index = 0; index < digits.Length; index++)
            {
                if (index == digit)
                {
                    word = digits[index];
                    break;
                }
            }
            return word;
        }
    }
}
