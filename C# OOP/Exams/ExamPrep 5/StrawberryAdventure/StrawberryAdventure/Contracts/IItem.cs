using StrawberryAdventure.Enums;

namespace StrawberryAdventure.Contracts
{
    public interface IItem
    {
        ItemType Type { get; set; }
        StatType StatToIncease { get; }
        int IncreasedValue { get; }
    }
}
