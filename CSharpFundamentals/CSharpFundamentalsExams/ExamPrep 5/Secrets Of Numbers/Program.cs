using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Secrets_Of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            if (number[0] == '-')
            {
                number = number.Substring(1);
            }

            string reverseNumber = string.Empty;
            ulong secretNumber = 0;
            ulong alphaSequenceDigits = 0;

            for (int i = 0; i < number.Length; i++)
            {
                reverseNumber += number[number.Length - 1 - i];
            }

            for (int i = 1; i <= reverseNumber.Length; i++)
            {
                if ((i & 1) == 1)
                {
                    secretNumber += (ulong)(i * i * (reverseNumber[i - 1] - '0'));
                }
                else
                {
                    secretNumber += (ulong)(i * (reverseNumber[i - 1] - '0') * (reverseNumber[i - 1] - '0'));
                }
            }
            alphaSequenceDigits = (secretNumber % 10);
            ulong alphaSequence = (secretNumber % 26) + 65;

            if (alphaSequenceDigits == 0)
            {
                Console.Write("{0}\r\n{1} has no secret alpha-sequence", secretNumber, number);
            }
            else
            {
                Console.WriteLine(secretNumber);
                for (ulong i = 0; i < alphaSequenceDigits; i++)
                {
                    Console.Write("{0}", (char)(alphaSequence + i));
                    if ((char)(alphaSequence + i) == 'Z')
                    {
                        alphaSequence -= 26;
                    }
                }
            }
            Console.WriteLine();

        }
    }
}
