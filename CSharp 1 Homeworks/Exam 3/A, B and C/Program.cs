using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A__B_and_C
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double thirdNumber = double.Parse(Console.ReadLine());
            double bigestNumber = double.MinValue;
            double smallestNumber = double.MaxValue;
            double aritmeticSum = 0;

            double[] numbers = { firstNumber, secondNumber, thirdNumber };
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > bigestNumber)
                {
                    bigestNumber = numbers[i];
                }
                if (numbers[i] < smallestNumber)
                {
                    smallestNumber = numbers[i];
                }
            }
            aritmeticSum = (firstNumber + secondNumber + thirdNumber) / 3;

            Console.WriteLine("{0}\r\n{1}\r\n{2:f3}", bigestNumber, smallestNumber, aritmeticSum);




        }
    }
}
