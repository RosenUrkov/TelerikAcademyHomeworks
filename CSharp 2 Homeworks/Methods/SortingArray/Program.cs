using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] numbersArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> listOfNumbers = numbersArray.ToList();

            listOfNumbers = Quicksort(listOfNumbers);
            Console.WriteLine(string.Join(" ", listOfNumbers));

        }

        static List<int> Quicksort(List<int> unsordedList)
        {
            if (unsordedList.Count <= 1)
            {
                return unsordedList;
            }

            int pivotIndex = unsordedList.Count / 2;
            int pivot = unsordedList[pivotIndex];
            List<int> leftSide = new List<int>();
            List<int> rightSide = new List<int>();

            for (int index = 0; index < unsordedList.Count; index++)
            {
                if (index == pivotIndex)
                {
                    continue;
                }
                if (unsordedList[index] < pivot)
                {
                    leftSide.Add(unsordedList[index]);
                }
                else
                {
                    rightSide.Add(unsordedList[index]);
                }

            }

            leftSide = Quicksort(leftSide);
            rightSide = Quicksort(rightSide);

            leftSide.Add(pivot);
            leftSide.AddRange(rightSide);
            return leftSide;
        }
    }
}
