using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialValue
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                jagged[i] = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            long result = Calculate(jagged);
            Console.WriteLine(result);

        }

        static long Calculate(int[][] jagged)
        {
            long maxValue = long.MinValue;
            for (int i = 0; i < jagged[0].Length; i++)
            {
                long currentValue = 0;
                int moves = 1;
                int row = 0;
                int col = i;
                bool[][] booleanJagged = BoolenCreate(jagged);
                bool isValid = true;

                while (jagged[row][col] >= 0)
                {
                    if (booleanJagged[row][col] == true)
                    {
                        isValid = false;
                        break;
                    }
                    booleanJagged[row][col] = true;
                    //currentValue += jagged[row][col];
                    col = jagged[row][col];
                    if (row + 1 == jagged.Length)
                    {
                        row = 0;
                    }
                    else
                    {
                        row++;
                    }
                    moves++;
                }

                if (!isValid)
                {
                    continue;
                }

                currentValue += Math.Abs(jagged[row][col]) + moves;
                maxValue = ValidateBigger(currentValue, maxValue);

            }

            return maxValue;
        }

        static bool[][] BoolenCreate(int[][] jagged)
        {
            bool[][] boolenJagged = new bool[jagged.Length][];
            for (int i = 0; i < jagged.Length; i++)
            {
                boolenJagged[i] = new bool[jagged[i].Length];
            }

            return boolenJagged;
        }

        static long ValidateBigger(long current, long best)
        {
            return (current > best ? current : best);
        }
    }
}
