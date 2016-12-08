using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fill_Matrix
{
    class Program
    {

        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            char layout = (char)Console.Read();

            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

            string direction = string.Empty;

            int row = 0;
            int col = 0;

            if (layout == 'a')
            {
                for (int counter = 1; counter <= sizeOfMatrix * sizeOfMatrix; counter++)
                {
                    matrix[row, col] = counter;
                    row++;
                    if (row == sizeOfMatrix)
                    {
                        col++;
                        row = 0;
                    }
                }
            }

            else if (layout == 'b')
            {
                direction = "down";

                for (int counter = 1; counter <= sizeOfMatrix * sizeOfMatrix; counter++)
                {

                    if (direction == "down")
                    {
                        matrix[row, col] = counter;
                        row++;
                        if (row == sizeOfMatrix)
                        {
                            direction = "rightDown";
                            row--;
                            col++;
                        }

                    }
                    else if (direction == "rightDown")
                    {
                        matrix[row, col] = counter;
                        direction = "up";
                        row--;
                    }
                    else if (direction == "up")
                    {
                        matrix[row, col] = counter;
                        row--;
                        if (row == -1)
                        {
                            direction = "rightUp";
                            row++;
                            col++;
                        }
                    }
                    else if (direction == "rightUp")
                    {
                        matrix[row, col] = counter;
                        direction = "down";
                        row++;
                    }
                }
            }

            if (layout == 'c')
            {
                int spin = 0;
                string position = "firstHalf";
                row = sizeOfMatrix - 1;
                for (int counter = 1; counter <= sizeOfMatrix * sizeOfMatrix; counter++)
                {
                    matrix[row, col] = counter;
                    row++;
                    col++;

                    if ((row == sizeOfMatrix) || (col == sizeOfMatrix))
                    {
                        if (position == "firstHalf")
                        {
                            spin++;
                            row = row - spin - 1;
                            col = col - spin;

                            if (spin + 1 == sizeOfMatrix)
                            {
                                position = "secondHalf";
                            }
                        }

                        else if (position == "secondHalf")
                        {

                            row = row - spin - 1;
                            col = col - spin;
                            spin--;

                        }

                    }

                }


            }

            else if (layout == 'd')
            {
                direction = "down";
                int spin = 0;

                for (int counter = 1; counter <= sizeOfMatrix * sizeOfMatrix; counter++)
                {

                    if (direction == "down")
                    {
                        matrix[row, col] = counter;
                        row++;
                        if (row == sizeOfMatrix - spin)
                        {
                            direction = "right";
                            row--;
                            col++;
                        }

                    }

                    else if (direction == "right")
                    {
                        matrix[row, col] = counter;
                        col++;
                        if (col == sizeOfMatrix - spin)
                        {
                            direction = "up";
                            col--;
                            row--;
                        }

                    }

                    else if (direction == "up")
                    {
                        matrix[row, col] = counter;
                        row--;
                        if (row == spin - 1)
                        {
                            direction = "left";
                            row++;
                            col--;
                        }
                    }
                    else if (direction == "left")
                    {
                        matrix[row, col] = counter;
                        col--;
                        if (col == spin)
                        {
                            spin++;
                            direction = "down";
                            col++;
                            row++;
                        }
                    }
                }
            }

            //print matrix
            for (int rows = 0; rows < sizeOfMatrix; rows++)
            {
                for (int cols = 0; cols < sizeOfMatrix; cols++)
                {
                    if (cols == 0)
                    {
                        Console.Write(matrix[rows, cols]);
                    }
                    else
                    {
                        Console.Write(" " + matrix[rows, cols]);
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
