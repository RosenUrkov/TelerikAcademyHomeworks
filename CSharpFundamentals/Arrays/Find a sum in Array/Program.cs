using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_a_sum_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the size of the array:");
            int sizeOfTheArray = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the sum you want to check for:");
            int sum = int.Parse(Console.ReadLine());
            int currentSum = 0;
            int sumNumbersLenght = 0;
            int counter = 0;
            List<int> myNumbers = new List<int>();

            //filling the list
            Console.WriteLine("Please enter the numbers:");
            for (int i = 0; i < sizeOfTheArray; i++)
            {

                myNumbers.Add(int.Parse(Console.ReadLine()));
            }

            //finding existing sequence of numbers with correct sum
            while ((currentSum != sum) && ((counter + 1 != sizeOfTheArray) || (currentSum > sum)))
            {
                if (currentSum < sum)
                {
                    currentSum += myNumbers[counter];
                    sumNumbersLenght++;
                    counter++;
                }
                else if (currentSum > sum)
                {
                    currentSum -= myNumbers[counter - sumNumbersLenght];
                    sumNumbersLenght--;
                }

            }

            Console.WriteLine();

            //check the preformance
            if (currentSum == sum)
            {
                for (int i = sumNumbersLenght; i > 0; i--)
                {
                    Console.Write("{0} ", myNumbers[counter - i]);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("da go duhash, Bobka :)");
            }

        }
    }
}
