using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<int> listOfNumbers = new List<int>();

            int mostRepeatedNumber = 0;
            int currentNumber = 0;

            int maxRepeats = 0;
            int currentRepeats = 0;

            bool isFirst = true;


            for (int i = 0; i < number; i++)
            {
                listOfNumbers.Add(int.Parse(Console.ReadLine()));
            }

            listOfNumbers.Sort();


            for (int i = 0; i < number; i++)
            {

                if (isFirst)
                {
                    isFirst = false;
                    currentNumber = listOfNumbers[i];
                    currentRepeats++;
                    maxRepeats = currentRepeats;
                    mostRepeatedNumber = currentNumber;
                }
                else if (currentNumber == listOfNumbers[i])
                {
                    currentRepeats++;
                }
                else if (currentNumber != listOfNumbers[i])
                {
                    if (currentRepeats > maxRepeats)
                    {
                        maxRepeats = currentRepeats;
                        mostRepeatedNumber = currentNumber;
                    }
                    currentNumber = listOfNumbers[i];
                    currentRepeats = 1;
                }
                if (i == number - 1)
                {
                    if (currentRepeats > maxRepeats)
                    {
                        maxRepeats = currentRepeats;
                        mostRepeatedNumber = currentNumber;
                    }
                }

            }
            Console.WriteLine("{0} ({1} times)", mostRepeatedNumber, maxRepeats);
        }
    }
}
