using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceInMatrix
{
    class Program
    {
        static int maxSequence = 0;

        static void Main()
        {
            int[] rowsAndCols = Console.ReadLine().Split(new char[] { ' ', ',', '.' }, StringSplitOptions.
                RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[,] matrix = new int[rows, cols];
            FillTheMatrix(matrix);

            SearchRows(matrix);
            SearchCols(matrix);
            SearchLeftDiagonals(matrix);
            SearchRightDiagonals(matrix);

            Console.WriteLine(maxSequence);

        }

        static void FillTheMatrix(int[,] table)
        {
            for (int rows = 0; rows < table.GetLength(0); rows++)
            {
                int[] rowNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int cols = 0; cols < table.GetLength(1); cols++)
                {
                    table[rows, cols] = rowNumbers[cols];
                }
            }
        }

        static void CheckSequence(List<int> sequenceOfNumbers)
        {
            int currentSequenceCount = 1;
            for (int i = 0; i < sequenceOfNumbers.Count - 1; i++)
            {
                if (sequenceOfNumbers[i] != sequenceOfNumbers[i + 1])
                {
                    if (currentSequenceCount > maxSequence)
                    {
                        maxSequence = currentSequenceCount;
                    }
                    currentSequenceCount = 1;
                }
                else
                {
                    currentSequenceCount++;
                }
            }
            if (currentSequenceCount > maxSequence)
            {
                maxSequence = currentSequenceCount;
            }

        }

        static void SearchRows(int[,] table)
        {

            for (int rows = 0; rows < table.GetLength(0); rows++)
            {
                List<int> allNumbersInRow = new List<int>();

                for (int cols = 0; cols < table.GetLength(1); cols++)
                {
                    allNumbersInRow.Add(table[rows, cols]);
                }
                CheckSequence(allNumbersInRow);
            }

        }

        static void SearchCols(int[,] table)
        {

            for (int cols = 0; cols < table.GetLength(1); cols++)
            {
                List<int> allNumbersInCol = new List<int>();

                for (int rows = 0; rows < table.GetLength(0); rows++)
                {
                    allNumbersInCol.Add(table[rows, cols]);
                }
                CheckSequence(allNumbersInCol);
            }

        }

        static void SearchLeftDiagonals(int[,] table)
        {
            //before main diagonal
            for (int rows = table.GetLength(0); rows > 0; rows--)
            {
                int row = rows;
                int col = 0;
                List<int> allNumbersInLeftDiagonal = new List<int>();

                while (row < table.GetLength(0) && col < table.GetLength(1))
                {
                    allNumbersInLeftDiagonal.Add(table[row, col]);
                    row++;
                    col++;
                }
                CheckSequence(allNumbersInLeftDiagonal);
            }

            //up to main diagonal
            for (int cols = 0; cols < table.GetLength(1); cols++)
            {
                int row = 0;
                int col = cols;
                List<int> allNumbersInLeftDiagonal = new List<int>();

                while (row < table.GetLength(0) && col < table.GetLength(1))
                {
                    allNumbersInLeftDiagonal.Add(table[row, col]);
                    row++;
                    col++;
                }
                CheckSequence(allNumbersInLeftDiagonal);
            }
        }

        static void SearchRightDiagonals(int[,] table)
        {
            //up to main diagonal
            for (int rows = 0; rows < table.GetLength(0); rows++)
            {
                int row = rows;
                int col = 0;
                List<int> allNumbersInRightDiagonal = new List<int>();

                while (row >= 0 && col < table.GetLength(1))
                {
                    allNumbersInRightDiagonal.Add(table[row, col]);
                    row--;
                    col++;
                }
                CheckSequence(allNumbersInRightDiagonal);
            }

            //after main diagonal
            for (int cols = 1; cols < table.GetLength(1); cols++)
            {
                int row = table.GetLength(0) - 1;
                int col = cols;
                List<int> allNumbersInRightDiagonal = new List<int>();

                while (row >= 0 && col < table.GetLength(1))
                {
                    allNumbersInRightDiagonal.Add(table[row, col]);
                    row--;
                    col++;
                }
                CheckSequence(allNumbersInRightDiagonal);
            }
        }


    }

}

