using StrawberryAdventure.Engine;

namespace StrawberryAdventure.Contracts
{
    public interface IGame
    {
        IHuman HumanCharacter { get; }
        Game GetInstande {get;}
    }
}
