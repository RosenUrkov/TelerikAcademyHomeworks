namespace StrawberryAdventure.Engine
{
    using System;
    using System.IO;
    using System.Linq;
    using Utils;

    public static class Map
    {
        public const string MapLegend = "Map legend: | You: V | Texture: - | Rock: # | Chest: o | Enemy: @ | Goal: X |";

        private static char[,] gameMap;
        private static string path;

        static Map()
        {
            CurrRow = Constants.InitialRow;
            CurrCol = Constants.InitialCol;
            path = Generator.GetRandomMap();
            ReadMap(path);         
        }

        public static int CurrRow { get; set; }
        public static int CurrCol { get; set; }
        public static char[,] GameMap { get { return gameMap; } }               

        private static void ReadMap(string path)
        {
            bool isFirst = true;
            using(var reader = new StreamReader(path))
            {
                if (isFirst)
                {
                    isFirst = false;
                    var rowsAndCols = reader.ReadLine().Split('x').Select(int.Parse).ToList();
                    gameMap = new char[rowsAndCols[0], rowsAndCols[1]];
                }

                for (int rows = 0; rows < gameMap.GetLength(0); rows++)
                {
                    var line = reader.ReadLine().ToCharArray();
                    for (int cols = 0; cols < gameMap.GetLength(1); cols++)
                    {
                        gameMap[rows, cols] = line[cols];
                    }
                }
            }
        }

        public static void PrintMap()
        {
            Console.WriteLine();
            for (int rows = 0; rows < gameMap.GetLength(0); rows++)
            {
                for (int cols = 0; cols < gameMap.GetLength(1); cols++)
                {
                    Console.Write(gameMap[rows, cols]);
                }
                Console.WriteLine();
            }

            Console.WriteLine(Map.MapLegend);
            Console.WriteLine();
        }
        
    }
}
