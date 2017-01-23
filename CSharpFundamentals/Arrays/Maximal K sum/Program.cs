using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximal_K_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sumCount = int.Parse(Console.ReadLine());
            int[] arrayOfNumbers = new int[number];
            int sum = 0;

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                arrayOfNumbers[i] = int.Parse(Console.ReadLine());

             }
            Array.Sort(arrayOfNumbers);
            for (int i = 1; i <= sumCount; i++)
            {
                sum += arrayOfNumbers[arrayOfNumbers.Length - i];
            }
            Console.WriteLine(sum);

        }
    }
}
