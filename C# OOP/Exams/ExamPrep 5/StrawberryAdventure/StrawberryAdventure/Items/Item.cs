using System;
using StrawberryAdventure.Contracts;
using StrawberryAdventure.Enums;
using StrawberryAdventure.Utils;

namespace StrawberryAdventure.Items
{
    public class Item : IItem
    {
        private int increasedValue;

        public Item(StatType statToIncrease, int value)
        {
            this.StatToIncease = statToIncrease;
            this.IncreasedValue = value;
        }

        public ItemType Type { get; set; }

        public int IncreasedValue
        {
            get
            {
                return this.increasedValue;
            }
            private set
            {
                Validator.ValidateGameIntValue(value);
                this.increasedValue = value;
            }
        }

        public StatType StatToIncease { get; private set; }
    }
}
