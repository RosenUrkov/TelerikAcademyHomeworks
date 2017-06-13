using StrawberryAdventure.Contracts;
using StrawberryAdventure.Utils;

namespace StrawberryAdventure.Characters.NPCs
{
    public class Cyclops : NPC, INPC, ICharacter
    {
        public Cyclops() 
            : base("Cyclops",Constants.CyclopsInitialAttack,Constants.CyclopsInitialDefense,Constants.CyclopsInitialHitPoints)
        {
        }
    }
}
