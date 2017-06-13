using System;

namespace StrawberryAdventure.Utils
{
    public struct Constants
    {       
        //map constants
        public const char MapTexture = '-';
        public const char RockSymbol = '#';
        public const char ChestSymbol = 'o';
        public const char EnemySymbol = '@';
        public const char GoalSymbol = 'X';
        public const char CharacterSymbol = 'V';

        //initial map entery
        public const int InitialRow = 1;
        public const int InitialCol = 7;

        //ingame messages
        public const string TextureEncounter = "*One step closer to the MAGIC STRAWBERRY!*";
        public const string RockEncounter = "You cannot move there - a rock in the path!";
        public const string ChestEncounter = "You found a chest! There is {0} inside and you get +{1} {2}!";
        public const string EnemyEncounter = "Enemy {0} encountered!";
        public const string KillCreature = "You took some damage but you killed the {0} and he dropped a {1} - you get +{2} {3}!";
        public const string GoalEncounter = "You found the Magic Strawberry! You Win!";
        public const string DeathEncounter = "You died... Game Over!";
        
        //character options
        public const string InvalidName = "Invalid name!";
        public const string GameMessage = "Type a command or 'options' to see all options:";
        public const string Options = "For your stats type 'hero' | For map type 'map' | For moveset type 'moveset'";        

        //command strings
        public const string InvalidCommand = "Invalid command!";
        public const string HeroStats = "Name: {0} | Attack: {1} | Defense: {2} | Hitpoints {3}";
        public const string Moveset = "For up press 'w' | For down press 's' | For left press 'a' | For right press 'd'";         

        //game value constants
        public const int MinIntGameValue = 0;
        public const int MaxIntGameValue = 100;

        //item increasing values
        public const int MinItemIncreaseValue = 5;
        public const int MaxItemIncreaseValue = 20;

        //initial human values
        public const int AssassinInitialAttack = 50;
        public const int AssassinInitialDefense = 30;
        public const int AssassinInitialHitPoints = 20;

        public const int TankInitialAttack = 20;
        public const int TankInitialDefense = 40;
        public const int TankInitialHitPoints = 40;

        public const int WarriorInitialAttack = 40;
        public const int WarriorInitialDefense = 30;
        public const int WarriorInitialHitPoints = 30;

        //initial NPC values
        public const int GolemInitialAttack = 20;
        public const int GolemInitialDefense = 60;
        public const int GolemInitialHitPoints = 40;

        public const int WolfInitialAttack = 60;
        public const int WolfInitialDefense = 40;
        public const int WolfInitialHitPoints = 20;

        public const int CyclopsInitialAttack = 40;
        public const int CyclopsInitialDefense = 40;
        public const int CyclopsInitialHitPoints = 40;
        
    }
}
