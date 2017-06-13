using System;
using System.Collections.Generic;
using StrawberryAdventure.Enums;
using StrawberryAdventure.Contracts;
using StrawberryAdventure.Utils;

namespace StrawberryAdventure.Engine
{
    public sealed class Game
    {
        private static volatile Game instance;
        private static object syncRoot = new Object();

        static Game()
        {
            Console.WriteLine("               Welcome to Strawberry Adventure Game");
            Console.WriteLine();

            Console.WriteLine("Please choose a character: ");
            Console.WriteLine("For Assassin press 1 | For Tank press 2 | For Warrior press 3");

            int enumerationNumber;

            while (!int.TryParse(Console.ReadLine(),out enumerationNumber) || (enumerationNumber < 1 || enumerationNumber > 3))
            {
                Console.WriteLine(Constants.InvalidCommand);
                Console.WriteLine("For Assassin press 1 | For Tank press 2 | For Warrior press 3");                
            }

            var humanType = (HumanType)enumerationNumber;

            Console.WriteLine("Please give name to the character:");

            var name = Console.ReadLine();
            while (string.IsNullOrEmpty(name.Trim()))
            {
                Console.WriteLine(Constants.InvalidName);
                Console.WriteLine("Please give name to the character:");
                name = Console.ReadLine();
            }

            HumanCharacter = GameEngine.HandleCharacterChoice(humanType, name);

            Map.PrintMap();
            GameEngine.Start();
        }

        public static IHuman HumanCharacter { get; private set; }

        //Singleton
        public static Game GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        instance = new Game();
                    }
                }

                return instance;
            }
        }



    }
}