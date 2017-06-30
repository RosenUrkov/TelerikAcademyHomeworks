using System;
using System.Linq;

namespace PathsInMatrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] matrix =
            {
                { " ", " ", " ", "x", " " },
                { " ", "x", " ", " ", "x" },
                { " ", " ", "x", " ", " " },
                { "x", " ", " ", "x", " " },
                { " ", " ", " ", " ", " " },
            };

            var visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            var coordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            FindPaths(coordinates[0], coordinates[1], coordinates[2], coordinates[3], matrix, visited);
        }

        private static void FindPaths(int currentX, int currentY, int endX, int endY, string[,] matrix, bool[,] visited)
        {
            visited[currentX, currentY] = true;

            if (currentX == endX && currentY == endY)
            {
                PrintPath(visited);
                visited[currentX, currentY] = false;
                return;
            }

            if (currentX + 1 < matrix.GetLength(0) &&
                matrix[currentX + 1, currentY] != "x" &&
                !visited[currentX + 1, currentY])
            {
                FindPaths(currentX + 1, currentY, endX, endY, matrix, visited);
            }

            if (currentY + 1 < matrix.GetLength(1) &&
                matrix[currentX, currentY + 1] != "x" &&
                !visited[currentX, currentY + 1])
            {
                FindPaths(currentX, currentY + 1, endX, endY, matrix, visited);
            }

            if (currentX - 1 >= 0 &&
                matrix[currentX - 1, currentY] != "x" &&
                !visited[currentX - 1, currentY])
            {
                FindPaths(currentX - 1, currentY, endX, endY, matrix, visited);
            }

            if (currentY - 1 >= 0 &&
                matrix[currentX, currentY - 1] != "x" &&
                !visited[currentX, currentY - 1])
            {
                FindPaths(currentX, currentY - 1, endX, endY, matrix, visited);
            }

            visited[currentX, currentY] = false;
        }

        private static void PrintPath(bool[,] visited)
        {
            int stepCounter = 1;
            for (int row = 0; row < visited.GetLength(0); row++)
            {
                for (int col = 0; col < visited.GetLength(1); col++)
                {
                    if (visited[row, col])
                    {
                        Console.Write("V");
                        stepCounter++;
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
