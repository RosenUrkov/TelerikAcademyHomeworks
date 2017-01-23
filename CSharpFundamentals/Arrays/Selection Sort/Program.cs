using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayLenght = int.Parse(Console.ReadLine());
            int[] unsortedArray = new int[arrayLenght];


            for (int i = 0; i < arrayLenght; i++)
            {
                unsortedArray[i] = int.Parse(Console.ReadLine());
            }


            for (int i = 0; i < arrayLenght; i++)
            {
                for (int j = i + 1; j < arrayLenght; j++)
                {
                    if (unsortedArray[i] > unsortedArray[j])
                    {
                        int temp = unsortedArray[i];
                        unsortedArray[i] = unsortedArray[j];
                        unsortedArray[j] = temp;
                    }

                }

            }


            for (int i = 0; i < arrayLenght; i++)
            {
                Console.WriteLine(unsortedArray[i]);
            }
        }
    }
}
