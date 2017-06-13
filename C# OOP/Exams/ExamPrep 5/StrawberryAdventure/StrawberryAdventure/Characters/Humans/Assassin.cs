using System;
using System.Collections.Generic;
using StrawberryAdventure.Contracts;
using StrawberryAdventure.Utils;

namespace StrawberryAdventure.Characters.Humans
{
    public class Assassin : Human,ICharacter,IHuman
    {
        public Assassin(string name) 
            : base(name,Constants.AssassinInitialAttack,Constants.AssassinInitialDefense,Constants.AssassinInitialHitPoints)
        {
        }
        
    }
}
