using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargerThanNeighbours
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] numbersArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int count = BiggerThanNeighbours(numbersArray);
            Console.WriteLine(count);

        }

        static int BiggerThanNeighbours(int[] array)
        {
            int counter = 0;
            for (int index = 1; index < array.Length - 1; index++)
            {
                if (array[index] > array[index - 1] && array[index] > array[index + 1])
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
