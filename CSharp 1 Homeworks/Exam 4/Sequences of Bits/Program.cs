using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequences_of_Bits
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfNumbers = int.Parse(Console.ReadLine());
            string numbersCollection = string.Empty;
            ulong mask = (1 << 30) - 1;

            int zerosCounter = 0;
            int onesCounter = 0;

            int mostZeros = 0;
            int mostOnes = 0;


            for (int i = 0; i < countOfNumbers; i++)
            {
                ulong currentNumber = uint.Parse(Console.ReadLine());
                ulong first30Bits = currentNumber & mask;
                numbersCollection += (Convert.ToString((int)first30Bits, 2).PadLeft(30, '0'));

            }

            //Console.WriteLine(numbersCollection);

            for (int i = 0; i < numbersCollection.Length; i++)
            {
                if (numbersCollection[i] == '0')
                {
                    if (onesCounter > mostOnes)
                    {
                        mostOnes = onesCounter;
                    }
                    zerosCounter++;
                    onesCounter = 0;
                }
                else if (numbersCollection[i] == '1')
                {
                    if (zerosCounter > mostZeros)
                    {
                        mostZeros = zerosCounter;
                    }
                    onesCounter++;
                    zerosCounter = 0;
                }

            }

            if (zerosCounter > mostZeros)
            {
                mostZeros = zerosCounter;
            }
            if (onesCounter > mostOnes)
            {
                mostOnes = onesCounter;
            }

            Console.WriteLine("{0}\r\n{1}", mostOnes, mostZeros);
        }
    }
}
