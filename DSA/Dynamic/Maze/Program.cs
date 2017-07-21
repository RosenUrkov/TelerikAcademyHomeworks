using System;

namespace Maze
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var map = new string[]
            {
                "         @          ",
                "    @           @   ",
                "                    ",
                "         @ @        ",
                "   @            @   ",
                "        @           ",
                "           @        ",
                "    @  @   @        ",
                "      @             ",
                "              @     ",
                "     @     @        ",
                "                   @",
                "                    "
            };

            Console.WriteLine(DFS(map));
            Console.WriteLine(Dynamic(map));
            Console.WriteLine(DynamicOptimised(map));
        }

        private static long Dynamic(string[] map)
        {
            var table = new long[map.Length, map[0].Length];
            table[0, 0] = 1;

            for (int row = 0; row < table.GetLength(0); row++)
            {
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    if (row == 0 && col == 0)
                    {
                        continue;
                    }

                    var top = row > 0 ? table[row - 1, col] : 0;
                    var left = col > 0 ? table[row, col - 1] : 0;

                    table[row, col] = map[row][col] == ' ' ? top + left : 0;
                }
            }

            return table[table.GetLength(0) - 1, table.GetLength(1) - 1];
        }

        private static long DynamicOptimised(string[] map)
        {
            var table = new long[2, map[0].Length + 1];
            table[0, 1] = 1;

            for (int row = 0; row < map.Length; row++)
            {
                for (int col = 1; col <= map[0].Length; col++)
                {
                    table[(row + 1) % 2, col] =
                                        map[row][col - 1] == ' '
                                        ? table[row % 2, col] + table[(row + 1) % 2, col - 1]
                                        : 0;
                }
            }

            return table[map.Length % 2, map[0].Length - 1];
        }

        private static long DFS(string[] map)
        {
            var memo = new long[map.Length, map[0].Length];
            for (int i = 0; i < memo.GetLength(0); i++)
            {
                for (int j = 0; j < memo.GetLength(1); j++)
                {
                    memo[i, j] = -1;
                }
            }

            return DFS(map, memo, 0, 0);
        }

        private static long DFS(string[] map, long[,] memo, int row, int col)
        {
            if (row == map.Length ||
                col == map[0].Length ||
                map[row][col] != ' ')
            {
                return 0;
            }

            if (row + 1 == map.Length && col + 1 == map[0].Length)
            {
                return 1;
            }

            if (memo[row, col] < 0)
            {
                var down = DFS(map, memo, row + 1, col);
                var right = DFS(map, memo, row, col + 1);

                memo[row, col] = down + right;
            }

            return memo[row, col];
        }
    }
}
