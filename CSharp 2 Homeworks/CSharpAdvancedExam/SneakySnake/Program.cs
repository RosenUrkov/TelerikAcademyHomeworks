using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakySnake
{
    class Program
    {
        static string[,] matrix;
        static int currRow;
        static int currCol;
        static int snakeLength;

        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split('x').Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            matrix = new string[rows, cols];
            FillMatrix();

            string[] moves = Console.ReadLine().Split(',').ToArray();
            snakeLength = 3;
            string output = "normal";
            int counter = 0;

            currRow = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[0, i] == "e")
                {
                    currCol = i;
                }
            }

            //PrintMatrix();

            while (output == "normal")
            {
                if (counter == moves.Length)
                {
                    output = "stuck";
                    break;
                }

                if (snakeLength == 0)
                {
                    output = "starve";
                    break;
                }

                output = MoveMenu(moves[counter]);             

                counter++;

                if (counter % 5 == 0)
                {
                    snakeLength--;
                }
               
            }

            StateValidate(output);
        }

        static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0:3}",matrix[ row,col]);
                }
                Console.WriteLine();
            }
        }

        static void FillMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string colChars = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colChars[col].ToString();
                }

            }
        }

        static string MoveMenu(string move)
        {
            string state = string.Empty;

            if (move == "s")
            {
                currRow++;
                if (currRow == matrix.GetLength(0))
                {
                    state = "lost";
                }
                else if (matrix[currRow, currCol] == "@")
                {
                    snakeLength++;
                    state = "normal";
                    matrix[currRow, currCol] = "-";
                }
                else if (matrix[currRow, currCol] == "%")
                {
                    state = "rock";
                }
                else if (matrix[currRow, currCol] == "e")
                {
                    state = "out";
                }
                else if (matrix[currRow, currCol] == "-")
                {
                    state = "normal";
                }

                return state;
            }

            if (move == "w")
            {
                currRow--;
                if (currRow == matrix.GetLength(0))
                {
                    state = "lost";
                }
                else if (matrix[currRow, currCol] == "@")
                {
                    snakeLength++;
                    state = "normal";
                    matrix[currRow, currCol] = "-";
                }
                else if (matrix[currRow, currCol] == "%")
                {
                    state = "rock";
                }
                else if (matrix[currRow, currCol] == "e")
                {
                    state = "out";
                }
                else if (matrix[currRow, currCol] == "-")
                {
                    state = "normal";
                }

                return state;
            }

            if (move == "a")
            {
                currCol--;
                if (currCol == -1)
                {
                    currCol = matrix.GetLength(1) - 1;
                }

                if (matrix[currRow, currCol] == "@")
                {
                    snakeLength++;
                    state = "normal";
                    matrix[currRow, currCol] = "-";
                }
                else if (matrix[currRow, currCol] == "%")
                {
                    state = "rock";
                }
                else if (matrix[currRow, currCol] == "e")
                {
                    state = "out";
                }
                else if (matrix[currRow, currCol] == "-")
                {
                    state = "normal";
                }

                return state;
            }

            if (move == "d")
            {
                currCol++;
                if (currCol == matrix.GetLength(1))
                {
                    currCol = 0;
                }

                if (matrix[currRow, currCol] == "@")
                {
                    snakeLength++;
                    state = "normal";
                    matrix[currRow, currCol] = "-";
                }
                else if (matrix[currRow, currCol] == "%")
                {
                    state = "rock";
                }
                else if (matrix[currRow, currCol] == "e")
                {
                    state = "out";
                }
                else if (matrix[currRow, currCol] == "-")
                {
                    state = "normal";
                }

                return state;
            }

            return state;
        }

        static void StateValidate(string output)
        {
            if (output == "out")
            {
                Console.WriteLine("Sneaky is going to get out with length {0}", snakeLength);
            }
            else if (output == "stuck")
            {
                Console.WriteLine("Sneaky is going to be stuck in the den at [{0},{1}]", currRow, currCol);
            }
            else if (output == "starve")
            {
                Console.WriteLine("Sneaky is going to starve at [{0},{1}]", currRow, currCol);
            }
            else if (output == "lost")
            {
                Console.WriteLine("Sneaky is going to be lost into the depths with length {0}", snakeLength);
            }
            else if (output == "rock")
            {
                Console.WriteLine("Sneaky is going to hit a rock at [{0},{1}]", currRow, currCol);
            }
            else
            {
                Console.WriteLine("How did you break it?");
            }
        }
    }
}
