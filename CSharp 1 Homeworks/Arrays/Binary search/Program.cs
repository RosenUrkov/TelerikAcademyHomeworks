using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_search
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfArray = int.Parse(Console.ReadLine());
            List<int> sortedList = new List<int>();

            for (int i = 0; i < sizeOfArray; i++)
            {
                sortedList.Add(int.Parse(Console.ReadLine()));
            }
            sortedList.Sort();


            int numberForSearch = int.Parse(Console.ReadLine());
            int lowIndex = 0;
            int highIndex = sizeOfArray - 1;
            int midpoint = (lowIndex + highIndex) / 2;
            bool isCorrect = false;

            for (int i = 0; i < sizeOfArray / 4; i++)
            {
                if (sortedList[midpoint] == numberForSearch)
                {
                    isCorrect = true;
                    break;
                }
                else if (sortedList[midpoint] > numberForSearch)
                {
                    highIndex = midpoint - 1;
                    midpoint = (lowIndex + highIndex) / 2;
                }
                else if (sortedList[midpoint] < numberForSearch)
                {
                    lowIndex = midpoint + 1;
                    midpoint = (lowIndex + highIndex) / 2;
                }
            }
            if (isCorrect)
            {


                Console.WriteLine(midpoint);
            }
            else
            {
                Console.WriteLine("-1");
            }
        }
    }
}
