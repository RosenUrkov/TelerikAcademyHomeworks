using System;
using System.Collections.Generic;
using StrawberryAdventure.Contracts;
using StrawberryAdventure.Utils;
using StrawberryAdventure.Enums;

namespace StrawberryAdventure.Characters.Humans
{
    public abstract class Human : Character, IHuman, ICharacter
    {
        private ICollection<IItem> items;

        public Human(string name, int attack, int defense, int hitPoints) : base(name, attack, defense, hitPoints)
        {
            this.items = new List<IItem>();
        }

        public ICollection<IItem> Items
        {
            get
            {
                return this.items;
            }
            private set
            {
                Validator.ValidateGameObjectInstance(value);
                this.items = value;
            }
        }

        public void AddItem(IItem item)
        {
            Validator.ValidateGameObjectInstance(item);

            switch (item.StatToIncease)
            {
                case StatType.Attack:
                    this.Attack += item.IncreasedValue;
                    break;
                case StatType.Defense:
                    this.Defense += item.IncreasedValue;
                    break;
                case StatType.HitPoints:
                    this.HitPoints += item.IncreasedValue;
                    break;
            }

            this.items.Add(item);
        }
    }
}
