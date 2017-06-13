using System;
using System.Collections.Generic;
using StrawberryAdventure.Contracts;
using StrawberryAdventure.Utils;

namespace StrawberryAdventure.Characters.Humans
{
    public class Tank : Human,ICharacter,IHuman
    {
        public Tank(string name)
            : base(name, Constants.TankInitialAttack, Constants.TankInitialDefense, Constants.TankInitialHitPoints)
        {
        }
        
    }
}
