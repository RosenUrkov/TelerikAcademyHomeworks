using System;

namespace EightQueensPuzzle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] chessboard =
           {
                { "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-" },
            };

            var checkedSquares = new bool[chessboard.GetLength(0), chessboard.GetLength(1)];
            PlaceQueens(0, 0, chessboard, checkedSquares);

            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    Console.Write(chessboard[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void PlaceQueens(int currentQueensCount, int queenCol, string[,] chessboard, bool[,] checkedSquares)
        {
            if (currentQueensCount == chessboard.GetLength(0))
            {
                return;
            }

            var queen = FindQueenPlace(currentQueensCount, checkedSquares);
            while (!queen.hasPlace)
            {
                RemoveQueen(queenCol, chessboard, checkedSquares);
                currentQueensCount--;

                queen = FindQueenPlace(queenCol, checkedSquares);
            }

            chessboard[queen.row, queen.col] = "X";
            CheckQueenSquares(queen.row, queen.col, checkedSquares, true);

            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    Console.Write(chessboard[row, col]);
                }

                Console.WriteLine();
            }
            Console.WriteLine();

            PlaceQueens(currentQueensCount + 1, queenCol + 1, chessboard, checkedSquares);
        }

        private static (int row, int col, bool hasPlace) FindQueenPlace(int queenCol, bool[,] checkedSqueares)
        {
            int col = queenCol % checkedSqueares.GetLength(0);

            for (int row = 0; row < checkedSqueares.GetLength(0); row++)
            {
                if (!checkedSqueares[row, col])
                {
                    return (row, col, true);
                }

            }

            return (-1, -1, false);
        }

        private static void CheckQueenSquares(int queenX, int queenY, bool[,] checkedSquares, bool checkValue)
        {
            for (int row = 0; row < checkedSquares.GetLength(0); row++)
            {
                for (int col = 0; col < checkedSquares.GetLength(1); col++)
                {
                    if (row == queenX ||
                        col == queenY ||
                        row + col == queenX + queenY ||
                        row - queenX == col - queenY)
                    {
                        checkedSquares[row, col] = checkValue;
                    }
                }
            }
        }

        private static void RemoveQueen(int currentQueenCol, string[,] chessboard, bool[,] checkedSquares)
        {
            bool isDeleted = false;
            for (int col = 0; col < chessboard.GetLength(0); col++)
            {
                col = (col + currentQueenCol + 1) % chessboard.GetLength(0);
                for (int row = 0; row < chessboard.GetLength(1); row++)
                {
                    if (chessboard[row, col] == "X")
                    {
                        chessboard[row, col] = "-";
                        CheckQueenSquares(row, col, checkedSquares, false);
                        isDeleted = true;
                        break;
                    }
                }

                if (isDeleted)
                {
                    break;
                }

            }

            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    if (chessboard[row, col] == "X")
                    {
                        CheckQueenSquares(row, col, checkedSquares, true);
                    }
                }
            }
        }
    }
}
