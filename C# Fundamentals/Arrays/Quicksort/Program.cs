using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    class Program
    {
        static List<int> QuickSort(List<int> numbers)
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }
            int pivotIndex = numbers.Count / 2;
            int pivot = numbers[pivotIndex];

            var left = new List<int>();
            var right = new List<int>();

            for(int i = 0; i < numbers.Count; i++)
            {
                if (i != pivotIndex)
                {
                    if (numbers[i] < pivot)
                    {
                        left.Add(numbers[i]);
                    }
                    else
                    {
                        right.Add(numbers[i]);
                    }
                }
            }


            left = QuickSort(left);
            right = QuickSort(right);

            left.Add(pivot);
            left.AddRange(right);



            return left;


        }
        static void Main(string[] args)
        {

            List<int> numbers = new List<int>();

            for (int i = 200; i >= 0; i--)
            {
                numbers.Add(i);
            }
        }
    }
}
