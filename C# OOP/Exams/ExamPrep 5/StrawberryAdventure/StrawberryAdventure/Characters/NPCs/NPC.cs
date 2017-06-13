namespace StrawberryAdventure.Characters.NPCs
{
    using Contracts;
    using System.Collections.Generic;
    using System;
    using Utils;

    public abstract class NPC : Character, INPC, ICharacter
    {
        public NPC(string name, int attack, int defense, int hitPoints) : base(name, attack, defense, hitPoints)
        {
        }

        public IItem DropItem()
        {
            return Generator.GetRandomItem();
        }
    }
}
