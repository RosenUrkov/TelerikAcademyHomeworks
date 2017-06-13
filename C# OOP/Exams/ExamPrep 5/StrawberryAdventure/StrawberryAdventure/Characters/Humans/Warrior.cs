using System;
using System.Collections.Generic;
using StrawberryAdventure.Contracts;
using StrawberryAdventure.Utils;

namespace StrawberryAdventure.Characters.Humans
{
    public class Warrior : Human,ICharacter,IHuman
    {
        public Warrior(string name) 
            : base(name, Constants.WarriorInitialAttack, Constants.WarriorInitialDefense, Constants.WarriorInitialHitPoints)
        {
        }
        
    }
}
