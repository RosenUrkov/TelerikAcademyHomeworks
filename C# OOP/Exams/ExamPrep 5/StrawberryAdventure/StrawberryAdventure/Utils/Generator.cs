using StrawberryAdventure.Characters.NPCs;
using StrawberryAdventure.Contracts;
using StrawberryAdventure.Enums;
using StrawberryAdventure.Items;
using System;
using System.Collections.Generic;
using System.Linq;
namespace StrawberryAdventure.Utils
{
    public static class Generator
    {
        //generator for the game
        public static Random RNGenerator = new Random();        

        public static IItem GetRandomItem()
        {
            var type = (ItemType)Generator.RNGenerator.Next(3);

            switch (type)
            {
                case ItemType.Armor:
                    return new Armor(Generator.RNGenerator.Next(Constants.MinItemIncreaseValue, Constants.MaxItemIncreaseValue));
                case ItemType.Shield:
                    return new Shield(Generator.RNGenerator.Next(Constants.MinItemIncreaseValue, Constants.MaxItemIncreaseValue));
                case ItemType.Weapon:
                    return new Weapon(Generator.RNGenerator.Next(Constants.MinItemIncreaseValue, Constants.MaxItemIncreaseValue));
                default:
                    throw new ArgumentException("Type must be from ItemType enumeration.");
            }
        }

        public static INPC GetRandomNPC()
        {
            var type = (NPCType)Generator.RNGenerator.Next(3);

            switch (type)
            {
                case NPCType.Cyclops:
                    return new Cyclops();
                case NPCType.Golem:
                    return new Golem();
                case NPCType.Wolf:
                    return new Wolf();
                default:
                    throw new ArgumentException("Type must be from NPCType enumeration.");
            }
        }

        public static string GetRandomMap()
        {
            var number = RNGenerator.Next(0,3);
            var path = "../../Map/";            

            switch (number)
            {
                case 0:
                    return path += "FirstMap.txt";
                case 1:
                    return path += "SecondMap.txt";
                case 2:
                    return path += "ThirdMap.txt";
                default:
                    return "";
            }
        }
       
    }
}
