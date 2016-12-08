using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tron3D
{
    class Program
    {
        static string[,] matrix;

        static void Main(string[] args)
        {

            int[] sizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string redMoves = Console.ReadLine();
            string blueMoves = Console.ReadLine();
            matrix = new string[sizes[0] + 1, 2 * sizes[1] + 2 * sizes[2] + 4];

            //get them in there
            int one = 1;
            if (sizes[1] % 2 != 0)
            {
                one = 0;
            }

            int redMovesX = sizes[0] / 2;
            int redMovesY = (sizes[1] / 2);


            int blueMovesX = sizes[0] / 2;
            int blueMovesY = sizes[1] / 2 + sizes[1] + sizes[2] - one + 2;


            //mile kitic

            bool isFirst = true;
            int redCounter = 0;
            int blueCounter = 0;
            string directionRed = "right";
            string directionBlue = "left";
            bool RedWinner = false;
            bool BlueWinner = false;
            bool isContinued = false;


            while (true)
            {
                if (isFirst)
                {
                    isFirst = false;
                    matrix[redMovesX, redMovesY] = "Red";
                    matrix[blueMovesX, blueMovesY] = "Blue";

                }

                if (!isContinued)
                {                    
                    if (redMoves[redCounter] == 'L')
                    {
                        directionRed = NewDirection(directionRed, "left");
                        redCounter++;
                        continue;
                    }
                    else if (redMoves[redCounter] == 'R')
                    {
                        directionRed = NewDirection(directionRed, "right");
                        redCounter++;
                        continue;
                    }
                    else if (redMoves[redCounter] == 'M')
                    {
                        if (directionRed == "up")
                        {
                            if (!IsOut("up", redMovesX, redMovesY) && RedValide(redMovesX++, redMovesY))
                            {
                                redMovesX++;
                                matrix[redMovesX, redMovesY] = "Red";
                            }
                            else
                            {
                                BlueWinner = true;
                            }
                        }

                        if (directionRed == "down")
                        {
                            if (!IsOut("down", redMovesX, redMovesY) && RedValide(redMovesX--, redMovesY))
                            {
                                redMovesX--;
                                matrix[redMovesX, redMovesY] = "Red";
                            }
                            else
                            {
                                BlueWinner = true;
                            }
                        }

                        if (directionRed == "right")
                        {
                            if (!IsOut("right", redMovesX, redMovesY))
                            {
                                redMovesY++;
                            }
                            else
                            {
                                redMovesY = 0;

                            }

                            if (RedValide(redMovesX, redMovesY))
                            {
                                matrix[redMovesX, redMovesY] = "Red";
                            }
                            else
                            {
                                BlueWinner = true;

                            }
                        }

                        if (directionRed == "left")
                        {
                            if (!IsOut("left", redMovesX, redMovesY))
                            {
                                redMovesY--;
                            }
                            else
                            {
                                redMovesY = matrix.GetLength(0) - 1;

                            }

                            if (RedValide(redMovesX, redMovesY))
                            {
                                matrix[redMovesX, redMovesY] = "Red";
                            }
                            else
                            {
                                BlueWinner = true;

                            }
                        }
                    }
                }


                if (blueMoves[blueCounter] == 'L')
                {
                    directionBlue = NewDirection(directionBlue, "left");
                    blueCounter++;
                    isContinued = true;
                    continue;
                }
                else if (blueMoves[blueCounter] == 'R')
                {
                    directionBlue = NewDirection(directionBlue, "right");
                    blueCounter++;
                    isContinued = true;
                    continue;
                }
                else if (blueMoves[blueCounter] == 'M')
                {
                    isContinued = false;
                    if (directionBlue == "up")
                    {
                        if (!IsOut("up", blueMovesX, blueMovesY) && BlueValide(blueMovesX++, blueMovesY))
                        {
                            blueMovesX++;
                            matrix[blueMovesX, blueMovesY] = "Blue";
                        }
                        else
                        {
                            RedWinner = true;
                        }
                    }

                    if (directionBlue == "down")
                    {
                        if (!IsOut("down", blueMovesX, blueMovesY) && BlueValide(blueMovesX, blueMovesY))
                        {
                            blueMovesX--;
                            matrix[blueMovesX, blueMovesY] = "Blue";
                        }
                        else
                        {
                            RedWinner = true;

                        }
                    }

                    if (directionBlue == "right")
                    {
                        if (!IsOut("right", blueMovesX, blueMovesY))
                        {
                            blueMovesY++;
                        }
                        else
                        {
                            blueMovesY = 0;

                        }

                        if (BlueValide(blueMovesX, blueMovesY))
                        {
                            matrix[blueMovesX, blueMovesY] = "Blue";
                        }
                        else
                        {
                            RedWinner = true;

                        }
                    }

                    if (directionBlue == "left")
                    {
                        if (!IsOut("left", blueMovesX, blueMovesY))
                        {
                            blueMovesY--;
                        }
                        else
                        {
                            blueMovesY = matrix.GetLength(0) - 1;

                        }

                        if (BlueValide(blueMovesX, blueMovesY))
                        {
                            matrix[blueMovesX, blueMovesY] = "Blue";
                        }
                        else
                        {
                            RedWinner = true;

                        }
                    }
                }

                redCounter++;
                blueCounter++;

                if (RedWinner || BlueWinner || (redCounter + 1 == redMoves.Length) || (blueCounter + 1 == blueMoves.Length))
                {
                    break;
                }
            }

            if (RedWinner && BlueWinner)
            {
                Console.WriteLine("DRAW");
            }
            else if (BlueWinner)
            {
                Console.WriteLine("BLUE");
            }
            else if (RedWinner)
            {
                Console.WriteLine("RED");
            }
            else
            {
                Console.WriteLine("DRAW");
            }
        }

        static string NewDirection(string direction, string turn)
        {
            if (direction == "left")
            {
                if (turn == "left")
                {
                    return "down";
                }
                else if (turn == "right")
                {
                    return "up";
                }
            }

            else if (direction == "up")
            {
                if (turn == "left")
                {
                    return "left";
                }
                else if (turn == "right")
                {
                    return "right";
                }
            }

            else if (direction == "right")
            {
                if (turn == "left")
                {
                    return "up";
                }
                else if (turn == "right")
                {
                    return "down";
                }
            }

            else if (direction == "down")
            {
                if (turn == "left")
                {
                    return "right";
                }
                else if (turn == "right")
                {
                    return "left";
                }
            }

            return "not valid direction or turn";
        }

        static bool RedValide(int row, int col)
        {
            if (matrix[row, col] == "Blue")
            {
                return false;
            }
            return true;
        }

        static bool BlueValide(int row, int col)
        {
            if (matrix[row, col] == "Red")
            {
                return false;
            }
            return true;

        }

        static bool IsOut(string direction, int row, int col)
        {
            if (direction == "up")
            {
                if (row == 0)
                {
                    return true;
                }
                return false;
            }

            if (direction == "down")
            {
                if (row == matrix.GetLength(0) - 1)
                {
                    return true;
                }
                return false;
            }

            if (direction == "left")
            {
                if (col == matrix.GetLength(1) - 1)
                {
                    return true;
                }
                return false;
            }

            if (direction == "right")
            {
                if (col == 0)
                {
                    return true;
                }
                return false;
            }

            return false;

        }
    }
}
