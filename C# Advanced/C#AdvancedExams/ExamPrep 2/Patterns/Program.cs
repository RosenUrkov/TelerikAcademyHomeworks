using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            long[,] matrix = new long[size, size];
            FillMatrix(matrix);
            long result = FindPatterns(matrix);
            if (result == long.MinValue)
            {
                result = SumDiagonal(matrix);
                Console.WriteLine("NO {0}", result);
            }
            else
            {
                Console.WriteLine("YES {0}", result);
            }


        }
        static void FillMatrix(long[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                long[] colsNumbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = colsNumbers[cols];
                }

            }
        }

        static long FindPatterns(long[,] matrix)
        {
            long bestPattern = long.MinValue;

            for (int rows = 0; rows < matrix.GetLength(0) - 2; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 4; cols++)
                {
                    long currentPattern = 0;
                    var numbersInPatern = new List<long>();
                    bool isPattern = true;
                    //int counter = 0;

                    for (int currRow = 0; currRow < 3; currRow++)
                    {
                        for (int currCol = 0 + currRow; currCol < 3 + currRow; currCol++)
                        {
                            if (currRow == 1)
                            {
                                currentPattern += matrix[rows + currRow, cols + currCol + 1];
                                numbersInPatern.Add(matrix[rows + currRow, cols + currCol + 1]);
                                break;
                            }
                            currentPattern += matrix[rows + currRow, cols + currCol];
                            numbersInPatern.Add(matrix[rows + currRow, cols + currCol]);

                        }

                    }

                    for (int i = 0; i < numbersInPatern.Count - 1; i++)
                    {
                        if (numbersInPatern[i] + 1 != numbersInPatern[i + 1])
                        {
                            isPattern = false;
                            break;
                        }
                    }

                    if ((currentPattern > bestPattern) && isPattern)
                    {
                        bestPattern = currentPattern;
                    }

                }
            }

            return bestPattern;
        }

        static long SumDiagonal(long[,] matrix)
        {
            long result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result += matrix[i, i];
            }
            return result;
        }

    }
}
