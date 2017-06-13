using StrawberryAdventure.Characters.Humans;
using StrawberryAdventure.Contracts;
using StrawberryAdventure.Enums;
using StrawberryAdventure.Utils;
using System;

namespace StrawberryAdventure.Engine
{
    public class GameEngine
    {
        private static bool isEnded;

        public static IHuman HandleCharacterChoice(HumanType human,string name)
        {
            switch (human)
            {
                case HumanType.Assassin:
                    return new Assassin(name);
                case HumanType.Tank:
                    return new Tank(name);
                case HumanType.Warrior:
                    return new Warrior(name);
                default:
                    throw new ArgumentException("Type must be from ItemType enumeration.");
            }
        }

        public static void Start()
        {
            isEnded = false;
             
            while (!isEnded)
            {
                Console.WriteLine(Constants.GameMessage);
                var command = Console.ReadLine().Trim();
                HandleCommand(command);
            }
        }

        private static void HandleCommand(string command)
        {
            Validator.ValidateString(command);
            if (command.Length == 1)
            {
                HandleMovesetCommand(Convert.ToChar(command));
            }
            else
            {

                switch (command)
                {
                    case "hero":
                        Console.WriteLine(string.Format(Constants.HeroStats, Game.HumanCharacter.Name,
                            Game.HumanCharacter.Attack, Game.HumanCharacter.Defense, Game.HumanCharacter.HitPoints));
                        break;
                    case "map":
                        Map.PrintMap();
                        break;
                    case "moveset":
                        Console.WriteLine(Constants.Moveset);
                        break;
                    case "options":
                        Console.WriteLine(Constants.Options);
                        break;
                    default:
                        Console.WriteLine(Constants.InvalidCommand);
                        break;
                }
            }
           // Console.WriteLine();
        }

        private static void HandleMovesetCommand(char move)
        {
            switch (move)
            {
                case 'w':
                    CheckMove(Map.CurrRow - 1, Map.CurrCol);
                    break;
                case 'a':
                    CheckMove(Map.CurrRow, Map.CurrCol-1);
                    break;
                case 'd':
                    CheckMove(Map.CurrRow, Map.CurrCol+1);
                    break;
                case 's':
                    CheckMove(Map.CurrRow + 1, Map.CurrCol);
                    break;
                default:
                    Console.WriteLine(Constants.InvalidCommand);
                    break;
            }
        }        

        private static void CheckMove(int row, int col)
        {            
            switch (Map.GameMap[row, col])
            {
                case Constants.MapTexture:
                    Console.WriteLine(Constants.TextureEncounter);
                    ChangeHeroPosition(row, col);
                    break;

                case Constants.RockSymbol:
                    Console.WriteLine(Constants.RockEncounter);
                    break;

                case Constants.ChestSymbol:                    
                    var item = Generator.GetRandomItem();
                    Console.WriteLine(string.Format(Constants.ChestEncounter,item.Type
                        ,item.IncreasedValue,item.StatToIncease));
                    Game.HumanCharacter.AddItem(item);
                    ChangeHeroPosition(row, col);
                    break;

                case Constants.EnemySymbol:
                    var enemy = Generator.GetRandomNPC();
                    Console.WriteLine(string.Format(Constants.EnemyEncounter,enemy.Name));
                    HandleBattle(Game.HumanCharacter, enemy);
                    ChangeHeroPosition(row, col);
                    break;

                case Constants.GoalSymbol:
                    Console.WriteLine(Constants.GoalEncounter);
                    isEnded = true;
                    break;

                default:
                    break;                    

            }
        }

        private static void HandleBattle(IHuman character,INPC enemy)
        {
            while (character.HitPoints<=0||enemy.HitPoints<=0)
            {
                enemy.HitPoints -= (character.Attack-enemy.Defense/2);
                character.HitPoints -= (enemy.Attack-character.Defense/2);
            }
            
            if (character.HitPoints <= 0)
            {
                isEnded = true;
                Console.WriteLine(Constants.DeathEncounter);
            }
            else
            {
                var dropped = enemy.DropItem();
                Console.WriteLine(string.Format
                    (Constants.KillCreature, enemy.Name,dropped.Type,dropped.IncreasedValue,dropped.StatToIncease));                               
                character.AddItem(dropped);
            }
        }

        private static void ChangeHeroPosition(int row,int col)
        {
            Map.GameMap[Map.CurrRow, Map.CurrCol] = '-';
            Map.CurrRow = row;
            Map.CurrCol = col;
            Map.GameMap[row, col] = 'V';
        }

    }
}
