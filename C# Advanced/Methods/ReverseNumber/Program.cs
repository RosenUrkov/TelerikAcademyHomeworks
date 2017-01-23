using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            char[] reverse = ReverseDigits(number);
            Console.WriteLine(reverse);
        }

        static char[] ReverseDigits(string number)
        {
            char[] reverseNumber = number.ToCharArray();
            for (int index = 0; index < number.Length / 2; index++)
            {
                char temp = reverseNumber[index];
                reverseNumber[index] = reverseNumber[reverseNumber.Length - 1 - index];
                reverseNumber[reverseNumber.Length - 1 - index] = temp;
            }
            return reverseNumber;
        }
    }
}
