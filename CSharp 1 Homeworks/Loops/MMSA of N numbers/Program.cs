using System;
using System.Globalization;
using System.Threading;

namespace MMSA_of_N_numbers
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            long number = long.Parse(Console.ReadLine());
            double minNumber = 0;
            double maxNumber = 0;
            double sum = 0;
            double currentNumber = 0;
            double averageNumber = 0;
            for (int i = 0; i < number; i++)
            {
                currentNumber = double.Parse(Console.ReadLine());
                if (i == 0)
                {
                    minNumber = currentNumber;
                    maxNumber = currentNumber;
                }
                if (currentNumber > maxNumber)
                {
                    maxNumber = currentNumber;
                }
                if (currentNumber < minNumber)
                {
                    minNumber = currentNumber;
                }

                sum += currentNumber;


            }
            averageNumber = sum / number;
            Console.WriteLine("min={0:f2}\r\nmax={1:f2}\r\nsum={2:f2}\r\navg={3:f2}", minNumber, maxNumber, sum, averageNumber);
        }
    }
}
