using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {

                numbers[i] = (int.Parse(input[i]));

            }
            while (numbers[1] != 0)
            {
                var c = numbers[1];
                numbers[1] = numbers[0] % numbers[1];
                numbers[0] = c;

            }
            Console.WriteLine(numbers[0]);

        }
    }
}
