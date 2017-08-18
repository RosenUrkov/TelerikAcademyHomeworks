using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyTasks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var coef = int.Parse(Console.ReadLine());

            int minTaskValue = list[0];
            int maxTaskValue = list[0];

            int result = 0;
            var isEnded = false;
            for (int i = 0; i < list.Count; i++)
            {
                result++;

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
                    isEnded = true;
                    Console.WriteLine(result);
                    break;
                }

                if (i + 1 < list.Count &&
                    (list[i + 1] - minTaskValue >= coef ||
                    maxTaskValue - list[i + 1] >= coef))
                {
                    continue;
                }
                else if (i + 2 < list.Count &&
                    ((list[i + 2] - minTaskValue < coef &&
                    list[i + 2] - list[i + 1] >= coef) ||
                    (maxTaskValue - list[i + 2] < coef &&
                    list[i + 1] - list[i + 2] >= coef)))
                {
                    continue;
                }
                else if (i + 3 < list.Count &&
                    ((list[i + 3] - list[i + 2] < coef &&
                    list[i + 3] - list[i + 1] >= coef) ||
                    (list[i + 2] - list[i + 3] < coef &&
                    list[i + 1] - list[i + 3] >= coef)))
                {
                    continue;
                }
                else
                {
                    i++;
                }
            }

            if (!isEnded)
            {
                Console.WriteLine(list.Count);
            }
        }
    }
}