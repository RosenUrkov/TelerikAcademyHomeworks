using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersArray = Console.ReadLine().Split(new char[] { ' ', ',', '.' }, StringSplitOptions
                .RemoveEmptyEntries).Select(int.Parse).ToList<int>();

            numbersArray = Quicksort(numbersArray);
            PrintArray(numbersArray);

            int[] sortedNumbersArray = numbersArray.ToArray();
            int numberToSearch = int.Parse(Console.ReadLine());
            int targetIndex = BinarySearch(sortedNumbersArray, numberToSearch,0,sortedNumbersArray.Length-1);
            Console.WriteLine(targetIndex);            

        }

        static List<int> Quicksort(List<int> unsortedList)
        {
            if (unsortedList.Count <= 1)
            {
                return unsortedList;
            }

            int indexOfPivot = unsortedList.Count / 2;
            int pivot = unsortedList[indexOfPivot];

            List<int> leftSide = new List<int>();
            List<int> rightSide = new List<int>();

            for (int index = 0; index < unsortedList.Count; index++)
            {
                if (index != indexOfPivot)
                {
                    if (unsortedList[index] < pivot)
                    {
                        leftSide.Add(unsortedList[index]);
                    }
                    else
                    {
                        rightSide.Add(unsortedList[index]);
                    }
                }
            }

            leftSide = Quicksort(leftSide);
            rightSide = Quicksort(rightSide);

            leftSide.Add(pivot);
            leftSide.AddRange(rightSide);

            return leftSide;
        }

        static void PrintArray(List<int> array)
        {
            foreach (int number in array)
            {
                Console.Write("{0} ",number);
            }
            Console.WriteLine();
        }

        static int BinarySearch(int[] sortedArray,int target, int startIndex, int endIndex)
        {
            if(startIndex>endIndex)
            {
                return startIndex-1;
            }
           
            int pivot = startIndex + (endIndex - startIndex) / 2;
            if (sortedArray[pivot] == target)
            {
                return pivot;
            }
            else if (sortedArray[pivot]>target)
            {
                return BinarySearch(sortedArray, target, startIndex, pivot - 1);
            }
            else
            {
                return BinarySearch(sortedArray, target, pivot + 1, endIndex);
            }

            
        }
    }
}
