using StrawberryAdventure.Contracts;
using StrawberryAdventure.Enums;

namespace StrawberryAdventure.Items
{
    public class Shield : Item, IItem
    {
        public Shield(int value) : base(StatType.Defense,value)
        {
            this.Type = ItemType.Shield;
        }
    }
}
