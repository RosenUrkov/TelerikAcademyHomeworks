using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyTasks
{
    public class Program
    {
        public static List<int> list;

        public static void Main(string[] args)
        {
            list = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var coef = int.Parse(Console.ReadLine());

            int minTaskValue = list[0];
            int maxTaskValue = list[0];

            int index = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < minTaskValue)
                {
                    minTaskValue = list[i];
                }
                if (list[i] > maxTaskValue)
                {
                    maxTaskValue = list[i];
                }

                if (maxTaskValue - minTaskValue >= coef)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine(list.Count);
            }

            int passedValue = list[index] == minTaskValue ? maxTaskValue : minTaskValue;
            Recursion(0, index, passedValue, false, 1);
        }

        public static void Recursion(int currentIndex, int index, int passedValue, bool isPassed, int result)
        {
            if (currentIndex > index)
            {
                return;
            }

            if (currentIndex == index)
            {
                if (!isPassed)
                {
                    return;
                }

                Console.WriteLine(result);
                Environment.Exit(0);
            }

            if (list[currentIndex] == passedValue)
            {
                isPassed = true;
            }

            Recursion(currentIndex + 2, index, passedValue, isPassed, result + 1);
            Recursion(currentIndex + 1, index, passedValue, isPassed, result + 1);
        }
    }
}