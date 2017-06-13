using StrawberryAdventure.Contracts;
using StrawberryAdventure.Utils;

namespace StrawberryAdventure.Characters.NPCs
{
    public class Wolf : NPC, INPC, ICharacter
    {
        public Wolf()
            : base("Wolf",Constants.WolfInitialAttack,Constants.WolfInitialDefense,Constants.WolfInitialHitPoints)
        {
        }
    }
}
