using StrawberryAdventure.Contracts;
using StrawberryAdventure.Enums;
using StrawberryAdventure.Items;

namespace StrawberryAdventure.Items
{
    public class Weapon : Item,IItem
    {       
        public Weapon(int value) : base(StatType.Attack,value)
        {
            this.Type = ItemType.Weapon;
        }
    }
}