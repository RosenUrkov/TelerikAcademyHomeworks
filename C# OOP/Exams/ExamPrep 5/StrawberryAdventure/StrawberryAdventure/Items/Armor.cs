using StrawberryAdventure.Contracts;
using StrawberryAdventure.Enums;
using StrawberryAdventure.Items;

namespace StrawberryAdventure.Items
{
    public class Armor : Item, IItem
    {
        public Armor(int value) : base(StatType.HitPoints, value)
        {
            this.Type = ItemType.Armor;
        }
    }
}