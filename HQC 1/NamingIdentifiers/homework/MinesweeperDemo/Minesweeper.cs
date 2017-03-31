namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        public static void Main()
        {
            const int MAX_TURNS_COUNT = 35;

            char[,] field = CreateGameField();
            char[,] mineField = PlantMines();

            int turnCounter = 0;
            string command = string.Empty;
            bool isMineExploded = false;

            var bestScorePlayers = new List<Score>(6);

            int row = 0;
            int col = 0;

            bool isNewGameStarted = true;
            bool isPlayerWonTheGame = false;

            do
            {
                if (isNewGameStarted)
                {
                    Console.WriteLine("Lets play \"Minesweeper\". Try to hit only boxes without mines and you will win." +
                    " Command 'top' shows the scoreboard, 'restart' starts new game, 'exit' closes the game. Have fun!");

                    PrintField(field);

                    isNewGameStarted = false;
                }

                Console.Write("Enter row and colomn : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowScoreboard(bestScorePlayers);
                        break;

                    case "restart":
                        field = CreateGameField();
                        mineField = PlantMines();

                        PrintField(field);

                        isMineExploded = false;
                        isNewGameStarted = false;
                        break;

                    case "exit":
                        Console.WriteLine("bye bye!");
                        Console.WriteLine();
                        break;

                    case "turn":
                        if (mineField[row, col] != '*')
                        {
                            if (mineField[row, col] == '-')
                            {
                                StartNextTurn(field, mineField, row, col);
                                turnCounter++;
                            }

                            if (MAX_TURNS_COUNT == turnCounter)
                            {
                                isPlayerWonTheGame = true;
                            }
                            else
                            {
                                PrintField(field);
                            }
                        }
                        else
                        {
                            isMineExploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command!\n");
                        break;
                }

                if (isMineExploded)
                {
                    PrintField(mineField);

                    Console.WriteLine("\nYou lost the game with {0} points.", turnCounter);
                    Console.WriteLine("Enter nickname: ");

                    string nickname = Console.ReadLine();
                    Score score = new Score(nickname, turnCounter);

                    if (bestScorePlayers.Count < 5)
                    {
                        bestScorePlayers.Add(score);
                    }
                    else
                    {
                        for (int i = 0; i < bestScorePlayers.Count; i++)
                        {
                            if (bestScorePlayers[i].Points < score.Points)
                            {
                                bestScorePlayers.Insert(i, score);
                                bestScorePlayers.RemoveAt(bestScorePlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    bestScorePlayers.Sort((Score firstPlayer, Score secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    bestScorePlayers.Sort((Score firstPlayer, Score secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));

                    ShowScoreboard(bestScorePlayers);

                    field = CreateGameField();
                    mineField = PlantMines();

                    turnCounter = 0;

                    isMineExploded = false;
                    isNewGameStarted = true;
                }

                if (isPlayerWonTheGame)
                {
                    Console.WriteLine("\nYou won, nice!");
                    PrintField(mineField);
                    Console.WriteLine("Enter nickname: ");

                    string name = Console.ReadLine();
                    Score score = new Score(name, turnCounter);

                    bestScorePlayers.Add(score);
                    ShowScoreboard(bestScorePlayers);

                    field = CreateGameField();
                    mineField = PlantMines();

                    turnCounter = 0;

                    isPlayerWonTheGame = false;
                    isNewGameStarted = true;
                }
            }
            while (command != "exit");
        }

        private static void ShowScoreboard(List<Score> scores)
        {
            Console.WriteLine("\nScoreboard:");
            if (scores.Count > 0)
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, scores[i].Name, scores[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty scoreboard!\n");
            }
        }

        private static void StartNextTurn(char[,] field, char[,] mines, int row, int col)
        {
            char minesCount = CalculateMines(mines, row, col);
            mines[row, col] = minesCount;
            field[row, col] = minesCount;
        }

        private static void PrintField(char[,] board)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < col; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlantMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> minesCoordinates = new List<int>();

            while (minesCoordinates.Count < 15)
            {
                Random random = new Random();
                int mineCoordinates = random.Next(50);

                if (!minesCoordinates.Contains(mineCoordinates))
                {
                    minesCoordinates.Add(mineCoordinates);
                }
            }

            foreach (int mineCoodinates in minesCoordinates)
            {
                int col = mineCoodinates / cols;
                int row = mineCoodinates % cols;

                if (row == 0 && mineCoodinates != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                gameField[col, row - 1] = '*';
            }

            return gameField;
        }

        // is not used
        private static void InitialCalculateMinesMaybe(char[,] mineField)
        {
            int col = mineField.GetLength(0);
            int row = mineField.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (mineField[i, j] != '*')
                    {
                        char minesCount = CalculateMines(mineField, i, j);
                        mineField[i, j] = minesCount;
                    }
                }
            }
        }

        private static char CalculateMines(char[,] mineField, int row, int col)
        {
            int minesCount = 0;

            int rows = mineField.GetLength(0);
            int cols = mineField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (mineField[row - 1, col] == '*')
                {
                    minesCount++;
                }
            }

            if (row + 1 < rows)
            {
                if (mineField[row + 1, col] == '*')
                {
                    minesCount++;
                }
            }

            if (col - 1 >= 0)
            {
                if (mineField[row, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (col + 1 < cols)
            {
                if (mineField[row, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (mineField[row - 1, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (mineField[row - 1, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (mineField[row + 1, col - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (mineField[row + 1, col + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}
