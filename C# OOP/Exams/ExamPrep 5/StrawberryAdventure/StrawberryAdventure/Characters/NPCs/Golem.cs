using StrawberryAdventure.Contracts;
using StrawberryAdventure.Utils;

namespace StrawberryAdventure.Characters.NPCs
{
    public class Golem : NPC, INPC, ICharacter
    {
        public Golem() 
            : base("Golem",Constants.GolemInitialAttack,Constants.GolemInitialDefense,Constants.GolemInitialHitPoints)
        {
        }
    }
}
