using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoverOf3
{
    class Program
    {
        static int positionRow;
        static int positionCol;
        static bool[,] booleanMatrix;

        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
            long[,] matrix = new long[rows, cols];
            booleanMatrix = new bool[rows, cols];

            FillMatrix(matrix);

            int numberOfCommands = int.Parse(Console.ReadLine());
            long sumOfMoves = 0;
            positionRow = matrix.GetLength(0) - 1;
            positionCol = 0;

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();
                string direction = command[0];
                int moves = int.Parse(command[1]);
                sumOfMoves += MovesMenu(direction, moves, matrix);

            }

            Console.WriteLine(sumOfMoves);

        }

        static void FillMatrix(long[,] matrix)
        {
            int counter = -1;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                counter++;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = counter * 3 + col * 3;
                }
            }
        }

        //static void PrintMatrix(long[,] matrix)
        //{
        //    for (int row = 0; row < matrix.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < matrix.GetLength(1); col++)
        //        {
        //            Console.Write("{0,4}", matrix[row, col]);
        //        }
        //        Console.WriteLine();
        //    }
        //}

        static long MovesMenu(string direction, int moves, long[,] matrix)
        {
            long result = 0;
            moves--;

            if ((direction == "RU") || (direction == "UR"))
            {
                for (int i = 0; i < moves; i++)
                {
                    positionRow--;
                    positionCol++;
                    if ((positionRow == -1) || (positionCol == matrix.GetLength(1)))
                    {
                        positionRow++;
                        positionCol--;
                        break;
                    }
                    if (booleanMatrix[positionRow, positionCol] == true)
                    {
                        continue;
                    }
                    booleanMatrix[positionRow, positionCol] = true;
                    result += matrix[positionRow, positionCol];

                }

                return result;
            }

            else if ((direction == "LU") || (direction == "UL"))
            {
                for (int i = 0; i < moves; i++)
                {
                    positionRow--;
                    positionCol--;
                    if ((positionRow == -1) || (positionCol == -1))
                    {
                        positionRow++;
                        positionCol++;
                        break;
                    }
                    if (booleanMatrix[positionRow, positionCol] == true)
                    {
                        continue;
                    }
                    booleanMatrix[positionRow, positionCol] = true;
                    result += matrix[positionRow, positionCol];

                }

                return result;

            }

            else if ((direction == "DL") || (direction == "LD"))
            {
                for (int i = 0; i < moves; i++)
                {
                    positionRow++;
                    positionCol--;
                    if ((positionRow == matrix.GetLength(0)) || (positionCol == -1))
                    {
                        positionRow--;
                        positionCol++;
                        break;
                    }
                    if (booleanMatrix[positionRow, positionCol] == true)
                    {
                        continue;
                    }
                    booleanMatrix[positionRow, positionCol] = true;
                    result += matrix[positionRow, positionCol];

                }

                return result;

            }

            else if ((direction == "RD") || (direction == "DR"))
            {
                for (int i = 0; i < moves; i++)
                {
                    positionRow++;
                    positionCol++;
                    if ((positionRow == matrix.GetLength(0)) || (positionCol == matrix.GetLength(1)))
                    {
                        positionRow--;
                        positionCol--;
                        break;
                    }
                    if (booleanMatrix[positionRow, positionCol] == true)
                    {
                        continue;
                    }
                    booleanMatrix[positionRow, positionCol] = true;
                    result += matrix[positionRow, positionCol];
                }

                return result;
            }

            return result;
        }
    }
}
