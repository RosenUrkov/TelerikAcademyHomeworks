namespace StrawberryAdventure.Contracts
{
    public interface ICharacter
    {
        string Name { get; }

        int Attack { get; }

        int Defense { get; }

        int HitPoints { get; set; }
    }
}
