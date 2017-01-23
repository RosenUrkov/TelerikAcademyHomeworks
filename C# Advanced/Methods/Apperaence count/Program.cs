using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apperaence_count
{
    class Program
    {
        static void Main(string[] args)
        {
            //int size = int.Parse(Console.ReadLine());
            //int[] numbersArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //int target = int.Parse(Console.ReadLine());
            //int count = NumberCountInCollection(numbersArray, target);
            //Console.WriteLine(count);

            int[][] jagged = new int[3][];
            jagged[0] =new int[] { 1, 2, 2 ,5 ,3, 2 };
            jagged[1] = new int[] { 5, 2, 1, 5, 3, 7 };
            jagged[2] = new int[] { 4, 2, 2, 5, 3, 2 };

            int[] targets = { 2, 5, 4 };
            for (int index = 0; index < jagged.Length; index++)
            {
                Console.WriteLine(NumberCountInCollection(jagged[index],targets[index]));
            }

        }

        static int NumberCountInCollection(int[] array,int target)
        {
            int counter = 0;
            for (int index = 0; index < array.Length; index++)
            {
                if(array[index]==target)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
