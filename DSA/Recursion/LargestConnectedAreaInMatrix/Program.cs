using System;
using System.Collections.Generic;
using System.Linq;

namespace LargestConnectedAreaInMatrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] matrix =
            {
                { " ", "x", " ", "x", " " },
                { " ", "x", " ", " ", "x" },
                { " ", "x", "x", " ", " " },
                { "x", " ", " ", "x", " " },
                { " ", " ", " ", " ", "x" },
            };

            var result = FindAllConnectedAreas(matrix).OrderByDescending(x => x.Value).FirstOrDefault().Key;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(result[row, col]+ " ");
                }

                Console.WriteLine();
            }
        }

        private static Dictionary<string[,], int> FindAllConnectedAreas(string[,] matrix)
        {
            var visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            var result = new Dictionary<string[,], int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != "x" && !visited[row, col])
                    {
                        var resultAreas = new string[matrix.GetLength(0), matrix.GetLength(1)];
                        for (int i = 0; i < resultAreas.GetLength(0); i++)
                        {
                            for (int j = 0; j < resultAreas.GetLength(1); j++)
                            {
                                resultAreas[i, j] = "-";
                            }
                        }    

                        var resultAreasCount = FindConnectedArea(row, col, matrix, visited, resultAreas);
                        result.Add(resultAreas, resultAreasCount);
                    }
                }
            }

            return result;
        }

        private static int FindConnectedArea(int currentX, int currentY, string[,] matrix, bool[,] visited, string[,] resultArea)
        {
            visited[currentX, currentY] = true;
            resultArea[currentX, currentY] = "V";
            int connectedAreasCount = 1;

            if (currentX + 1 < matrix.GetLength(0) &&
                matrix[currentX + 1, currentY] != "x" &&
                !visited[currentX + 1, currentY])
            {
                connectedAreasCount += FindConnectedArea(currentX + 1, currentY, matrix, visited, resultArea);
            }

            if (currentY + 1 < matrix.GetLength(1) &&
               matrix[currentX, currentY + 1] != "x" &&
               !visited[currentX, currentY + 1])
            {
                connectedAreasCount += FindConnectedArea(currentX, currentY + 1, matrix, visited, resultArea);
            }

            if (currentX - 1 >= 0 &&
                matrix[currentX - 1, currentY] != "x" &&
                !visited[currentX - 1, currentY])
            {
                connectedAreasCount += FindConnectedArea(currentX - 1, currentY, matrix, visited, resultArea);
            }

            if (currentY - 1 >= 0 &&
                matrix[currentX, currentY - 1] != "x" &&
                !visited[currentX, currentY - 1])
            {
                connectedAreasCount += FindConnectedArea(currentX, currentY - 1, matrix, visited, resultArea);
            }

            return connectedAreasCount;
        }
    }
}
