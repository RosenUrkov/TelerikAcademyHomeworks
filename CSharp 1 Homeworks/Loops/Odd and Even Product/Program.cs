using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_and_Even_Product
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] currentNumber = new int[number];
            string[] array = Console.ReadLine().Split(' ');
            long odd = 1;
            long even = 1;
            for (int i = 0; i < currentNumber.Length; i++)

            {
                currentNumber[i] = int.Parse(array[i]);
                if ((i & 1) == 1)
                {
                    even *= currentNumber[i];
                }
                else
                {
                    odd *= currentNumber[i];
                }
            }
            Console.WriteLine(odd == even ? "yes {0}" : "no {0} {1}", odd, even);
        }
    }
}
